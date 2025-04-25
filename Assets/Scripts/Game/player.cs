using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Globalization;

namespace projectlndieFem
{
	public partial class player : ViewController
	{
        public Grid Grid;
        public Tilemap Tilemap;
        void Start()
		{
            Debug.Log("@@@@@");
            Global.Days.Register( day =>
            {
                var soilDatas = FindObjectOfType<GridController>().ShowGrid;

                plantController.Instance.plants.ForEach((x,y,plant) =>
                {
                    if (plant )
                    {
                        if (plant.State == PlantStates.Seed)
                        {
                            if(soilDatas[x,y].Watered)
                            {
                                //plant에서 SmallPlant변환
                                plant.SetState(PlantStates.Small);
                            }
                        }
                        else if (plant.State == PlantStates.Small)
                        {
                            if (soilDatas[x,y].Watered)
                            {
                                plant.SetState(PlantStates.Ripe);
                            }
                        }
                        
                    }
                });

                soilDatas.ForEach(soilData =>
                {
                    if (soilData != null)
                    {
                        soilData.Watered = false;
                    }
                });
                foreach (var water in SceneManager.GetActiveScene().GetRootGameObjects()
                .Where(gameObj => gameObj
                .name.StartsWith("water")))
                {
                    water.DestroySelf();
                }




            }).UnRegisterWhenGameObjectDestroyed(gameObject);

		}


        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(600, 300);
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("날수 :"+ Global.Days.Value);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("열매 :" + Global.FruitCount.Value);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("물:E");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("다음날:F " );
            GUILayout.EndHorizontal();
        }



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Global.Days.Value++;
            }
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
                        var plantGameObj = ResController.Instance.PlantPrefab
                            .Instantiate()
                            .Position(tileWorldPos);


                        var plant = plantGameObj.GetComponent<Plant>();

                        plant.XCell = cellPosition.x;
                        plant.YCell = cellPosition.y;

                        plantController.Instance.plants[cellPosition.x, cellPosition.y] = plant;

                        grid[cellPosition.x, cellPosition.y].HasPlant = true;
                    }
                    else if (grid[cellPosition.x, cellPosition.y].HasPlant)
                    {
                        if (grid[cellPosition.x, cellPosition.y].PlantState == PlantStates.Ripe)
                        {
                            Destroy(plantController.Instance.plants[cellPosition.x, cellPosition.y].gameObject);
                            grid[cellPosition.x, cellPosition.y].HasPlant = false;
                            Global.FruitCount.Value++;
                        }
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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("GamePass");
            }
        }
    }
}
