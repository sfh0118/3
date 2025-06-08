
using UnityEngine;
using QFramework;
using UnityEngine.UIElements;
using DG.Tweening;

namespace projectlndieFem
{
    public partial class CameraController : ViewController
    {
        private Transform mPlayer;
        void Start()
        {
            // Code Here
            mPlayer = FindObjectOfType<Player>()?.transform;
        }
        private static CameraController mDefault;
        private void Awake()
        {
            mDefault = this;
        }
        private void OnDestroy()
        {
            
                mDefault = null;
            
        }
        public static void ShakeHeavy()
        {
            mDefault.mMovementEnabled = false;
            // 카메라 흔들기
            mDefault.GetComponent<Camera>().DOShakePosition(0.2f, 0.1f, 100, 180, true, ShakeRandomnessMode.Harmonic)
                .OnComplete(()=>
                {
                    mDefault.mMovementEnabled = true;
                });
        }
        public static void ShakeMiddle()
        {
            mDefault.mMovementEnabled = false;
            // 카메라 흔들기
            mDefault.GetComponent<Camera>().DOShakePosition(0.2f, 0.05f, 100, 180, true, ShakeRandomnessMode.Harmonic)
                .OnComplete(() =>
                {
                    mDefault.mMovementEnabled = true;
                });
        }
        public static void ShakeSlight()
        {
            mDefault.mMovementEnabled = false;
            // 카메라 흔들기
            mDefault.GetComponent<Camera>().DOShakePosition(0.2f, 0.02f, 100, 180, true, ShakeRandomnessMode.Harmonic)
                .OnComplete(() =>
                {
                    mDefault.mMovementEnabled = true;
                });
        }
        private bool mMovementEnabled = true;
        void Update()
        {
            if (mMovementEnabled)
            {
                var position =
                    Vector2.Lerp(transform.position, mPlayer.position, 1 - Mathf.Exp(-Time.deltaTime * 10));
                transform.position = new Vector3(position.x, position.y, transform.position.z);
            }
        }
    }
}
