namespace projectlndieFem
{
    public class ChallengeRadishCountGreaterOrEqual10 : Challenge
    {
        public override string Name { get; } = " 10개 무 수요하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return Global.RadishCount.Value >= 10;
        }

        public override void OnFinish()
        {


        }
    }
}