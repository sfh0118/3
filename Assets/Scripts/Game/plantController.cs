using UnityEngine;
using QFramework;
using projectlndieFem;

namespace projectlndieFem
{ 
    public enum PlantStates
    {
        Seed,
        Small,
        Ripe,
        Old,
    }
    public partial class PlantController : ViewController, ISingleton
	{
		public static PlantController Instance => MonoSingletonProperty<PlantController>.Instance;

        public EasyGrid<Plant> plants = new EasyGrid<Plant>(10, 10);

        public void OnSingletonInit()
        {
           
        }
    }
}
