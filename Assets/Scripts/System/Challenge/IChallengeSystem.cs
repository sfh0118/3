using QFramework;
using System.Collections.Generic;

namespace projectlndieFem
{
    public interface IChallengeSystem : ISystem
    {
        //void LoadDate();
        //void SaveDate();
        //void ResetDate();
    }
public class ChallengeSystem : AbstractSystem//,IChallengeSystem
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

        };
        public static List<Challenge> ActiveChallenges = new List<Challenge>()
        {

        };

        public static List<Challenge> FinishedChallenges = new List<Challenge>()
        {

        };
        public static EasyEvent<Challenge> OnChallengeFinish = new EasyEvent<Challenge>();
        protected override void OnInit()
        {
            var potatoCount = 0;
            var tomatoCount = 0;
            var pumpkinCount = 0;
            var beanCount = 0;
            var carrotCount = 0;
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
                else if (Item.Name == "carrot")
                {
                    carrotCount = count;
                }
            });
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

            var randomItem = Challenges.GetRandomItem();
            ActiveChallenges.Add(randomItem);


            Global.OnPlantHarvest.Register(plant =>
            {

                if (plant is Plant)
                {
                    var plantObj = plant as Plant;
                    if (plantObj.Name == "potato")
                    {
                        PotatoHarvestCountInCurrentDay.Value++;

                        HarvestPotatoCount++;
                    }
                    else if (plantObj.Name == "tomato")
                    {
                        TomatoHarvestCountInCurrentDay.Value++;
                        HarvestTomatoCount++;
                    }
                    else if (plantObj.Name == "pumpkin")
                    {
                        PumpkinHarvestCountInCurrentDay.Value++;
                        HarvestPumpkinCount++;
                    }
                    else if (plantObj.Name == "bean")
                    {
                        BeanHarvestCountInCurrentDay.Value++;
                        HarvestBeanCount++;
                    }
                    else if (plantObj.Name == "carrot")
                    {
                        BeanHarvestCountInCurrentDay.Value++;
                        HarvestCarrotCount++;
                    }

                }
            });

        }
        //public void LoadData()
        //{

        //}
        //public void SaveData()
        //{

        //}
        //public void ResetData()
        //{

        //}

        //public void LoadDate()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void SaveDate()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void ResetDate()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}