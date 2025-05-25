using UnityEngine;
using QFramework;
using System.Linq;
using System.Collections.Generic;

namespace projectlndieFem
{
    public partial class ChallengeController : ViewController
    {

        //당일 열매수량
        public static BindableProperty<int> RipeAndHarvestCountInCurrentDay = new BindableProperty<int>(0);

        //당일 무 수량
        public static BindableProperty<int> RipeAndHarvestRadishCountInCurrentDay = new BindableProperty<int>(0);

        //당일 수확한 식물 수량
        public static BindableProperty<int> HarvestCountInCurrentDay = new BindableProperty<int>(0);

        //당일 수확한 무 수량
        public static BindableProperty<int> RadishHarvestCountInCurrentDay = new BindableProperty<int>(0);

        //당일 수확한 배추 수량
        public static BindableProperty<int> ChineseCabbageHarvestCountInCurrentDay = new BindableProperty<int>(0);

        //수확한 열매의 수량
        public static int HarvestedFruitCount = 0;
        //수확한 무의 수량
        public static int HarvestedRadishCount = 0;

        public static List<Challenge> Challenges = new List<Challenge>()
        {
            //new ChallengeHarvestAFruit(),
            //new ChallengeRipeAndHarvestTwoFruitslnADay(),
            //new ChallengeRipeAndHarvestFiveFruitslnADay(),
            //new ChallengeHarvestARadish(),
            //new ChallengeRipeAndHarvestFruitAndRadishInADay(),
            //new ChallengeHarvest10thFruit(),
            //new ChallengeHarvest10thRadish(),
            //new ChallengeFruitCountGreaterOrEqual10(),
            //new ChallengeRadishCountGreaterOrEqual10(),
            new ChallengeHarvestAChineseCabbage(),

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


            var randomItem = ChallengeController.Challenges.GetRandomItem();
            ChallengeController.ActiveChallenges.Add(randomItem);


            Global.OnPlantHarvest.Register(plant =>
            {
                if (plant is Plant)
                {
                    ChallengeController.HarvestCountInCurrentDay.Value++;

                    HarvestedFruitCount++;

                    if (plant.RipeDay == Global.Days.Value)
                    {
                        ChallengeController.RipeAndHarvestCountInCurrentDay.Value++;
                    }
                }
                else if (plant is PlantRadish)
                {
                    ChallengeController.RadishHarvestCountInCurrentDay.Value++;

                    HarvestedRadishCount++;

                    if (plant.RipeDay == Global.Days.Value)
                    {
                        ChallengeController.RipeAndHarvestRadishCountInCurrentDay.Value++;
                    }

                }
                else if(plant is PlantChineseCabbage)
                {
                    ChineseCabbageHarvestCountInCurrentDay.Value++;
                }
            }).UnRegisterWhenGameObjectDestroyed(this);
        }




        private void Update()
        {
            var hasFinishChallenge = false;
            foreach (var challenge in ChallengeController.ActiveChallenges)
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

                        ChallengeController.OnChallengeFinish.Trigger(challenge);
                        ChallengeController.FinishedChallenges.Add(challenge);
                        hasFinishChallenge = true;
                    }
                }
            }
            if (hasFinishChallenge)
            {
                ChallengeController.ActiveChallenges.RemoveAll(challenge => challenge.State == Challenge.States.Finished);

            }


            if (ChallengeController.ActiveChallenges.Count == 0 && ChallengeController.FinishedChallenges.Count != ChallengeController.Challenges.Count)
            {
                var randomItem = ChallengeController.Challenges.Where(c => c.State == Challenge.States.NotStart).ToList().GetRandomItem();
                ChallengeController.ActiveChallenges.Add(randomItem);
            }
        }

        public Font Font;
        private GUIStyle mLabelsyle;
        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(960, 540);

            GUI.Label(new Rect(960 - 300, 24 + -24, 300, 24), "@@ 도전 @@", mLabelsyle);

            for (var i = 0; i < ChallengeController.ActiveChallenges.Count; i++)
            {
                var challenge = ChallengeController.ActiveChallenges[i];

                GUI.Label(new Rect(960 - 300, 24 + i * 24, 300, 24), challenge.Name, mLabelsyle);

                if (challenge.State == Challenge.States.Finished)
                {
                    GUI.Label(new Rect(960 - 300, 24 + i * 24, 300, 24), "<color=green>" + challenge.Name + "</color>", mLabelsyle);
                }
            }
            for (var i = 0; i < ChallengeController.FinishedChallenges.Count; i++)
            {
                var challenge = ChallengeController.FinishedChallenges[i];

                GUI.Label(new Rect(960 - 300, 24 + (i + ChallengeController.ActiveChallenges.Count) * 24, 300, 24),
                "<color=green>" + challenge.Name + "</color>", mLabelsyle);

            }
        }
    }
}
