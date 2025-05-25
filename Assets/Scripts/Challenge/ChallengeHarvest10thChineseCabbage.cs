namespace projectlndieFem
{
    public class ChallengeHarvest10thChineseCabbage : Challenge
    {
        public override string Name { get; } = " 10번째배추 수확하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return ChallengeController.HarvestChineseCabbageCount >= 10;
        }

        public override void OnFinish()
        {


        }
    }
}