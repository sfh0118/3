using QFramework;
using UnityEngine.UI;

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
                    Global.Hours.Value -= needHoursToDay;
                    Global.FirstGameCurrentHours = Global.FirstGameTotalHours;
                    Global.FirstGameFinished.Value = true;
                    
				}
				else
				{
                    Global.FirstGameCurrentHours.Value += Global.Hours.Value;
                    Global.Hours.Value = 0;
                }
				
			});
			
		}
	}
}
