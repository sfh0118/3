using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;


namespace projectlndieFem
{
    public partial class GridController : ViewController
    {
        private EasyGrid<SoilData> mShowGrid = new EasyGrid<SoilData>(10, 10);

        public EasyGrid<SoilData> ShowGrid => mShowGrid;

      

        public TileBase Pen;

        public TileBase PlantablePen;
       
        // public Tilemap Tilemap; // Added this field to reference the Tilemap component
        // Added this field to reference the Tilemap component  

        void Start()
        {
            mShowGrid[0, 0] = new SoilData();
            mShowGrid[2, 2] = new SoilData();


            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    Ground.SetTile(new Vector3Int(i, j), PlantablePen);
                }
            }

            mShowGrid.ForEach((x, y, data) =>
            {
                if (data != null)
                {
                    Soil.SetTile(new Vector3Int(x, y), Pen); // Fixed missing z-coordinate in Vector3Int  
                }
               
            });
        }
        private void Update()
        {
            var grid = FindObjectOfType<Grid>();

            mShowGrid.ForEach((x, y, _) =>
            {
                var tileWorldPos = grid.CellToWorld(new Vector3Int(x, y, 0));
                var leftBottomPos = tileWorldPos;
                var leftTopPos = tileWorldPos + new Vector3(0, grid.cellSize.y, 0);
                var rightToPos = tileWorldPos + new Vector3(grid.cellSize.x, grid.cellSize.y, 0);
                var rightBottomPos = tileWorldPos + new Vector3(grid.cellSize.x, 0, 0);

                Debug.DrawLine(leftBottomPos, leftTopPos, Color.red);
                Debug.DrawLine(leftTopPos, rightToPos, Color.red);
                Debug.DrawLine(rightToPos, rightBottomPos, Color.red);
                Debug.DrawLine(rightBottomPos, leftBottomPos, Color.red);

            });

        }
    }
}   
