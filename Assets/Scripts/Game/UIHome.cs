using QFramework;
using System;
using UnityEngine.UI;
using UnityEngine;

namespace projectlndieFem
{
	public partial class UIHome : ViewController
	{
		void Start()
		{
            Global.FirstGameFinished.RegisterWithInitValue(finished =>
			{
				if (finished)
				{
					BtnFirstGame.Hide();
				}
				else
				{
					BtnFirstGame.Show();
				}

			}).UnRegisterWhenGameObjectDestroyed(gameObject);

			Global.FirstGameCurrentHours.RegisterWithInitValue(hours =>
			{
                BtnFirstGame.GetComponentInChildren<Text>().text =
                    $"미니농장게임({hours:0.0}/{Global.FirstGameTotalHours.Value:0}시간)";

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
           
			BtnFirstGame.onClick.AddListener(() =>
			{
				var canFinishGameToday = (Global.FirstGameTotalHours.Value - Global.FirstGameCurrentHours.Value) <= Global.Hours.Value;

				if (canFinishGameToday)
				{
                    var needHoursToDay = Global.FirstGameTotalHours.Value - Global.FirstGameCurrentHours.Value;
					UIMessageQueue.Push($"시간수-{needHoursToDay}");
                    Global.Hours.Value -= needHoursToDay;
                    Global.FirstGameCurrentHours = Global.FirstGameTotalHours;
                    Global.FirstGameFinished.Value = true;
                    
				}
				else
                {
                    UIMessageQueue.Push($"시간수-{Global.Hours.Value}");
                    Global.FirstGameCurrentHours.Value += Global.Hours.Value;
                    Global.Hours.Value = 0;
                }
				
			});
			Global.Hours.RegisterWithInitValue(hours =>
			{
				if (hours > 1)
				{
					BtnPartTime.Show();
				}
				else
				{
					BtnPartTime.Hide();
				}
			}).UnRegisterWhenGameObjectDestroyed(gameObject);
			BtnPartTime.onClick.AddListener(() =>
			{
				var coinPerHour = UnityEngine.Random.Range(2f, 3f);
				var income = Global.Hours.Value * coinPerHour;
                UIMessageQueue.Push($"시간수-{Global.Hours.Value} 코인$+{income}");
                Global.Coin.Value += (int)income;
				Global.Hours.Value = 0;

			});
			
		}
	}
}
