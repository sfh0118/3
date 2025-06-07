using QFramework;
using System.Linq;
using UnityEngine;

namespace projectlndieFem
{
    public class AddItemCountCommand : AbstractCommand
    {
        private readonly string mItemName;
        private readonly int mAddCount;

        public AddItemCountCommand(string itemName, int addCount)
        {
            mItemName = itemName;
            mAddCount = addCount;
        }
        protected override void OnExecute()
        {
            var toolbarSystem = this.GetSystem<IToolBarSystem>();
            var slot = toolbarSystem.Slots.FirstOrDefault(slot => slot.ItemId == mItemName);

            if (slot == null)
            {
                slot = toolbarSystem.Slots.FirstOrDefault(slot => slot.Count.Value == 0);

                if (slot == null)
                {
                    Debug.LogWarning($"[AddItemCountCommand] No empty slot available for {mItemName}");
                    return;
                }

                Debug.Log($"[AddItemCountCommand] Empty slot found, adding {mItemName}");
                slot.ItemId = mItemName;
                slot.Count.Value = mAddCount;
            }
            else
            {
                Debug.Log($"[AddItemCountCommand] Existing slot found, adding {mAddCount} to {mItemName}");
                slot.Count.Value += mAddCount;
            }

            ToolBarSystem.OnItemCountChanged.Trigger(slot, slot.Count.Value);
        }

        //protected override void OnExecute()
        //{
        //    var slot = this.GetSystem<IToolBarSystem>().Slots.FirstOrDefault(slot => slot.ItemId == mItemName);

        //    if (slot == null)
        //    {
        //        slot = this.GetSystem<IToolBarSystem>().Slots.FirstOrDefault(slot => slot.Count.Value == 0);


        //        slot.ItemId = mItemName;
        //        slot.Count.Value = mAddCount;

        //        //Global.UIToolBar.AddItem(carrotItem);
        //    }
        //    else
        //    {
        //        slot.Count.Value += mAddCount;
        //    }
        //    ToolBarSystem.OnItemCountChanged.Trigger(slot, slot.Count.Value);
        //}
    }
}
