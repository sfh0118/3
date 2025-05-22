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
                Name = "손",
                PlantPrefabName = string.Empty,
                Tool = new ToolHand()
            },
            new Item()
            {
                IconName = "ToolShovel_0",
                Count = new BindableProperty<int>(1),
                Countable = false,
                IsPlant = false,
                Name = "삽",
                PlantPrefabName = string.Empty,
                Tool = new ToolShovel()

            },
            new Item()
                {
                    IconName = "ToolSeed_0",
                    Count = new BindableProperty<int>(5),
                    Countable = true,
                    IsPlant = true,
                    Name = "씨앗",
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
                Name = "물뿌리개",
                PlantPrefabName = string.Empty,
                Tool = new ToolWateringCan()
            },
            new Item()
            {
                IconName = "ToolSeedRadish_0",
                Count = new BindableProperty<int>(5),
                Countable = true,
                IsPlant = true,
                Name = "무 씨앗",
                PlantPrefabName = "PlantRadish",
                
            }.Self(item =>item.Tool = new ToolSeed()
            {
                   Item = item
            }),
            new Item()
            {
                IconName = "ToolSeedChineseCabbage_0",
                Count = new BindableProperty<int>(5),
                Countable = true,
                IsPlant = true,
                Name = "배추 씨앗",
                PlantPrefabName = "PlantChineseCabbage",
                
            }.Self(item =>item.Tool = new ToolSeed()
            {
                   Item = item
            }),
        };
        
    }
}