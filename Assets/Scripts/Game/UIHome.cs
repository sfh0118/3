using UnityEngine;
using QFramework;
using UnityEngine.UI;

namespace projectlndieFem
{
	public partial class UIHome : ViewController
	{
		void Start()
		{
			var firstGameTotalHours = 100f;
			var firstGameCurrentHours = 0f;
			BtnFirstGame.onClick.AddListener(() =>
			{
				var canFinishGameToday = (firstGameTotalHours - firstGameCurrentHours) <= Global.Hours.Value;

				if (canFinishGameToday)
				{
                    var needHoursToDay = firstGameTotalHours - firstGameCurrentHours;
                    Global.Hours.Value -= needHoursToDay;
                    firstGameCurrentHours = firstGameTotalHours;
                    
				}
				else
				{
                    firstGameCurrentHours += Global.Hours.Value;
                    Global.Hours.Value = 0;
                }
				BtnFirstGame.GetComponentInChildren<Text>().text = 
					$"미니농장게임({firstGameCurrentHours:0.0}/{firstGameTotalHours:0}시간)";
				
			});
			
		}
	}
}
