namespace projectlndieFem
{
    
    public class ToolbarSlot
    {
        public ToolbarSlot() { }
        public ToolbarSlot(string itemId , int count)
        {
            ItemId = itemId;
            Count = count;
        }
        public string ItemId;
        public int Count;
    }
}