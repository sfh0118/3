namespace projectlndieFem
{
    public class ChallengeHarvest10thFruit : Challenge
    {
        public override string Name { get; } = " 10번째 열매 수확하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return ChallengeController.HarvestedFruitCount >= 10;
        }

        public override void OnFinish()
        {


        }
    }
}
