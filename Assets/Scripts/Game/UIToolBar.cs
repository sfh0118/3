using UnityEngine;
using QFramework;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

namespace projectlndieFem
{

    public partial class UIToolBar : ViewController, IController
    {
        public List<UISlot> ToolbarSlots { get; } = new List<UISlot>();



        void Start()
        {
            CollectionIconTemplate.Hide();
            // UI 초기화
            ToolBarSystem.OnItemCountChanged.Register((slot, count) =>
            {
                if (count == 0 && Global.CurrentTool.Value != null && Global.CurrentTool.Value is ToolSeed &&
                    (Global.CurrentTool.Value as ToolSeed).Slot.ItemId == slot.ItemId)
                {
                    SelectDefault();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            UISlot.IconLoader = (spriteName) => ResController.Instance.LoadSprite(spriteName);
            UISlot.OnItemSelect = slot =>
            {
                if (slot.Data != null)
                {
                    // 선택된 슬롯의 아이템이 있으면
                    var tool = Config.ItemForName[slot.Data.ItemId].Tool;
                    if (tool is ToolSeed)
                    {
                        (tool as ToolSeed).Slot = slot.Data;
                    }
                    // 선택된 슬롯의 도구를 변경
                    ChangeTool(tool, slot.Select, slot.Icon.sprite);
                }
            };


            // 도구
            // (순서0~9)
            ToolbarSlots.Add(ToolbarSlot1);
            ToolbarSlots.Add(ToolbarSlot2);
            ToolbarSlots.Add(ToolbarSlot3);
            ToolbarSlots.Add(ToolbarSlot4);
            ToolbarSlots.Add(ToolbarSlot5);
            ToolbarSlots.Add(ToolbarSlot6);
            ToolbarSlots.Add(ToolbarSlot7);
            ToolbarSlots.Add(ToolbarSlot8);
            ToolbarSlots.Add(ToolbarSlot9);
            ToolbarSlots.Add(ToolbarSlot10);


            var toolBarSystem = this.GetSystem<IToolBarSystem>();

            for (var i = 0; i < ToolbarSlots.Count; i++)
            {
                var slotData = toolBarSystem.Slots[i];
                var slot = ToolbarSlots[i];
                slot.InitwithData(slotData, i + 1); // 슬롯 초기화




            }

            HideAllSelect();

            SelectDefault();



        }
        //툴 변경
        void HideAllSelect()
        {
            foreach (var toolbarSlot in ToolbarSlots)
            {
                toolbarSlot.Select.Hide();
            }
        }
        void ChangeTool(ITool tool, Image selectimage, Sprite icon)
        {
            Global.CurrentTool.Value = tool;
            AudioController.Get.SfxTake.Play();

            HideAllSelect();

            selectimage.Show();
            Global.Mouse.Icon.sprite = icon;

        }
        public void SelectDefault()
        {
            UISlot.OnItemSelect(ToolbarSlots[0]);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) UISlot.OnItemSelect(ToolbarSlots[0]);
            if (Input.GetKeyDown(KeyCode.Alpha2)) UISlot.OnItemSelect(ToolbarSlots[1]);
            if (Input.GetKeyDown(KeyCode.Alpha3)) UISlot.OnItemSelect(ToolbarSlots[2]);
            if (Input.GetKeyDown(KeyCode.Alpha4)) UISlot.OnItemSelect(ToolbarSlots[3]);
            if (Input.GetKeyDown(KeyCode.Alpha5)) UISlot.OnItemSelect(ToolbarSlots[4]);
            if (Input.GetKeyDown(KeyCode.Alpha6)) UISlot.OnItemSelect(ToolbarSlots[5]);
            if (Input.GetKeyDown(KeyCode.Alpha7)) UISlot.OnItemSelect(ToolbarSlots[6]);
            if (Input.GetKeyDown(KeyCode.Alpha8)) UISlot.OnItemSelect(ToolbarSlots[7]);
            if (Input.GetKeyDown(KeyCode.Alpha9)) UISlot.OnItemSelect(ToolbarSlots[8]);
            if (Input.GetKeyDown(KeyCode.Alpha0)) UISlot.OnItemSelect(ToolbarSlots[9]); 
        }
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }

    }
}
