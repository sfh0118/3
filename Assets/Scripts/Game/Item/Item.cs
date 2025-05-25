using System;
using UnityEngine;
using QFramework;

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



    }
}
