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
            var Item = toolBarSystem.Items.FirstOrDefault(Item => Item.Name == mItemName);

            if (Item != null)
            {

                Item.Count.Value -= mSubCount;
                if (Item.Count.Value == 0)
                {
                    toolBarSystem.Items.Remove(Item);
                    ToolBarSystem.OnRemoveItem.Trigger(Item);
                    Object. FindObjectOfType<UIToolBar>().RemoveItem(Item);
                }
            }

        }
    }
}