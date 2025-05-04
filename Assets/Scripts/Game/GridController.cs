using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;


namespace projectlndieFem
{
    public partial class GridController : ViewController
    {
        private EasyGrid<SoilData> mShowGrid = new EasyGrid<SoilData>(10, 10);

        public EasyGrid<SoilData> ShowGrid => mShowGrid;

        public TileBase pen;
       // public Tilemap Tilemap; // Added this field to reference the Tilemap component
                                // Added this field to reference the Tilemap component  

        void Start()
        {
            mShowGrid[0, 0] = new SoilData();
            mShowGrid[2, 2] = new SoilData();

            mShowGrid.ForEach((x, y, data) =>
            {
                if (data != null)
                {
                    Tilemap.SetTile(new Vector3Int(x, y, 0), pen); // Fixed missing z-coordinate in Vector3Int  
                }
                else
                {
                    Tilemap.SetTile(new Vector3Int(x, y, 0), null); // Fixed missing z-coordinate in Vector3Int  
                }
            });
        }
    }
}   
