using UnityEngine;
using QFramework;
using UnityEngine.UI;

namespace projectlndieFem
{
	public partial class UIToolBar : ViewController
	{
		void Start()
		{
            HideAllSelect();
            Btn1Select.Hide();
            Global.Mouse.Icon.sprite = Btn1Icon.sprite;
            //툴 초기화

            //툴 버튼 클릭
            Btn1.onClick.AddListener(() =>
            {
                ChangeTool(Constant.TOOL_HAND,Btn1Select,Btn1Icon.sprite);
            });
            Btn2.onClick.AddListener(() =>
            {
                ChangeTool(Constant.TOOL_SHOVEL,Btn2Select,Btn2Icon.sprite);
            });
            Btn3.onClick.AddListener(() =>
            {
                ChangeTool(Constant.TOOL_SEED,Btn3Select,Btn3Icon.sprite);
            });
            Btn4.onClick.AddListener(() =>
            {
                ChangeTool(Constant.TOOL_WATERING_SCAN,Btn4Select,Btn4Icon.sprite);
            });
            Btn5.onClick.AddListener(() =>
            {
                ChangeTool(Constant.TOOL_SEED_RADISH, Btn5Select, Btn5Icon.sprite);
            }); 
        }
        //툴 변경
        void HideAllSelect()
        {
            Btn1Select.Hide();
            Btn2Select.Hide();
            Btn3Select.Hide();
            Btn4Select.Hide();
            Btn5Select.Hide();
        }
        void ChangeTool(string tool,Image selectimage,Sprite icon)
        {
            ChallengeComtroller.CurrentTool.Value = tool;
            AudioController.Get.SfxTake.Play();

            HideAllSelect();
            selectimage.Show();
            Global.Mouse.Icon.sprite = icon;

        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeTool(Constant.TOOL_HAND, Btn1Select,Btn1Icon.sprite);
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeTool(Constant.TOOL_SHOVEL, Btn2Select,Btn2Icon.sprite);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeTool(Constant.TOOL_SEED, Btn3Select,Btn3Icon.sprite);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ChangeTool(Constant.TOOL_WATERING_SCAN, Btn4Select,Btn4Icon.sprite);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ChangeTool(Constant.TOOL_SEED_RADISH, Btn5Select, Btn5Icon.sprite);
            }
        }
    }
}
