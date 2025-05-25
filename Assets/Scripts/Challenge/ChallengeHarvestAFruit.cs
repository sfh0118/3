using projectlndieFem;
using UnityEngine;

namespace projectlndieFem
{
    public class ChallengeHarvestAFruit : Challenge
    {
        public override string Name { get; } = " 열매 하나 수확하기";
        public override void OnStart()
        {
            
        }
        public override bool CheckFinish()
        {
            return Global.Days.Value != StartDate && ChallengeController.HarvestCountInCurrentDay.Value > 0;
        }

        public override void OnFinish()
        {
           

        }

    }
}
