using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class AudioController : ViewController,ISingleton
	{
		public static AudioController Get => MonoSingletonProperty<AudioController>.Instance;
        
        public void OnSingletonInit()
		{
			// Code Here
		}
	}
}
