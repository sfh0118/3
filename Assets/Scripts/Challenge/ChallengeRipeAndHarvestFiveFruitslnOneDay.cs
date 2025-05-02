namespace ProjectlndieFarm
{
    public class ChallengeRipeAndHarvestFiveFruitslnOneDay : Challenge
    {
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
