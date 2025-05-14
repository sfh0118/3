using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class TimeController : ViewController
	{
		public static float Seconds = 0;
        void Start()
		{
            Seconds = 0;
        }
        private void Update()
        {
            Seconds += Time.deltaTime;
        }

        private void OnDestroy()
        {
            Debug.Log($"통관소요시간{Seconds}");
        }
        private void OnGUI()
        {
			IMGUIHelper.SetDesignResolution(640, 360);

            GUI.Label(new Rect(640 - 50, 360 - 20, 640 - 100, 360 - 40), $"{(int) Seconds}s");
        }
    }
}
