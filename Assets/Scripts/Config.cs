using QFramework;
using System.Collections.Generic;
using static UnityEditor.Progress;

namespace projectlndieFem
{
    public class Config
    {
        public const int INIT_COIN = 1000;
        public const int INIT_DAY = 1;
        public const int INIT_HOURS = 10;
        public static List<Item> Items => Global.Interface.GetSystem<IToolBarSystem>().Items;

        //public static Dictionary<string, Item> ItemForName = new Dictionary<string, Item>()
        //{
        //    { "hand", CreateHand() },
        //    { "shovel", CreateShovel() },
        //    { "seed", CreateSeed() },
        //    { "watering_can", CreateWateringCan() },
        //    { "seed_radish", CreateSeedRadish() },
        //    { "seed_chinese_cabbage", CreateSeedChineseCabbage() },
        //    { "seed_carrot", CreateSeedCarrot() },
        //    { "carrot", CreateCarrot() },
        //{"pumpkin",CreatePumpkin() },
        //{"potato", CreatePotato() },
        //{"tomato", CreateTomato() },
        //{"bean", CreateBean() },
        //};

        public static Item CreateItem(string itemName, int count = 1)
        {
            if (itemName == "hand")
            {
                return CreateHand();
            }
            else if (itemName == "shovel")
            {
                return CreateShovel();
            }
           
            else if (itemName == "watering_can")
            {
                return CreateWateringCan();
            }
            
            else if (itemName == "seed_potato")
            {
                return CreateSeedPotato(count);
            }
            else if (itemName == "seed_tomato")
            {
                return CreateSeedTomato(count);
            }
            else if (itemName == "seed_carrot")
            {
                return CreateSeedCarrot(count);
            }
            else if (itemName == "seed_bean")
            {
                return CreateSeedPumpkin(count);
            }
            else if (itemName == "seed_bpumpkin")
            {
                return CreateSeedBean(count);
            }
            else if (itemName == "carrot")
            {
                return CreateCarrot(count);
            }
            else if (itemName == "pumpkin")
            {
                return CreatePumpkin(count);
            }
            else if (itemName == "potato")
            {
                return CreatePotato(count);
            }
            else if (itemName == "tomato")
            {
                return CreateTomato(count);
            }
            else if (itemName == "bean")
            {
                return CreateBean(count);
            }
            return null;

        }
        public static Item CreateHand()
        {
            return new Item()
            {
                IconName = "ToolHand_0",
                Count = new BindableProperty<int>(1),
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
                Count = new BindableProperty<int>(1),
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
                Count = new BindableProperty<int>(1),
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
                Count = new BindableProperty<int>(count),
                Countable = true,
                IsPlant = true,
                Name = "seed_carrot",
                PlantPrefabName = "PlantCarrot",
                Tool = new ToolSeed()
            }
            .Self(item => item.Tool = new ToolSeed()
            {
                Item = item
            });
        }
        public static Item CreateSeedPumpkin(int count = 5)
        {
            return new Item()
            {
                IconName = "PumpkinSeedIcon",
                Count = new BindableProperty<int>(count),
                Countable = true,
                IsPlant = true,
                Name = "seed_pumpkin",
                PlantPrefabName = "PlantPumpkin",
                Tool = new ToolSeed()
            }
            .Self(item => item.Tool = new ToolSeed()
            {
                Item = item
            });
        }
        public static Item CreateSeedPotato(int count = 5)
        {
            return new Item()
            {
                IconName = "PotatoSeedIcon",
                Count = new BindableProperty<int>(count),
                Countable = true,
                IsPlant = true,
                Name = "seed_potato",
                PlantPrefabName = "PlantPotato",
                Tool = new ToolSeed()
            }
            .Self(item => item.Tool = new ToolSeed()
            {
                Item = item
            });
        }
        public static Item CreateSeedTomato(int count = 5)
        {
            return new Item()
            {
                IconName = "TomatoSeedIcon",
                Count = new BindableProperty<int>(count),
                Countable = true,
                IsPlant = true,
                Name = "seed_tomato",
                PlantPrefabName = "PlantTomato",
                Tool = new ToolSeed()
            }
            .Self(item => item.Tool = new ToolSeed()
            {
                Item = item
            });
        }
        public static Item CreateSeedBean(int count = 5)
        {
            return new Item()
            {
                IconName = "BeanSeedIcon",
                Count = new BindableProperty<int>(count),
                Countable = true,
                IsPlant = true,
                Name = "seed_bean",
                PlantPrefabName = "PlantBean",
                Tool = new ToolSeed()
            }
            .Self(item => item.Tool = new ToolSeed()
            {
                Item = item
            });
        }
        public static Item CreateCarrot(int count = 1)
        {
            return new Item()
            {
                IconName = "CarrotIcon",
                Count = new BindableProperty<int>(count),
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
                Count = new BindableProperty<int>(count),
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
                Count = new BindableProperty<int>(count),
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
                Count = new BindableProperty<int>(count),
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
                Count = new BindableProperty<int>(count),
                Countable = true,
                IsPlant = false,
                Name = "bean",
                PlantPrefabName = string.Empty,
                Tool = null
            };
        }
    }
}