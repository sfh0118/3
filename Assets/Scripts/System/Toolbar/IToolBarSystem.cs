using QFramework;
using System.Collections.Generic;

namespace projectlndieFem
{
    public interface IToolBarSystem : ISystem
    {

        List<ToolbarSlot> Slots { get; }

    }

    public class ToolBarSystem : AbstractSystem, IToolBarSystem
    {
      
        public static EasyEvent<ToolbarSlot, int> OnItemCountChanged = new EasyEvent<ToolbarSlot, int>();


        // 게임 설정 및 아이템 목록을 정의하는 클래스

        List<ToolbarSlot> IToolBarSystem.Slots => Slots;


        public List<ToolbarSlot> Slots = new List<ToolbarSlot>()
        {
            new ToolbarSlot("hand", 1),
            new ToolbarSlot("shovel", 1),
            new ToolbarSlot("watering_can", 1),
            new ToolbarSlot("seed_pumpkin", 5),
            new ToolbarSlot("seed_potato", 5),
            new ToolbarSlot("seed_tomato", 5),
            new ToolbarSlot("seed_bean", 5),
            new ToolbarSlot(),
            new ToolbarSlot(),
            new ToolbarSlot(),
        };

        protected override void OnInit()
        {
            // Initialization logic if needed
        }
    }
}