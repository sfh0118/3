using QFramework;
using UnityEngine;

namespace projectlndieFem
{
    public interface ISoilSystem : ISystem
    {
        EasyGrid<SoilData> SoilGrid { get; }

        void ResetData();
        void LoadData();
        void SaveData();

    }
    public class SoilSystem : AbstractSystem, ISoilSystem
    {
        protected override void OnInit()
        {
            // Initialization logic for the soil system
        }
        public EasyGrid<SoilData> SoilGrid { get; } = new EasyGrid<SoilData>(5, 4);
        public void ResetData()
        {
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 4; j++)
                {

                    PlayerPrefs.SetInt($"soil_{i}_{j}_is_empty", false ? 1 : 0);


                }
            }
        }
        public void LoadData()
        {
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var isEmpty = PlayerPrefs.GetInt($"soil_{i}_{j}_is_empty", 1) == 1 ? true : false;
                    if (!isEmpty)
                    {
                        SoilGrid[i, j] = new SoilData();

                    }
                    else
                    {
                        SoilGrid[i, j] = null;
                    }

                }
            }
        }
        public void SaveData()
        {
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var soilData = SoilGrid[i, j];
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
        }
    }
}