using UnityEngine;
using QFramework;
using projectlndieFem;
using ProjectlndieFarm;
namespace ProjectlndieFarm
{ 
    public enum PlantStates
    {
        Seed,
        Small,
        Ripe,
        Old,
    }
    public partial class plantController : ViewController, ISingleton
	{
		public static plantController Instance => MonoSingletonProperty<plantController>.Instance;

        public EasyGrid<Plant> plants = new EasyGrid<Plant>(10, 10);

        public void OnSingletonInit()
        {
           
        }
    }
}
