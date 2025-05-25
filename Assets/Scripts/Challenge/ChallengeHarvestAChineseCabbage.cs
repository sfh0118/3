using projectlndieFem;
using UnityEngine;

namespace projectlndieFem
{
    public class ChallengeHarvestAChineseCabbage : Challenge
    {
        public override string Name { get; } = " 배추 하나 수확하기";
        public override void OnStart()
        {

        }
        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate && ChallengeController.ChineseCabbageHarvestCountInCurrentDay.Value > 0;
        }

        public override void OnFinish()
        {


        }

    }
}
