using QFramework;
using System.Collections.Generic;

namespace projectlndieFem
{
    public interface IToolBarSystem : ISystem
    {
        List<Item> Items { get; }
        int MaxCount { get; }

    }
    public class ToolBarSystem : AbstractSystem, IToolBarSystem
    {
      
        public static EasyEvent<Item> OnAddItem = new EasyEvent<Item>();
        public static EasyEvent<Item> OnRemoveItem = new EasyEvent<Item>();
        public static EasyEvent<Item,int> OnItemCountChanged = new EasyEvent<Item, int>();


        // 게임 설정 및 아이템 목록을 정의하는 클래스
        public List<Item> Items { get; } = new List<Item>()
        {
            Config.CreateHand(),
            Config.CreateShovel(),
            Config.CreateWateringCan(),
            Config.CreateSeedPumpkin(),
            Config.CreateSeedPotato(),
            Config.CreateSeedTomato(),
            Config.CreateSeedBean(),


        };
        public int MaxCount { get; } = 10;

        protected override void OnInit()
        {
            // Initialization logic if needed
        }
    }
}