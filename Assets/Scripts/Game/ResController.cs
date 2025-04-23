using UnityEngine;
using QFramework;

namespace projectlndieFem
{
    public partial class ResController : ViewController, ISingleton // Added ISingleton interface  
    {
        public GameObject SeedPrefab;

        public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        void Start()
        {
            // Code Here  
        }

        // Implement ISingleton interface  
        public void OnSingletonInit()
        {
            // Initialization logic if needed  
        }
    }
}
