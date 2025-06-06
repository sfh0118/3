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
            var item = Config.Items.FirstOrDefault(item => item.Name == mItemName);

            if (item == null)
            {

                item = Config.CreateItem(mItemName, mAddCount);
                Config.Items.Add(item);
                ToolBarSystem.OnAddItem.Trigger(item);

                //Global.UIToolBar.AddItem(carrotItem);
            }
            else
            {
                item.Count.Value += mAddCount;
            }
            ToolBarSystem.OnItemCountChanged.Trigger(item, item.Count.Value);
        }
    }
}
