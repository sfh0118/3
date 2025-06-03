using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class UIHome : ViewController
	{
		void Start()
		{
			float firstGameHours = 100;
			float firstGameCurrentHours = 0;
			BtnFirstGame.onClick.AddListener(() =>
			{
				//firstGameTotalHours == Global.Hours.Value;
				Global.Hours.Value = 0;

			});
			
		}
	}
}
