using UnityEngine;
using QFramework;

namespace ProjectlndieFarm
{
	public partial class TlieSelectController : ViewController, ISingleton
	{
		public static TlieSelectController Instance => MonoSingletonProperty<TlieSelectController>.Instance;
        public void OnSingletonInit()
        {
            
        }
    }
}
