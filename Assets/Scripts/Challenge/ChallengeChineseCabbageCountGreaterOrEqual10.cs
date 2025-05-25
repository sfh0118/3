namespace projectlndieFem
{
    public class ChallengeChineseCabbageCountGreaterOrEqual10 : Challenge
    {
        public override string Name { get; } = " 10개 배추 수요하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return Global.ChineseCabbageCount.Value >= 10;
        }

        public override void OnFinish()
        {


        }
    }
}