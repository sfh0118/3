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
        public EasyGrid<SoilData> SoilGrid { get; } = new EasyGrid<SoilData>(Config.INIT_SOIL_GRID_WIDTH, Config.INIT_SOIL_GRID_HEIGHT);
        public void ResetData()
        {

            for (var i = 0; i < SoilGrid.Width; i++)
            {
                for (var j = 0; j < SoilGrid.Height; j++)
                {

                    PlayerPrefs.SetInt($"soil_{i}_{j}_is_empty", true ? 1 : 0);
                    PlayerPrefs.SetInt($"soil_{i}_{j}_has_plant", false ? 1 : 0);
                    PlayerPrefs.SetString($"soil_{i}_{j}_plant_name", string.Empty);
                    PlayerPrefs.SetInt($"soil_{i}_{j}_plant_state", 0);
                    PlayerPrefs.SetInt($"soil_{i}_{j}_days_in_current_state", 0);

                    SoilGrid[i, j] = null;

                }
            }
            SoilGrid.Resize(Config.INIT_SOIL_GRID_WIDTH, Config.INIT_SOIL_GRID_HEIGHT, (x, y) => null);

            PlayerPrefs.SetInt($"soil_grid_width", Config.INIT_SOIL_GRID_WIDTH);
            PlayerPrefs.SetInt($"soil_grid_height", Config.INIT_SOIL_GRID_HEIGHT);
        }
        public void LoadData()
        {
            var width = PlayerPrefs.GetInt($"soil_grid_width", Config.INIT_SOIL_GRID_WIDTH);
            var height = PlayerPrefs.GetInt($"soil_grid_height", Config.INIT_SOIL_GRID_HEIGHT);
            SoilGrid.Resize(width, height, (x, y) => null);

            for (var i = 0; i < SoilGrid.Width; i++)
            {
                for (var j = 0; j < SoilGrid.Height; j++)
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
                            var daysInCurrentState = PlayerPrefs.GetInt($"soil_{i}_{j}_days_in_current_state", 0);
                            SoilGrid[i, j].PlantName = plantName;
                            SoilGrid[i, j].PlantState = plantState;
                            SoilGrid[i, j].DaysInCurrentState = daysInCurrentState;
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
            PlayerPrefs.SetInt($"soil_grid_width", SoilGrid.Width);
            PlayerPrefs.SetInt($"soil_grid_height", SoilGrid.Height);
            for (var i = 0; i < SoilGrid.Width; i++)
            {
                for (var j = 0; j < SoilGrid.Height; j++)
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
                            PlayerPrefs.SetInt($"soil_{i}_{j}_days_in_current_state",soilData.DaysInCurrentState);

                        }
                    }


                }
            }
        }
    }
}