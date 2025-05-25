using UnityEngine;
using QFramework;
using System.Linq;
using UnityEngine.UI;
using System;

namespace projectlndieFem
{
	public partial class UIShop : ViewController
	{
        void SetupBtnShowCheck(BindableProperty<int> itemCount,Button btn,Func<int,bool> showCondition)
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
		void Start()
		{
            SetupBtnShowCheck(Global.FruitCount, BtnSellFruit,(count )=>count >= 1);
            SetupBtnShowCheck(Global.RadishCount, BtnSellRadish, (count) => count >= 1);
            SetupBtnShowCheck(Global.ChineseCabbageCount, BtnSellChineseCabbage, (count) => count >= 1);
            SetupBtnShowCheck(Global.Coin, BtnBuyFruitSeed, (count) => count >= 1);
            SetupBtnShowCheck(Global.Coin, BtnBuyRadishSeed, (count) => count >= 2);
            SetupBtnShowCheck(Global.Coin,BtnBuyChineseCabbageSeed, (count) => count >= 3);





            BtnBuyFruitSeed.onClick.AddListener( () =>
			{

                var seedItem = Config.Items.Single(i => i.Name == "seed");
                seedItem.Count.Value += 1;

                //수확한 열매씨앗 Item를 ++ 동작
                Global.Coin.Value -= 1;
                AudioController.Get.SfxBuy.Play();
            });

			BtnBuyRadishSeed.onClick.AddListener( () =>
			{
                var seedItem = Config.Items.Single(i => i.Name == "seed_radish");
                seedItem.Count.Value += 1;
                Global.Coin.Value -= 2;
                AudioController.Get.SfxBuy.Play();
            });

            BtnBuyChineseCabbageSeed.onClick.AddListener(() =>
            {
                var seedItem = Config.Items.Single(i => i.Name == "seed_chinese_cabbage");
                seedItem.Count.Value += 1;
                Global.Coin.Value -= 3;
                AudioController.Get.SfxBuy.Play();
            });
           
            BtnSellFruit.onClick.AddListener(() =>
            {
                Global.Coin.Value += 3;
                Global.FruitCount.Value -= 1;
                AudioController.Get.SfxBuy.Play();
            });
            BtnSellRadish.onClick.AddListener(() =>
            {
                Global.Coin.Value += 5;
                Global.RadishCount.Value -= 1;
                AudioController.Get.SfxBuy.Play();
            });
            BtnSellChineseCabbage.onClick.AddListener(() =>
            {
                Global.Coin.Value += 8;
                Global.ChineseCabbageCount.Value -= 1;
                AudioController.Get.SfxBuy.Play();
            });

        }
	}
}
