namespace projectlndieFem
{
    public class ChallengeFruitCountGreaterOrEqual10 : Challenge
    {
        public override string Name { get; } = " 10개 열매 수요하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return Global.FruitCount.Value >= 10;
        }

        public override void OnFinish()
        {


        }
    }
}