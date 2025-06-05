using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

using System.Linq;
using projectlndieFem;

namespace projectlndieFem
{
	public partial class GameController : ViewController,IController
	{
        

        void Start()
		{
            var challengeSystem = this.GetSystem<IChallengeSystem>();
            Application.targetFrameRate = 60;

            ChallengeSystem.OnChallengeFinish.Register(challenge =>
            {
                AudioController.Get.SfxChallengeFinish.Play();
                Global.Coin.Value += 100;
                UIMessageQueue.Push("도전[" + challenge.Name + "]완료 코인<colcr=yellow>+$100</color>");
                if (challengeSystem.Challenges.All(challenge => challenge.State == Challenge.States.Finished))
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
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }
}
