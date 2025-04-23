using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
	public partial class player : ViewController
	{
        public Grid Grid;
        public Tilemap Tilemap;
        void Start()
		{
            Debug.Log("@@@@@");
		}

     

        private void Update()
        {
            var cellPosition = Grid.WorldToCell(transform.position);

            var grid = FindObjectOfType<GridController>().ShowGrid;
            var tileWorldPos = Grid.CellToWorld(cellPosition);
            tileWorldPos.x += Grid.cellSize.x * 0.5f;
            tileWorldPos.y += Grid.cellSize.y * 0.5f;

            if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
            {
                TlieSelectController.Instance.Position(tileWorldPos);
                TlieSelectController.Instance.Show();
            }
            else
            {
                TlieSelectController.Instance.Hide();
            }
            if (Input.GetMouseButtonDown(0))
            {
             
                if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
                {
                    //땅업음
                    if (grid[cellPosition.x, cellPosition.y] == null)
                    {
                        //땅있음
                        Tilemap.SetTile(cellPosition, FindObjectOfType<GridController>().pen);
                        grid[cellPosition.x, cellPosition.y] = new SoilData();
                    }
                    //땅있음 씨앗씨기
                    else if (grid[cellPosition.x, cellPosition.y].HasPlant != true)
                    {
                       //씨앗심기
                        ResController.Instance.SeedPrefab
                            .Instantiate()
                            .Position(tileWorldPos);

                        grid[cellPosition.x, cellPosition.y].HasPlant = true;
                    }
                    else
                    {
                        Debug.Log("이미 심어져 있습니다.");
                    }
                }
                

            }

            if (Input.GetMouseButtonDown(1))
            {


                if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
                {
                    if (grid[cellPosition.x, cellPosition.y] != null)
                    {
                        Tilemap.SetTile(cellPosition, null);
                        grid[cellPosition.x, cellPosition.y] = null;
                    }
                }

            }
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
                {  //땅업음
                    if (grid[cellPosition.x, cellPosition.y] != null)
                    {
                        if (grid[cellPosition.x, cellPosition.y].Watered != true)
                        {
                            //물주기
                            ResController.Instance.WaterPrefab
                                .Instantiate()
                                .Position(tileWorldPos);

                            grid[cellPosition.x, cellPosition.y].Watered = true;
                        }

                    }
                }
                  
                
            }
        }
    }
}
