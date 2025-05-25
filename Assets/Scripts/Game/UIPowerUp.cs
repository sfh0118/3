using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class UIPowerUp : ViewController
	{
        void Start()
        {
            UIShop.SetupBtnShowCheck(Global.Coin, BtnHandRange1, (coin) => coin >= 20 && !Global.HandRangelUnlock, gameObject);
            UIShop.SetupBtnShowCheck(Global.Coin, BtnShoveRange1, (coin) => coin >= 20 && !Global.ShovelRangelUnlock, gameObject);
            UIShop.SetupBtnShowCheck(Global.Coin, BtnWateringCan1, (coin) => coin >= 30 && !Global.WateringCanRangelUnlock, gameObject);

            BtnHandRange1.onClick.AddListener(() =>
            {
                Global.HandRangelUnlock = true;
                Global.Coin.Value -= 20;
                AudioController.Get.SfxBuy.Play();
            });
            BtnShoveRange1.onClick.AddListener(() =>
            {
                Global.ShovelRangelUnlock = true;
                Global.Coin.Value -= 20;
                AudioController.Get.SfxBuy.Play();
            });
            BtnWateringCan1.onClick.AddListener(() =>
            {
                Global.WateringCanRangelUnlock = true;
                Global.Coin.Value -= 30;
                AudioController.Get.SfxBuy.Play();
            });
        }
	}
}
