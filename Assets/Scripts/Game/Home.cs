using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class Home : ViewController
	{
		
     
        public void NextDay()
        {
            Global.Days.Value++;

            AudioController.Get.SfxNextDay.Play();
        }
    }
}
