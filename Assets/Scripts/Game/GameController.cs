using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

using System.Linq;
using projectlndieFem;

namespace ProjectlndieFarm
{
	public partial class GameController : ViewController
	{
		void Start()
		{
            
            Global.OnPlantHarvest.Register(print =>
            {
                if (print.RipeDay == Global.Days.Value)
                {
                    Global.RipeAndHarvestCountInCurrentDay.Value++;
                }
            }).UnRegisterWhenGameObjectDestroyed(this);

            Global.OnChallengeFinish.Register(challenge =>
            {
                Debug.Log("@@@@@" + challenge.GetType().Name + " 도전완료");

                if(Global.Challenges.All(challenge => challenge.State == Challenge.States.Finished))
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
            foreach(var challenge in Global.Challenges.Where(Challenge=>Challenge.State != Challenge.States.Finished))
            {
                if (challenge.State == Challenge.States.NotStart)
                {
                    challenge.OnStart();
                    challenge.State = Challenge.States.Started;
                }
                if (challenge.State == Challenge.States.Started)
                {
                    if (challenge.CheckFinish())
                    {
                        challenge.OnFinish();
                        challenge.State = Challenge.States.Finished;

                    }
                }
            }
        }
    }
}
