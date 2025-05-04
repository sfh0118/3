using projectlndieFem;

namespace projectlndieFem
{
    public class ChallengeHarvestFirstFruit : Challenge
    {
        public override string Name { get; } = "첫 열매 수확하기";
        public override void OnStart()
        {
            
        }
        public override bool CheckFinish()
        {
            return Global.FruitCount.Value > 0;
        }
        public override void OnFinish()
        {
            
        }

    }
}
