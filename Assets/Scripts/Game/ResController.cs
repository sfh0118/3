using UnityEngine;
using QFramework;

namespace ProjectlndieFarm
{
    public partial class ResController : ViewController, ISingleton // Added ISingleton interface  
    {
        public GameObject WaterPrefab;
        public GameObject PlantPrefab; // Added PlantPrefab field

        public Sprite SeedSprite;
        public Sprite SmallplantSprite;
        public Sprite RipeSprite;
        public Sprite OldSprite;
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
