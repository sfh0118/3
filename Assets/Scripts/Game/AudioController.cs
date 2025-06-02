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

		public bool IsWalkPlaying { get; private set; } = false;

		private IActionController mWalkAction;

        public int Walk2Frames = 25;
        public int Walk3Frames = 25;
        public int Walk4Frames = 25;
        public void PlayWalk()
		{
            if (IsWalkPlaying) return; // 이미 걷는 소리가 재생 중이면 리턴
            if (mWalkAction == null)
			{
				// 걷는 소리 재생
				mWalkAction = ActionKit.Repeat()
					.Callback(() => SfxWalk2.Play())
					.DelayFrame(Walk2Frames)
					.Callback(() => SfxWalk3.Play())
					.DelayFrame(Walk3Frames)
					.Callback(() => SfxWalk4.Play())
					.DelayFrame(Walk4Frames)
					.Start(this);
			}
            IsWalkPlaying = true;



        }
		public void StopWalk()
		{
			if (!IsWalkPlaying) return; // 걷는 소리가 재생 중이 아니면 리턴
            if (mWalkAction != null)
            {
                mWalkAction.Deinit(); // 액션을 정리
                mWalkAction = null; // 액션 컨트롤러를 null로 설정
            }
			IsWalkPlaying = false; // 걷는 소리가 재생 중이 아님으로 설정

        }
	}
}
