namespace projectlndieFem
{
    public class ChallengeCoin100 : Challenge
    {
        public override string Name { get; } = " $100벌기 ";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return Global.Coin.Value >= 100;
        }

        public override void OnFinish()
        {


        }
    }
}
