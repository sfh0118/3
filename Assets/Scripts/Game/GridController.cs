using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;


namespace projectlndieFem
{
    public partial class GridController : ViewController
    {
        private EasyGrid<SoilData> mShowGrid = new EasyGrid<SoilData>(5, 4);

        public EasyGrid<SoilData> ShowGrid => mShowGrid;

        public TileBase Pen;

        public TileBase PlantablePen;

        // public Tilemap Tilemap; // Added this field to reference the Tilemap component
        // Added this field to reference the Tilemap component  

        void Start()
        {


        
            //데이터  초기화
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var soilData = mShowGrid[i, j];
                    var isEmpty = PlayerPrefs.GetInt($"soil_{i}_{j}_is_empty", 1)== 1 ? true : false;
                    if(isEmpty)
                    {
                        mShowGrid[i, j] = null; 
                       
                    }
                   
                }
            }
            //            //Tilemap 컴포넌트 가져오기
            for (var i = 0; i < ShowGrid.Width; i++)
            {
                for (var j = 0; j < ShowGrid.Height; j++)
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
            //데이터 저장
            Global.Days.Register(day =>
            {
                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 4; j++)
                    {
                        var soilData = mShowGrid[i, j];
                        if (soilData == null)
                        {
                            PlayerPrefs.SetInt($"soil_{i}_{j}_is_empty", true ? 1 : 0);
                        }
                        else
                        {
                            PlayerPrefs.SetInt($"soil_{i}_{j}_is_empty", false ? 1 : 0);

                        }


                    }
                }

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
       
    }
}   
