using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class UIMessageQueue : ViewController
	{
		public static void Push(Sprite icon,string message)
        {
            mInstance.UIMessageItemTemplete.InstantiateWithParent(mInstance.MessageRoot)
                 .Self(self =>
                 {
                     self.Icon.sprite = icon;
                     self.TextWithIcon.text = message;
                     self.Text.Hide();
                     self.Icon.Show();
                     self.TextWithIcon.Show();
                     self.SetAlpha(0);
                     self.Show();
                     ActionKit.Sequence()
                     .Lerp(1, 0, 0.5f, self.SetAlpha)
                     .Delay(3.0f)
                     .Lerp(0, 1, 2.0f, self.SetAlpha)
                     .Start(self, () =>
                     {
                         self.DestroyGameObj();
                     });

                 });

        }
        public static void Push( string message)
        {
            mInstance.UIMessageItemTemplete.InstantiateWithParent(mInstance.MessageRoot)
                 .Self(self =>
                 {
                     self.Text.text = message;
                     self.TextWithIcon.Hide();
                     self.Icon.Hide();
                     self.Text.Show();
                     self.SetAlpha(0);
                     self.Show();

                     ActionKit.Sequence()
                     .Lerp(0, 1, 0.5f, self.SetAlpha)
                     .Delay(3.0f)
                     .Lerp(1, 0, 2.0f, self.SetAlpha)
                     .Start(self, () =>
                     {
                         self.DestroyGameObj();
                     });

                 });
        }
        private static UIMessageQueue mInstance;

        void Start()
        {
            UIMessageItemTemplete.Hide();

        }
        private void Awake()
        {
            mInstance = this;
        }
        
        private void OnDestroy()
        {
            mInstance = null;
        }
         
	}
}
