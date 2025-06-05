using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;


namespace projectlndieFem
{
    public partial class GridController : ViewController,IController
    {
        private ISoilSystem mSoilSystem;

        public EasyGrid<SoilData> ShowGrid => mSoilSystem.SoilGrid;

        public TileBase Pen;

        public TileBase PlantablePen;

        // public Tilemap Tilemap; // Added this field to reference the Tilemap component
        // Added this field to reference the Tilemap component  

        
       
        void ParseData()
        {

            for (var i = 0; i < ShowGrid.Width; i++)
            {
                for (var j = 0; j < ShowGrid.Height; j++)
                {
                    Ground.SetTile(new Vector3Int(i, j), PlantablePen);
                }
            }

            mSoilSystem.SoilGrid.ForEach((x, y, data) =>
            {
                if (data != null)
                {
                    Soil.SetTile(new Vector3Int(x, y), Pen); // Fixed missing z-coordinate in Vector3Int  
                }

            });
        }
        
        void Awake()
        {
            mSoilSystem = this.GetSystem<ISoilSystem>();
        }

        void Start()
        {
            
            ParseData(); // 데이터 파싱

            
        }

        private void OnDestroy()
        {
            mSoilSystem = null;

        }
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }
}   
