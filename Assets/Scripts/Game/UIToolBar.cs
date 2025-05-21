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

            for (var i = 0; i < ToolbarSlots.Count; i++)
            {
                var slot = ToolbarSlots[i];

                if(i < Config.Items.Count)
                {
                    var item = Config.Items[i];

                    slot.SetData(new SlotData()
                    {
                        
                        Icon = ResController.Instance.LoadSprite(item.IconName),
                        OnSelect = () =>
                        {
                            ChangeTool(item.Tool, slot.Select, slot.Icon.sprite);
                        }
                    }, (i + 1).ToString());
                }
                else
                {
                    ToolbarSlots[i].Hide();
                }
               
            }

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
