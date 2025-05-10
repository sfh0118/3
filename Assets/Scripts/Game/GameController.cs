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
            var randomItem = Global.Challenges.GetRandomItem();
            Global.ActiveChallenges.Add(randomItem);

            
            Global.OnPlantHarvest.Register(plant =>
            {
                if (plant is Plant)
                {
                    Global.HarvestCountInCurrentDay.Value++;

                    if (plant.RipeDay == Global.Days.Value)
                    {
                        Global.RipeAndHarvestCountInCurrentDay.Value++;
                    }
                }else if (plant is PlantRadish)
                {
                    Global.RadishHarvestCountInCurrentDay.Value++;
                    if (plant.RipeDay == Global.Days.Value)
                    {
                        Global.RipeAndHarvestRadishCountInCurrentDay.Value++;
                    }

                }
            }).UnRegisterWhenGameObjectDestroyed(this);

            Global.OnChallengeFinish.Register(challenge =>
            {
                AudioController.Get.SfxChallengeFinish.Play();


                if (Global.Challenges.All(challenge => challenge.State == Challenge.States.Finished))
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
            var hasFinishChallenge = false;
            foreach (var challenge in Global.ActiveChallenges)
            {
                if (challenge.State == Challenge.States.NotStart)
                {
                    challenge.StartDate = Global.Days.Value;
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
                        Global.FinishedChallenges.Add(challenge);
                        hasFinishChallenge = true;
                    }
                }
            }
            if (hasFinishChallenge)
            {
                Global.ActiveChallenges.RemoveAll(challenge => challenge.State == Challenge.States.Finished);

            }
                

            if(Global.ActiveChallenges.Count == 0 && Global.FinishedChallenges.Count != Global.Challenges.Count)
            {
                var randomItem = Global.Challenges.Where(c => c.State == Challenge.States.NotStart).ToList().GetRandomItem();
                Global.ActiveChallenges.Add(randomItem);
            }
            
        }
    }
}
