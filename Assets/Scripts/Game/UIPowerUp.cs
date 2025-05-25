using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class UIPowerUp : ViewController
	{
        void Start()
        {
            UIShop.SetupBtnShowCheck(Global.Coin, BtnWateringCan1, (coin) => coin >= 30 && !Global.WateringCanRange1Unlock, gameObject);

            UIShop.SetupBtnShowCheck(Global.Coin, BtnHandRange1, (coin) => coin >= 20 && !Global.HandRange1Unlock && Global.WateringCanRange1Unlock, gameObject);


            UIShop.SetupBtnShowCheck(Global.Coin, BtnSeedRange1, (coin) => coin >= 25 && !Global.SeedRange1Unlock && Global.HandRange1Unlock, gameObject);

            UIShop.SetupBtnShowCheck(Global.Coin, BtnShoveRange1, (coin) => coin >= 20 && !Global.ShovelRange1Unlock && Global.SeedRange1Unlock, gameObject);

            BtnHandRange1.onClick.AddListener(() =>
            {
                Global.HandRange1Unlock = true;
                Global.Coin.Value -= 20;
                AudioController.Get.SfxBuy.Play();
            });
            BtnShoveRange1.onClick.AddListener(() =>
            {
                Global.ShovelRange1Unlock = true;
                Global.Coin.Value -= 20;
                AudioController.Get.SfxBuy.Play();
            });
            BtnWateringCan1.onClick.AddListener(() =>
            {
                Global.WateringCanRange1Unlock = true;
                Global.Coin.Value -= 30;
                AudioController.Get.SfxBuy.Play();
            });
            BtnSeedRange1.onClick.AddListener(() =>
            {
                Global.SeedRange1Unlock = true;
                Global.Coin.Value -= 25;
                AudioController.Get.SfxBuy.Play();
            });
        }
	}
}
