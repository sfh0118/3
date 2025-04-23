using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
	public partial class GridController : ViewController
	{

        private EasyGrid<SoilData> mShowGrid = new EasyGrid <SoilData>(10, 10);

        public EasyGrid<SoilData> ShowGrid => mShowGrid;

        public TileBase pen;
        void Start()
		{
            mShowGrid[0,0] = new SoilData();
            mShowGrid[2,2] = new SoilData();

            //Tilemap.SetTile
            // Code Here
            mShowGrid.ForEach((x,y,data)=>
            {
                if (data != null)
                {
                    Tilemap.SetTile(new Vector3Int(x, y), pen);
                }
               
            });
        }

        private void Update()
        {
            var grid = FindObjectOfType<Grid>();
            mShowGrid.ForEach((x, y, _) =>
            {
                var tileWorldPos = grid.CellToWorld(new Vector3Int(x, y,0));
                var leftBottomPos = tileWorldPos;
                var leftTopPos = tileWorldPos + new Vector3(0, grid.cellSize.y, 0);
                var rightTopPos = tileWorldPos + new Vector3(grid.cellSize.x,grid.cellSize.y, 0);
                var rightBottomPos = tileWorldPos + new Vector3(grid.cellSize.x,0,0);

                Debug.DrawLine(leftBottomPos,leftTopPos, Color.red);
                Debug.DrawLine(leftTopPos,rightTopPos, Color.red);
                Debug.DrawLine(rightTopPos,rightBottomPos, Color.red);
                Debug.DrawLine(rightBottomPos,leftBottomPos, Color.red);
            });
    
        }
    }
}
