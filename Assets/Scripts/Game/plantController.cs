using UnityEngine;
using QFramework;

namespace projectlndieFem
{
    public enum PlantStates
    {
        Seed,
        Small,
        Middle,
        Big,
        Ripe,
        Old,
    }
   
       
    public partial class PlantController : ViewController,ISingleton
    {
        public static PlantController Instance => MonoSingletonProperty<PlantController>.Instance;

        public EasyGrid<IPlant> Plants = new EasyGrid<IPlant>(Config.INIT_SOIL_GRID_WIDTH, Config.INIT_SOIL_GRID_HEIGHT);

        public void OnSingletonInit()
        {

        }
    }
}
