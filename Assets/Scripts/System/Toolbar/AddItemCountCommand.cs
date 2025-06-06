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
            var slot = this.GetSystem<IToolBarSystem>().Slots.FirstOrDefault(slot => slot.ItemId == mItemName);

            if (slot == null)
            {
                slot = this.GetSystem<IToolBarSystem>().Slots.FirstOrDefault(slot => slot.Count == 0);
                slot.ItemId = mItemName;
                slot.Count = mAddCount;
                ToolBarSystem.OnAddItem.Trigger(slot);

                //Global.UIToolBar.AddItem(carrotItem);
            }
            else
            {
                slot.Count += mAddCount;
            }
            ToolBarSystem.OnItemCountChanged.Trigger(slot, slot.Count);
        }
    }
}
