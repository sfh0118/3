using UnityEngine;
using QFramework;
using System.Linq;
using UnityEngine.UI;
using System;

namespace projectlndieFem
{
	public partial class UIShop : ViewController,IController
	{
        public static void SetupBtnShowCheck(BindableProperty<int> itemCount,Button btn,Func<int,bool> showCondition,GameObject gameObject)
        {
            itemCount.RegisterWithInitValue(count =>
            {
                if (showCondition(count))
                {
                    btn.Show();
                }
                else
                {
                    btn.Hide();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
        }
        public  void CreateSellItem(string itemName, string displayName, int sellPrice)
        {
            var btnSellItem = BtnTemplate.InstantiateWithParent(BtnRoot);
            btnSellItem.onClick.AddListener(() =>
            {
                var toolBarSystem = this.GetSystem<IToolBarSystem>();
                var carrotItem = toolBarSystem.Items.FirstOrDefault(Item => Item.Name == itemName);
                if (carrotItem != null)
                {
                    Global.Coin.Value += sellPrice;
                    this.SendCommand(new SubItemCountCommand(itemName, 1));
                }


                AudioController.Get.SfxBuy.Play();
            });
            btnSellItem.GetComponentInChildren<Text>().text = displayName;
            if ( Global.Interface.GetSystem<IToolBarSystem>().Items.Any(item => item != null && item.Name == itemName))
            {
                btnSellItem.Show();
            }
            else
            {
                btnSellItem.Hide();
            }
            ToolBarSystem.OnItemCountChanged.Register((item, count) =>
            {
                if (item.Name == itemName)
                {
                    if (count >0)
                    {
                        btnSellItem.Show();
                    }
                    else
                    {
                        btnSellItem.Hide();
                    }
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            
        }

        public void CreateBuyItem(string itemName, string displayName, int buyPrice)
        {
            var btnBuyItem = BtnTemplate.InstantiateWithParent(BtnRoot);
            btnBuyItem.onClick.AddListener(() =>
            {
                Global.Coin.Value -= buyPrice;
                this.SendCommand(new AddItemCountCommand(itemName, 1));

                AudioController.Get.SfxBuy.Play();
            });
            btnBuyItem.GetComponentInChildren<Text>().text = displayName;
            Global.Coin.RegisterWithInitValue(coin =>
            {
                if (coin >= buyPrice)
                {
                    btnBuyItem.Show();
                }
                else
                {
                    btnBuyItem.Hide();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
        void Start()
		{

            BtnTemplate.Hide();

            CreateSellItem("carrot", "매출:당근($+12)", 12);
            CreateSellItem("pumpkin", "매출:호박 ($+20)", 20);
            CreateSellItem("potato", "매출:감자($10)", 10);
            CreateSellItem("tomato", "매출:토마토($13)", 13);
            CreateSellItem("bean", "매출:단콩($15)", 15);

            CreateBuyItem("seed_carot","구입:당근씨앗($-5)", 5);
            CreateBuyItem("seed_pumpkin", "구입:호박씨앗($-8)", 8);
            CreateBuyItem("seed_potato", "구입:감자씨앗($-4)", 4);
            CreateBuyItem("seed_tomato", "구입:토마토씨앗($-5)", 5);
            CreateBuyItem("seed_bean", "구입:단콩씨앗($-6)", 6);

        }
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
	}
}
