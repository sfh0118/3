using UnityEngine;
using QFramework;
using projectlndieFem;
namespace projectlndieFem
{
    public partial class ResController : ViewController, ISingleton // Added ISingleton interface  
    {
        public GameObject WaterPrefab;
        public GameObject PlantPrefab; // Added PlantPrefab field
        public GameObject PlantRadishPrefab; 
        public GameObject PlantChineseCabbagePrefab;

        public Sprite SeedSprite;
        public Sprite SmallPlantSprite;
        public Sprite RipeSprite;
        public Sprite OldSprite;
        public Sprite SeedRadishSprite;
        public Sprite SmallPlantRadishSprite;
        public Sprite RipeRadishSprite;

        public Sprite SeedChineseCabbageSprite;
        public Sprite SmallPlantChineseCabbageSprite;
        public Sprite RipeChineseCabbageSprite;
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
