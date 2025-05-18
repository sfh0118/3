using UnityEngine;
using QFramework;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace projectlndieFem
{
    public partial class UIToolBar : ViewController
    {
        public List<UISlot> ToolbarSlots = new List<UISlot>();

        public interface ISlotData
        {
            public Image Icon { get; set; }
            public Action OnSelect { get; set; }
        }
        void Start()
        {

            ToolbarSlot1.SetData(new SlotData()
            {
                Icon= ResController.Instance.LoadSprite("ToolHand_0"),
                OnSelect =() => {ChangeTool(Constant.ToolHand, ToolbarSlot1.Select, ToolbarSlot1.Icon.sprite); }
            },"1손");
            ToolbarSlot2.SetData(new SlotData()
            {
                Icon = ResController.Instance.LoadSprite("ToolShovel_0"),
                OnSelect = () => { ChangeTool(Constant.ToolShovel, ToolbarSlot2.Select, ToolbarSlot2.Icon.sprite); }
            },"2깽이");
            ToolbarSlot3.SetData(new SlotData()
            {
                Icon = ResController.Instance.LoadSprite("ToolSeed_0"),
                OnSelect = () => { ChangeTool(Constant.ToolSeed, ToolbarSlot3.Select, ToolbarSlot3.Icon.sprite); }
            },"3 열매");
            ToolbarSlot4.SetData(new SlotData()
            {
                Icon = ResController.Instance.LoadSprite("ToolWateringCan_0"),
                OnSelect = () => { ChangeTool(Constant.ToolWateringCan, ToolbarSlot4.Select, ToolbarSlot4.Icon.sprite); }
            },"4 물");
            ToolbarSlot5.SetData(new SlotData()
            {
                Icon = ResController.Instance.LoadSprite("ToolSeedRadish_0"),
                OnSelect = () => { ChangeTool(Constant.ToolSeedRadish, ToolbarSlot5.Select, ToolbarSlot5.Icon.sprite); }
            },"5 무");
            ToolbarSlot6.SetData(new SlotData()
            {
                Icon = ResController.Instance.LoadSprite("ToolSeedChineseCabbage_0"),
                OnSelect = () => { ChangeTool(Constant.ToolSeedChineseCabbage, ToolbarSlot6.Select, ToolbarSlot6.Icon.sprite); }
            },"6 배추");
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


            HideAllSelect();
            ToolbarSlots[0].Select.Hide();
            Global.Mouse.Icon.sprite = ToolbarSlots[0].Icon.sprite;
            //툴 초기화

            foreach (var toolbarSlot in ToolbarSlots)
            {
                var data = toolbarSlot.Data;
                toolbarSlot.GetComponent<Button>().onClick.AddListener(() =>
                {
                   data?.OnSelect?.Invoke();
                
                });
            }

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
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) ToolbarSlots[0].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha2)) ToolbarSlots[1].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha3)) ToolbarSlots[2].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha4)) ToolbarSlots[3].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha5)) ToolbarSlots[4].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha6)) ToolbarSlots[5].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha7)) ToolbarSlots[6].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha8)) ToolbarSlots[7].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha9)) ToolbarSlots[8].Data?.OnSelect?.Invoke();
            if (Input.GetKeyDown(KeyCode.Alpha0)) ToolbarSlots[9].Data?.OnSelect?.Invoke();

        }
    }
}
