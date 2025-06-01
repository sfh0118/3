using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

using System.Linq;
using projectlndieFem;

namespace projectlndieFem
{
	public partial class GameController : ViewController
	{
		void Start()
		{
            Application.targetFrameRate = 60;

            ChallengeController.OnChallengeFinish.Register(challenge =>
            {
                AudioController.Get.SfxChallengeFinish.Play();


                if (ChallengeController.Challenges.All(challenge => challenge.State == Challenge.States.Finished))
                {
                    ActionKit.Delay(0.5f, () =>
                     {
                         SceneManager.LoadScene("GamePass");
                     }).Start(this);

                }
                
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }
        private void Update()
        {
           
            
        }
    }
}
