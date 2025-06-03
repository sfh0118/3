using UnityEngine;
using QFramework;

namespace projectlndieFem
{
    public partial class UIGame : ViewController
    {
        void Start()
        {
            Global.Days.RegisterWithInitValue(day =>
            {
                DayText.text = $"제{day}일";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.Hours.RegisterWithInitValue(hours =>
            {
                HourText.text = $"{hours: 0.0}시간";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            Global.Coin.RegisterWithInitValue(coin =>
            {
                CoinText.text = $"${coin}";
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

        }
    }
}
