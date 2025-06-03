namespace projectlndieFem
{
    public class ChallengeHarvest10thCarrot : Challenge
    {
        public override string Name { get; } = " 10번째당근 수확하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return ChallengeSystem.HarvestCarrotCount >= 10;
        }

        public override void OnFinish()
        {


        }
    }
}
