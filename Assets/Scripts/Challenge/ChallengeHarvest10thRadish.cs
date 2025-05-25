namespace projectlndieFem
{
    public class ChallengeHarvest10thRadish : Challenge
    {
        public override string Name { get; } = " 10번째 무 수확하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return ChallengeController.HarvestedRadishCount >= 10;
        }

        public override void OnFinish()
        {


        }
    }
}