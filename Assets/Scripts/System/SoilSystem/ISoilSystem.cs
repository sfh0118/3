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
                        var hasPlant = PlayerPrefs.GetInt($"soil_{i}_{j}_has_plant", 1) == 1 ? true : false;
                        SoilGrid[i, j] = new SoilData();
                        SoilGrid[i, j].HasPlant = hasPlant;

                        if (hasPlant)
                        {
                            var plantName = PlayerPrefs.GetString($"soil_{i}_{j}_plant_name", string.Empty);
                            var plantState = (PlantStates)PlayerPrefs.GetInt($"soil_{i}_{j}_plant_state", (int)PlantStates.Seed);
                            SoilGrid[i, j].PlantName = plantName;
                            SoilGrid[i, j].PlantState = plantState;
                        }
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
                        PlayerPrefs.SetInt($"soil_{i}_{j}_has_plant", false ? 1 : 0);
                    }
                    else
                    {
                        PlayerPrefs.SetInt($"soil_{i}_{j}_is_empty", false ? 1 : 0);
                        PlayerPrefs.SetInt($"soil_{i}_{j}_has_plant",soilData.HasPlant ? 1 : 0);

                        if (soilData.HasPlant)
                        {
                            PlayerPrefs.SetString($"soil_{i}_{j}_plant_name", soilData.PlantName);
                            PlayerPrefs.SetInt($"soil_{i}_{j}_plant_state", (int)soilData.PlantState);

                        }
                    }


                }
            }
        }
    }
}