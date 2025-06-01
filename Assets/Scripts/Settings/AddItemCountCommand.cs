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
            var item = Config.Items.FirstOrDefault(item => item.Name == "Carrot");

            if (item == null)
            {

                item = Config.CreateItem(mItemName, mAddCount);
                Config.Items.Add(item);
                Object.FindObjectOfType<UIToolBar>().AddItem(item);

                //Global.UIToolBar.AddItem(carrotItem);
            }
            else
            {
                item.Count.Value += mAddCount;
            }
        }
	}
}
