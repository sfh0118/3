namespace projectlndieFem
{
    public class ChallengeHarvestACarrot : Challenge
    {
        public override string Name { get; } = "당근 하나 수확하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate && ChallengeController.CarrotHarvestCountInCurrentDay.Value > 0;
        }

        public override void OnFinish()
        {


        }
    }
    
}