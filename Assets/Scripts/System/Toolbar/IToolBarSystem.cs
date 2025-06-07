using QFramework;
using System.Collections.Generic;
using UnityEngine;

namespace projectlndieFem
{
    public interface IToolBarSystem : ISystem
    {

        List<ToolbarSlot> Slots { get; }

        void LoadData();
        void SaveData();
        void ResetData();


    }

    public class ToolBarSystem : AbstractSystem, IToolBarSystem
    {
      
        public static EasyEvent<ToolbarSlot, int> OnItemCountChanged = new EasyEvent<ToolbarSlot, int>();



        public List<ToolbarSlot> Slots { get; } = new List<ToolbarSlot>()
        {
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),


        };

        private readonly
            List<ToolbarSlot> mInitSlotsConfig = new List<ToolbarSlot>()
        {

            new ToolbarSlot("hand", 1),
            new ToolbarSlot("shovel", 1),
            new ToolbarSlot("watering_can", 1),
            new ToolbarSlot("seed_pumpkin", 5),
            new ToolbarSlot("seed_potato", 5),
            new ToolbarSlot("seed_tomato", 5),
            new ToolbarSlot("seed_bean", 5),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),

        };

        public void LoadData()
        {
            for (var i = 0; i < Slots.Count; i++)
            {
                Slots[i].ItemId = PlayerPrefs.GetString($"toolbar_slot_{i}_item_id", mInitSlotsConfig[i].ItemId);
                Slots[i].Count.Value = PlayerPrefs.GetInt($"toolbar_slot_{i}_count", mInitSlotsConfig[i].Count.Value);
            }
        }

        public void SaveData()
        {
            for (var i=0; i<Slots.Count; i++)
            {
                PlayerPrefs.SetString($"toolbar_slot_{i}_item_id", Slots[i].ItemId);
                PlayerPrefs.SetInt($"toolbar_slot_{i}_count", Slots[i].Count.Value);
            }
        
            
        }

        public void ResetData()
        {
            for (var i = 0; i < Slots.Count; i++)
            {
                var toolbarSlot = Slots[i];
                toolbarSlot.ItemId = mInitSlotsConfig[i].ItemId;
                toolbarSlot.Count.Value = mInitSlotsConfig[i].Count.Value;
            }
            SaveData();
        }
        protected override void OnInit()
        {
            // Initialization logic if needed
        }

        
    }
}