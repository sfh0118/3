using UnityEngine;
using QFramework;
using projectlndieFem;
using System.Collections.Generic;
using System.Linq;
using System;
namespace projectlndieFem
{
    public partial class ResController : ViewController, ISingleton // Added ISingleton interface  
    {
        public GameObject WaterPrefab;

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

        public List<Sprite> Sprites = new List<Sprite>();

        public Sprite LoadSprite(string spriteName)
        {
            return Sprites.Single(spr => spr.name == spriteName);
        }

        public List<GameObject> Prefabs = new List<GameObject>();

        public GameObject LoadPrefab(string prefabName)
        {
            return Prefabs.Single(prefab => prefab.name == prefabName);
        }
        public static ResController Instance => MonoSingletonProperty<ResController>.Instance;

        
        // Implement ISingleton interface  
        public void OnSingletonInit()
        {
            // Initialization logic if needed  
        }
    }
}
