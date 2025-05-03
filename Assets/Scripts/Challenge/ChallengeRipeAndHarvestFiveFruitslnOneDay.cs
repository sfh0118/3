using projectlndieFem;

namespace ProjectlndieFarm
{
    public class ChallengeRipeAndHarvestFiveFruitslnOneDay : Challenge
    {
        public override string Name { get; } = "하루에 5개 열매 수확하기";
        public override void OnStart()
        {
        }
        public override bool CheckFinish()
        {
            return Global.RipeAndHarvestCountInCurrentDay.Value >= 5;
        }
        public override void OnFinish()
        {
        }
    }
}
