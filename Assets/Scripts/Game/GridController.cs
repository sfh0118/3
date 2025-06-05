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
            var tileGrid = Soil.layoutGrid;
            mSoilSystem.SoilGrid.ForEach((x, y, data) =>
            {
                if (data != null)
                {
                    Soil.SetTile(new Vector3Int(x, y), Pen);

                    if(data.HasPlant)
                    {
                        var plantSeedName = "seed_" + data.PlantName;
                        var plantItemConfig = Config.ItemForName[plantSeedName];
                        var plantPrefab = ResController.Instance.LoadPrefab(plantItemConfig.PlantPrefabName);
                        PlantController.Instance.Plants[x,y] = plantPrefab.Instantiate()
                            .Position(tileGrid.CellToWorld(new Vector3Int(x, y)) + 0.5f * tileGrid.cellSize)
                            .GetComponent<IPlant>();

                        PlantController.Instance.Plants[x, y].SetState(data.PlantState);
                    }
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
