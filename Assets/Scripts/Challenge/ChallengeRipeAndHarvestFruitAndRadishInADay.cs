using projectlndieFem;

namespace projectlndieFem
{

    public class ChallengeRipeAndHarvestFruitAndRadishInADay : Challenge
    {

        public override string Name { get; } = "하루에 열매와 무 수확하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate && ChallengeComtroller.RipeAndHarvestCountInCurrentDay.Value >= 1 &&
                ChallengeComtroller.RipeAndHarvestRadishCountInCurrentDay.Value >= 1;
        }
        public override void OnFinish()
        {

        }
    }
}