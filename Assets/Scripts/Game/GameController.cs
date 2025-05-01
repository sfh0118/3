using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;
using System.Linq;

namespace ProjectlndieFarm
{
	public partial class GameController : ViewController
	{
		void Start()
		{
            Global.OnChallengeFinish.Register(challenge =>
            {
                Debug.Log("@@@@@" + challenge.GetType().Name + " ????");
            });
        }
        private void Update()
        {
            foreach(var challenge in Global.Challenges.Where(Challenge=>Challenge.State != Challenge.States.Finished))
            {
                if (challenge.State ==Challenge.States.NotStart)
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
                        Global.OnChallengeFinish.Trigger(challenge);
                    }
                }
            }
        }
    }
}
