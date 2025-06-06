using QFramework;
using System.Collections.Generic;
using UnityEngine.XR;
using static UnityEditor.Progress;

namespace projectlndieFem
{
    public class Config
    {
        public const int INIT_COIN = 1000;
        public const int INIT_DAY = 1;
        public const int INIT_HOURS = 10;
        public const int INIT_SOIL_GRID_WIDTH = 5;
        public const int INIT_SOIL_GRID_HEIGHT = 4;



        public static Dictionary<string, Item> ItemForName = new Dictionary<string, Item>()
        {
            {"hand", CreateHand()},
            {"shovel", CreateShovel()},
            {"watering_can",CreateWateringCan()},
            {"seed_potato", CreateSeedPotato()},
            { "seed_tomato", CreateSeedTomato()},
            {"seed_carrot", CreateSeedCarrot()},
            {"seed_pumpkin", CreateSeedPumpkin()},
            {"seed_bean", CreateSeedBean()},
            {"carrot", CreateCarrot()},
            {"pumpkin", CreatePumpkin()},
            {"potato", CreatePotato()},
            {"tomato", CreateTomato()},
            {"bean", CreateBean()},

        };
        public static Item CreateHand()
        {
            return new Item()
            {
                IconName = "ToolHand_0",
                Countable = false,
                IsPlant = false,
                Name = "hand",
                PlantPrefabName = string.Empty,
                Tool = new ToolHand()
            };
        }
        public static Item CreateShovel()
        {
            return new Item()
            {
                IconName = "ToolShovel_0",
                Countable = false,
                IsPlant = false,
                Name = "shovel",
                PlantPrefabName = string.Empty,
                Tool = new ToolShovel()
            };

        }
       
        public static Item CreateWateringCan()
        {

            return new Item()
            {
                IconName = "ToolWateringCan_0",
                Countable = false,
                IsPlant = false,
                Name = "watering_can",
                PlantPrefabName = string.Empty,
                Tool = new ToolWateringCan()
            };
        }
        
        
        public static Item CreateSeedCarrot(int count = 5)
        {
            return new Item()
            {
                IconName = "CarrotSeedIcon",
                Countable = true,
                IsPlant = true,
                Name = "seed_carrot",
                PlantPrefabName = "PlantCarrot",
                Tool = new ToolSeed()
            };
        }
        public static Item CreateSeedPumpkin(int count = 5)
        {
            return new Item()
            {
                IconName = "PumpkinSeedIcon",
                Countable = true,
                IsPlant = true,
                Name = "seed_pumpkin",
                PlantPrefabName = "PlantPumpkin",
                Tool = new ToolSeed()
            };
        }
        public static Item CreateSeedPotato(int count = 5)
        {
            return new Item()
            {
                IconName = "PotatoSeedIcon",
                Countable = true,
                IsPlant = true,
                Name = "seed_potato",
                PlantPrefabName = "PlantPotato",
                Tool = new ToolSeed()
            };
        }
        public static Item CreateSeedTomato(int count = 5)
        {
            return new Item()
            {
                IconName = "TomatoSeedIcon",
                Countable = true,
                IsPlant = true,
                Name = "seed_tomato",
                PlantPrefabName = "PlantTomato",
                Tool = new ToolSeed()
            };
        }
        public static Item CreateSeedBean(int count = 5)
        {
            return new Item()
            {
                IconName = "BeanSeedIcon",
                Countable = true,
                IsPlant = true,
                Name = "seed_bean",
                PlantPrefabName = "PlantBean",
                Tool = new ToolSeed()
            };
        }
        public static Item CreateCarrot(int count = 1)
        {
            return new Item()
            {
                IconName = "CarrotIcon",
                Countable = true,
                IsPlant = false,
                Name = "carrot",
                PlantPrefabName = string.Empty,
                Tool = null
            };

        }
        public static Item CreatePumpkin(int count = 1)
        {
            return new Item()
            {
                IconName = "PumpkinIcon",
                Countable = true,
                IsPlant = false,
                Name = "pumpkin",
                PlantPrefabName = string.Empty,
                Tool = null
            };
        }
        public static Item CreatePotato(int count = 1)
        {
            return new Item()
            {
                IconName = "PotatoIcon",
                Countable = true,
                IsPlant = false,
                Name = "potato",
                PlantPrefabName = string.Empty,
                Tool = null
            };
        }
        public static Item CreateTomato(int count = 1)
        {
            return new Item()
            {
                IconName = "TomatoIcon",
                Countable = true,
                IsPlant = false,
                Name = "tomato",
                PlantPrefabName = string.Empty,
                Tool = null
            };
        }
        public static Item CreateBean(int count = 1)
        {
            return new Item()
            {
                IconName = "BeanIcon",
                Countable = true,
                IsPlant = false,
                Name = "bean",
                PlantPrefabName = string.Empty,
                Tool = null
            };
        }
    }
}