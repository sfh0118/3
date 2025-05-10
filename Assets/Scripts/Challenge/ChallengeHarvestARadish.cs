namespace projectlndieFem
{
    public class ChallengeHarvestARadish : Challenge
    {
        public override string Name => " 무 하나 수확하기";

        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate && Global.RadishHarvestCountInCurrentDay.Value > 0;
        }
        public override void OnFinish()
        {
        }
    }
}