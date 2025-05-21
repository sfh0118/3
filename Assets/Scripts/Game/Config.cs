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
                Count = 1,
                Countable = false,
                IsPlant = false,
                Name = "손",
                PlantPrefabName = string.Empty,
                Tool = Constant.ToolHand
            },
            new Item()
            {
                IconName = "ToolShovel_0",
                Count = 1,
                Countable = false,
                IsPlant = false,
                Name = "삽",
                PlantPrefabName = string.Empty,
                Tool = Constant.ToolShovel

            },
            new Item()
            {
                IconName = "ToolSeed_0",
                Count = 1,
                Countable = true,
                IsPlant = true,
                Name = "씨앗",
                PlantPrefabName = "Plant",
                Tool = Constant.ToolSeed
            },
            new Item()
            {
                IconName = "ToolWateringCan_0",
                Count = 1,
                Countable = false,
                IsPlant = false,
                Name = "물뿌리개",
                PlantPrefabName = string.Empty,
                Tool = Constant.ToolWateringCan
            },
            new Item()
            {
                IconName = "ToolSeedRadish_0",
                Count = 1,
                Countable = true,
                IsPlant = true,
                Name = "무 씨앗",
                PlantPrefabName = "PlantRadish",
                Tool = Constant.ToolSeedRadish
            },
            new Item()
            {
                IconName = "ToolSeedChineseCabbage_0",
                Count = 1,
                Countable = true,
                IsPlant = true,
                Name = "배추 씨앗",
                PlantPrefabName = "PlantChineseCabbage",
                Tool = Constant.ToolSeedChineseCabbage
            },
        };
        
    }
}