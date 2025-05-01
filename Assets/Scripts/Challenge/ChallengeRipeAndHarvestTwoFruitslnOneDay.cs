using QFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectlndieFarm
{
    public class ChallengeRipeAndHarvestTwoFruitslnOneDay : Challenge,IUnRegisterList
    {
        public override void OnStart()
        {
            Global.OnPlantHarvest.Register(print =>
            {
                if (print.RipeDay == Global.Days.Value)
                {
                    Global.RipeAndHarvestCountInCurrentDay.Value++;
                }
            }).AddToUnregisterList(this);

          
        }
        public override bool CheckFinish()
        {
            return Global.RipeAndHarvestCountInCurrentDay.Value>= 2;
        }

        public override void OnFinish()
        {
            this.UnRegisterAll();

        }
        public List<IUnRegister> UnregisterList { get;} = new List<IUnRegister>();
    }

}
