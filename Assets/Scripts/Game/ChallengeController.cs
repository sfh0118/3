using UnityEngine;
using QFramework;
using System.Linq;
using System.Collections.Generic;

namespace projectlndieFem
{
    public partial class ChallengeController : ViewController,IController
    {

        public static BindableProperty<int> CarrotHarvestCountInCurrentDay = new BindableProperty<int>(0);
        public static BindableProperty<int> PotatoHarvestCountInCurrentDay = new BindableProperty<int>(0);
        public static BindableProperty<int> TomatoHarvestCountInCurrentDay = new BindableProperty<int>(0);
        public static BindableProperty<int> PumpkinHarvestCountInCurrentDay = new BindableProperty<int>(0);
        public static BindableProperty<int> BeanHarvestCountInCurrentDay = new BindableProperty<int>(0);

        public static int HarvestCarrotCount = 0;
        public static int HarvestPotatoCount = 0;
        public static int HarvestTomatoCount = 0;
        public static int HarvestPumpkinCount = 0;
        public static int HarvestBeanCount = 0;

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
            //new ChallengeHarvestAChineseCabbage(),
            //new ChallengeCoin100(),
            //new ChallengeHarvest10thChineseCabbage(),
            ////new ChallengeChineseCabbageCountGreaterOrEqual10(),
            //new ChallengeHarvestACarrot(),
            //new ChallengeHarvest10thCarrot(),
            //new ChallengeCarrotCountGreatorOrEqual10(),

        };
        public static List<Challenge> ActiveChallenges = new List<Challenge>()
        {

        };

        public static List<Challenge> FinishedChallenges = new List<Challenge>()
        {

        };
        public static EasyEvent<Challenge> OnChallengeFinish = new EasyEvent<Challenge>();


        //private IChallengeSystem mUIChallengeSystem;
        private void Awake()
        {
            var potatoCount = 0;
            var tomatoCount = 0;
            var pumpkinCount = 0;
            var beanCount = 0;
            ToolBarSystem.OnItemCountChanged.Register((Item, count) =>
            {
                if (Item.Name == "potato")
                {
                    potatoCount = count;
                }
                else if (Item.Name == "tomato")
                {
                    tomatoCount = count;
                }
                else if (Item.Name == "pumpkin")
                {
                    pumpkinCount = count;
                }
                else if (Item.Name == "bean")
                {
                    beanCount = count;
                }
            }).UnRegisterWhenGameObjectDestroyed(this);
            Challenges.Add(new GenericChallenge()
                .Key("감자하나수확")
                .OnCheckFinish(self => Global.Days.Value != self.StartDate && PotatoHarvestCountInCurrentDay.Value > 0));
            Challenges.Add(new GenericChallenge()
                .Key("토마토하나수확")
                .OnCheckFinish(self => Global.Days.Value != self.StartDate && TomatoHarvestCountInCurrentDay.Value > 0));
            Challenges.Add(new GenericChallenge()
                .Key("호박하나수확")
                .OnCheckFinish(self => Global.Days.Value != self.StartDate && PumpkinHarvestCountInCurrentDay.Value > 0));
            Challenges.Add(new GenericChallenge()
                .Key("단콩하나수확")
                .OnCheckFinish(self => Global.Days.Value != self.StartDate && BeanHarvestCountInCurrentDay.Value > 0));
            Challenges.Add(new GenericChallenge()
                .Key("10번째감자수확하기")
                .OnCheckFinish(self => HarvestPotatoCount >= 10));
            Challenges.Add(new GenericChallenge()
                .Key("10번째토마토수확하기")
                .OnCheckFinish(self => HarvestTomatoCount >= 10));
            Challenges.Add(new GenericChallenge()
                .Key("10번째호박수확하기")
                .OnCheckFinish(self => HarvestPumpkinCount >= 10));
            Challenges.Add(new GenericChallenge()
                .Key("10번째단콩수확하기")
                .OnCheckFinish(self => HarvestBeanCount >= 10));
            Challenges.Add(new GenericChallenge()
                .Key("10개감자보요하기")
                .OnCheckFinish(self => potatoCount >= 10));
            Challenges.Add(new GenericChallenge()
                .Key("10개토마토보요하기")
                .OnCheckFinish(self => tomatoCount >= 10));
            Challenges.Add(new GenericChallenge()
                .Key("10개호박보요하기")
                .OnCheckFinish(self => pumpkinCount >= 10));
            Challenges.Add(new GenericChallenge()
                .Key("10개단콩보요하기")
                .OnCheckFinish(self => beanCount >= 10));


        }
        //public override void OnDestroy()
        //{
        //    mUIChallengeSystem = null;
        //}


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
                    var plantObj = plant as Plant;
                    if(plantObj.Name == "potato")
                    {
                        PotatoHarvestCountInCurrentDay.Value++;

                        HarvestPotatoCount++;
                    }
                    else if (plantObj.Name == "tomato")
                    {
                        TomatoHarvestCountInCurrentDay.Value++;
                        HarvestTomatoCount++;
                    }
                    else if (plantObj.Name == "pumkin")
                    {
                        PumpkinHarvestCountInCurrentDay.Value++;
                        HarvestTomatoCount++;
                    }
                    else if (plantObj.Name == "bean")
                    {
                        BeanHarvestCountInCurrentDay.Value++;
                        HarvestTomatoCount++;
                    }

                }
               
                else if (plant is PlantCarrot)
                {
                    CarrotHarvestCountInCurrentDay.Value++;
                    HarvestCarrotCount++;
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
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }
}
