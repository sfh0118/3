using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace projectlndieFem
{
	public partial class GameController : ViewController
	{
		void Start()
		{
			// Code Here

			Global.FruitCount.Register(fruitCount =>
			{

				if (fruitCount >= 1)
				{
					ActionKit.Delay(1.0f, () =>
					{
						SceneManager.LoadScene("GamePass");

					}).Start(this);
				}
			}).UnRegisterWhenGameObjectDestroyed(this);
		}
	}
}
