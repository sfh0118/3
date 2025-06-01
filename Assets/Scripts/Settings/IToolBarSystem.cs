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
      
       


        // 게임 설정 및 아이템 목록을 정의하는 클래스
        public List<Item> Items { get; } = new List<Item>()
        {
            Config.CreateHand(),
            Config.CreateShovel(),
            Config.CreateSeed(),
            Config.CreateWateringCan(),
            Config.CreateSeedRadish(),
            Config.CreateSeedChineseCabbage(),
            Config.CreateSeedCarrot(),

        };
        public int MaxCount { get; } = 10;

        protected override void OnInit()
        {
            // Initialization logic if needed
        }
    }
}