using projectlndieFem;

namespace projectlndieFem
{
    public class ChallengeHarvestAFruit : Challenge
    {
        public override string Name { get; } = "첫 열매 수확하기";
        public override void OnStart()
        {
            
        }
        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate && Global.HarvestCountInCurrentDay.Value > 0;
        }
        public override void OnFinish()
        {
            
        }

    }
}
