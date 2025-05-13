using UnityEngine;
using QFramework;
using System.Linq;
using System.Collections.Generic;

namespace projectlndieFem
{
    public partial class ChallengeComtroller : ViewController
    {

        //당일 열매수량
        public static BindableProperty<int> RipeAndHarvestCountInCurrentDay = new BindableProperty<int>(0);

        //당일 무 수량
        public static BindableProperty<int> RipeAndHarvestRadishCountInCurrentDay = new BindableProperty<int>(0);

        //당일 수확한 식물 수량
        public static BindableProperty<int> HarvestCountInCurrentDay = new BindableProperty<int>(0);

        //당일 수확한 무 수량
        public static BindableProperty<int> RadishHarvestCountInCurrentDay = new BindableProperty<int>(0);

        public static List<Challenge> Challenges = new List<Challenge>()
        {
            new ChallengeHarvestAFruit(),
            new ChallengeRipeAndHarvestTwoFruitslnADay(),
            new ChallengeRipeAndHarvestFiveFruitslnADay(),
            new ChallengeHarvestARadish(),
            new ChallengeRipeAndHarvestFruitAndRadishInADay(),

        };
        public static List<Challenge> ActiveChallenges = new List<Challenge>()
        {

        };

        public static List<Challenge> FinishedChallenges = new List<Challenge>()
        {

        };
        public static EasyEvent<Challenge> OnChallengeFinish = new EasyEvent<Challenge>();
        void Start()
        {
            // Code Here
            mLabelsyle = new GUIStyle("Label")
            {
                font = Font,
            };


            var randomItem = ChallengeComtroller.Challenges.GetRandomItem();
            ChallengeComtroller.ActiveChallenges.Add(randomItem);


            Global.OnPlantHarvest.Register(plant =>
            {
                if (plant is Plant)
                {
                    ChallengeComtroller.HarvestCountInCurrentDay.Value++;

                    if (plant.RipeDay == Global.Days.Value)
                    {
                        ChallengeComtroller.RipeAndHarvestCountInCurrentDay.Value++;
                    }
                }
                else if (plant is PlantRadish)
                {
                    ChallengeComtroller.RadishHarvestCountInCurrentDay.Value++;
                    if (plant.RipeDay == Global.Days.Value)
                    {
                        ChallengeComtroller.RipeAndHarvestRadishCountInCurrentDay.Value++;
                    }

                }
            }).UnRegisterWhenGameObjectDestroyed(this);
        }




        private void Update()
        {
            var hasFinishChallenge = false;
            foreach (var challenge in ChallengeComtroller.ActiveChallenges)
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

                        ChallengeComtroller.OnChallengeFinish.Trigger(challenge);
                        ChallengeComtroller.FinishedChallenges.Add(challenge);
                        hasFinishChallenge = true;
                    }
                }
            }
            if (hasFinishChallenge)
            {
                ChallengeComtroller.ActiveChallenges.RemoveAll(challenge => challenge.State == Challenge.States.Finished);

            }


            if (ChallengeComtroller.ActiveChallenges.Count == 0 && ChallengeComtroller.FinishedChallenges.Count != ChallengeComtroller.Challenges.Count)
            {
                var randomItem = ChallengeComtroller.Challenges.Where(c => c.State == Challenge.States.NotStart).ToList().GetRandomItem();
                ChallengeComtroller.ActiveChallenges.Add(randomItem);
            }
        }

        public Font Font;
        private GUIStyle mLabelsyle;
        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(960, 540);

            GUI.Label(new Rect(960 - 300, 20 + -24, 300, 20), "@@ 도전 @@", mLabelsyle);

            for (var i = 0; i < ChallengeComtroller.ActiveChallenges.Count; i++)
            {
                var challenge = ChallengeComtroller.ActiveChallenges[i];

                GUI.Label(new Rect(960 - 300, 20 + i * 20, 300, 20), challenge.Name, mLabelsyle);

                if (challenge.State == Challenge.States.Finished)
                {
                    GUI.Label(new Rect(960 - 300, 20 + i * 20, 300, 20), "<color=green>" + challenge.Name + "</color>", mLabelsyle);
                }
            }
            for (var i = 0; i < ChallengeComtroller.FinishedChallenges.Count; i++)
            {
                var challenge = ChallengeComtroller.FinishedChallenges[i];

                GUI.Label(new Rect(960 - 300, 20 + (i + ChallengeComtroller.ActiveChallenges.Count) * 20, 300, 20),
                "<color=green>" + challenge.Name + "</color>", mLabelsyle);

            }
        }
    }
}
