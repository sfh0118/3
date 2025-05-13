using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class UIShop : ViewController
	{
		void Start()
		{
			Global.FruitCount.RegisterWithInitValue(fruitCout =>
			{
				if (fruitCout >= 1)
				{
					BtnBuyFruitSeed.Show();
				}
				else
				{
					BtnBuyFruitSeed.Hide();
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.RadishCount.RegisterWithInitValue(radishCount =>
            {
                if (radishCount >= 1)
                {
                    BtnBuyRadishSeed.Show();
                }
                else
                {
                    BtnBuyRadishSeed.Hide();
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

			BtnBuyFruitSeed.onClick.AddListener( () =>
			{
				Global.FruitSeedCount.Value += 2;
				Global.FruitCount.Value -= 1;
			});

			BtnBuyRadishSeed.onClick.AddListener( () =>
			{
				Global.RadishSeedCount.Value += 2;
				Global.RadishCount.Value -= 1;
			});
        }
	}
}
