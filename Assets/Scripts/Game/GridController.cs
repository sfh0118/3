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
                else
                {
                    Tilemap.SetTile(new Vector3Int(x, y), null);
                }
            });
        }
	}
}
