using QFramework;

namespace projectlndieFem
{
    
    public class ToolbarSlot
    {
        public ToolbarSlot() { }
        public ToolbarSlot(string itemId , int count)
        {
            ItemId = itemId;
            Count.Value = count;
        }
        public string ItemId;
        public BindableProperty<int> Count = new BindableProperty<int>(0);
    }
}