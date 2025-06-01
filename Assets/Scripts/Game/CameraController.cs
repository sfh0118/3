using UnityEngine;
using QFramework;

namespace projectlndieFem
{
    public partial class CameraController : ViewController
    {
        private Transform mPlayer;

        void Start()
        {
            mPlayer = FindObjectOfType<Player>()?.transform;
        }

        void Update()
        {
            if (mPlayer == null) return; // 플레이어 없으면 리턴

            var currentPosition = transform.position;
            var targetPosition = mPlayer.position;

            // z축을 -10으로 고정
            targetPosition.z = -10f;

            var smoothPosition = Vector3.Lerp(currentPosition, targetPosition, 1 - Mathf.Exp(-Time.deltaTime * 10));
            transform.position = smoothPosition;
        }
    }
}

//using UnityEngine;
//using QFramework;
//using UnityEngine.UIElements;

//namespace projectlndieFem
//{
//	public partial class CameraController : ViewController
//	{
//        private Transform mPlayer;
//        void Start()
//        {
//            // Code Here
//            mPlayer = FindObjectOfType<Player>()?.transform;
//        }
//        void Update()
//        {

//            var position = transform.position = Vector2.Lerp(transform.position, mPlayer.position, 1 - Mathf.Exp(-Time.deltaTime * 10));

//            transform.position = new Vector3(position.x, position.y, transform.position.z);
//        }
//    }
//}
