using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class Home : ViewController
	{
		
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name.StartsWith("Player"))
            {
                Global.Days.Value++;

                col.PositionY(this.Position().y - 3);
                AudioController.Get.SfxNextDay.Play();
            }
        }
    }
}
