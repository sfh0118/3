﻿using UnityEngine;
using QFramework;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace projectlndieFem
{
    public partial class UIToolBar : ViewController
    {
        public List<UISlot> ToolbarSlots = new List<UISlot>();

       
        void Start()
        {
            UISlot.IconLoader = (spriteName) => ResController.Instance.LoadSprite(spriteName);
            UISlot.OnItemSelect = slot =>
            {
                if (slot.Data != null)
                {
                    ChangeTool(slot.Data.Tool, slot.Select, slot.Icon.sprite);
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

            for (var i = 0; i < ToolbarSlots.Count; i++)
            {
                var slot = ToolbarSlots[i];

                if(i < Config.Items.Count)
                {

                    slot.SetData(Config.Items[i], (i + 1).ToString());
                }
                else
                {
                    ToolbarSlots[i].Hide();
                }
               
            }

            HideAllSelect();
            ToolbarSlots[0].Select.Hide();
            Global.Mouse.Icon.sprite = ToolbarSlots[0].Icon.sprite;
           


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
    }
}
