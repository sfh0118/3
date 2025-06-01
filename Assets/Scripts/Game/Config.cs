using QFramework;
using System.Collections.Generic;

namespace projectlndieFem
{
    public class Config
    {
        public static List<Item> Items = new List<Item>()
        {
            new Item()
            {

                IconName = "ToolHand_0",
                Count = new BindableProperty<int>(1),
                Countable = false,
                IsPlant = false,
                Name = "Hand",
                PlantPrefabName = string.Empty,
                Tool = new ToolHand()
            },
            new Item()
            {
                IconName = "ToolShovel_0",
                Count = new BindableProperty<int>(1),
                Countable = false,
                IsPlant = false,
                Name = "Shovel",
                PlantPrefabName = string.Empty,
                Tool = new ToolShovel()

            },

                new Item()
                {
                    IconName = "ToolSeed_0",
                    Count = new BindableProperty<int>(5),
                    Countable = true,
                    IsPlant = true,
                    Name = "seed",
                    PlantPrefabName = "Plant",

                }
                .Self(item =>item.Tool = new ToolSeed()
                {
                   Item = item
                }),
            new Item()
            {
                IconName = "ToolWateringCan_0",
                Count = new BindableProperty<int>(1),
                Countable = false,
                IsPlant = false,
                Name = "watering_can",
                PlantPrefabName = string.Empty,
                Tool = new ToolWateringCan()
            },
            new Item()
            {
                IconName = "ToolSeedRadish_0",
                Count = new BindableProperty<int>(5),
                Countable = true,
                IsPlant = true,
                Name = "seed_radish",
                PlantPrefabName = "PlantRadish",

            }
            .Self(item =>item.Tool = new ToolSeed()
            {
                   Item = item
            }),
            new Item()
            {
                IconName = "ToolSeedChineseCabbage_0",
                Count = new BindableProperty<int>(5),
                Countable = true,
                IsPlant = true,
                Name = "seed_chinese_cabbage",
                PlantPrefabName = "PlantChineseCabbage",

            }
            .Self(item =>item.Tool = new ToolSeed()
            {
                   Item = item
            }),
            new Item()
            {
                IconName = "CarrotSeedIcon",
                Count = new BindableProperty<int>(5),
                Countable = true,
                IsPlant = true,
                Name = "seed_carrot",
                PlantPrefabName = "PlantCarrot",

            }
            .Self(item =>item.Tool = new ToolSeed()
            {
                   Item = item
            }),
        };
        
    }
}