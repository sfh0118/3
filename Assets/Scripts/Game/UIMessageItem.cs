using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class UIMessageItem : ViewController
	{
		public void SetAlpha(float alpha)
		{
			Icon.ColorAlpha(alpha);
			TextWithIcon.ColorAlpha(alpha);
            Text.ColorAlpha(alpha);
        }
	}
}
