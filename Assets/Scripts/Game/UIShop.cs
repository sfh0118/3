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
		void Start()
		{
            SetupBtnShowCheck(Global.FruitCount, BtnSellFruit,(count )=>count >= 1,gameObject);
            SetupBtnShowCheck(Global.RadishCount, BtnSellRadish, (count) => count >= 1, gameObject);
            SetupBtnShowCheck(Global.ChineseCabbageCount, BtnSellChineseCabbage, (count) => count >= 1, gameObject);
            SetupBtnShowCheck(Global.Coin, BtnBuyFruitSeed, (count) => count >= 1, gameObject);
            SetupBtnShowCheck(Global.Coin, BtnBuyRadishSeed, (count) => count >= 2, gameObject);
            SetupBtnShowCheck(Global.Coin,BtnBuyChineseCabbageSeed, (count) => count >= 3, gameObject);





            BtnBuyFruitSeed.onClick.AddListener( () =>
			{
                this.SendCommand(new AddItemCountCommand("Seed",1));
                //수확한 열매씨앗 Item를 ++ 동작
                Global.Coin.Value -= 1;
                AudioController.Get.SfxBuy.Play();
            });

			BtnBuyRadishSeed.onClick.AddListener( () =>
			{
                this.SendCommand(new AddItemCountCommand("seed_radish", 1));
                Global.Coin.Value -= 2;
                AudioController.Get.SfxBuy.Play();
            });

            BtnBuyChineseCabbageSeed.onClick.AddListener(() =>
            {
                this.SendCommand(new AddItemCountCommand("seed_chinese_cabbage", 1));
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
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
	}
}
