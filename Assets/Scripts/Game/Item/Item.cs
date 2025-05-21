using UnityEngine;

namespace projectlndieFem
{
    [System.Serializable]
    public class Item
    {
        public string Name;
        public string IconName;
        public int Count;

        public bool Countable = false;

        public ITool Tool;
        public bool IsPlant;
        public string PlantPrefabName;


    }
}
