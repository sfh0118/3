using System;
using UnityEngine;
using QFramework;
using static UnityEditor.Progress;


namespace projectlndieFem
{
    [System.Serializable]
    public class Item
    {
        public string Name;
        public string IconName;
        public  BindableProperty<int>  Count;

        public bool Countable = false;

        public ITool Tool;
        public bool IsPlant;
        public string PlantPrefabName;


        public Item Copy()

        {
            var item = new Item()
            {
                Name = Name,
                IconName = IconName,
                Count = new BindableProperty<int>(Count.Value),
                Countable = Countable,
                Tool = Tool,
                IsPlant = IsPlant,
                PlantPrefabName = PlantPrefabName
            };
            
            return item;
        }
        
    }
}
