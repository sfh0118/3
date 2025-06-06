using QFramework;
using System.Linq;
using UnityEngine;

namespace projectlndieFem
{
    public class SubItemCountCommand : AbstractCommand
    {
        private readonly string mItemName;
        private readonly int mSubCount;
        public SubItemCountCommand(string itemName, int subCount)
        {
            mItemName = itemName;
            mSubCount = subCount;
        }
        protected override void OnExecute()
        {
            var toolBarSystem = this.GetSystem<IToolBarSystem>();
            var slot = toolBarSystem.Slots.FirstOrDefault(slot => slot.ItemId == mItemName);

            if (slot != null)
            {

                slot.Count -= mSubCount;
                if (slot.Count == 0)
                {
                    ToolBarSystem.OnRemoveItem.Trigger(slot);
                }
                ToolBarSystem.OnItemCountChanged.Trigger(slot, slot.Count);
            }

        }
    }
}