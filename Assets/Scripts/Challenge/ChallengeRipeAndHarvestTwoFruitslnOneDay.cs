using projectlndieFem;
using QFramework;
using System.Collections.Generic;

namespace projectlndieFem
{
    public class ChallengeRipeAndHarvestTwoFruitslnOneDay : Challenge
    {
        public override string Name { get; } = "하루에 두 개의 열매를 수확하라";
        public override void OnStart()
        {



        }
        public override bool CheckFinish()
        {
            return Global.RipeAndHarvestCountInCurrentDay.Value >= 2;
        }

        public override void OnFinish()
        {


        }
    }

}
