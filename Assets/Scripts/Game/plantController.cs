using UnityEngine;
using QFramework;

namespace projectlndieFem
{
    public enum PlantStates
    {
        Seed,
        Small,
        Ripe,
        Old,
    }
   
       
    public partial class PlantController : ViewController,ISingleton
    {
        public static PlantController Instance => MonoSingletonProperty<PlantController>.Instance;

        public EasyGrid<IPlant> Plants = new EasyGrid<IPlant>(5, 4);

        public void OnSingletonInit()
        {

        }
    }
}
