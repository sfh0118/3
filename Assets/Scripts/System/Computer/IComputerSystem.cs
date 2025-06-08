using QFramework;
using UnityEngine;

namespace projectlndieFem
{
    public interface IComputerSystem : ISystem
    {
        void LoadData();
        void SaveData();
        void ResetData();
    }
    public class ComputerSystem : AbstractSystem, IComputerSystem
    {
        protected override void OnInit()
        {

        }
        public void LoadData()
        {
            Global.FirstGameFinished.Value = PlayerPrefs.GetInt(nameof(Global.FirstGameFinished), 0) == 1;
            Global.FirstGameCurrentHours.Value = PlayerPrefs.GetFloat(nameof(Global.FirstGameCurrentHours.Value), 0);
        }

        public void ResetData()
        {
            PlayerPrefs.SetInt(nameof(Global.FirstGameFinished), Global.FirstGameFinished.Value ? 1 : 0);
            PlayerPrefs.SetFloat(nameof(Global.FirstGameCurrentHours.Value), Global.FirstGameCurrentHours.Value);
        }

        public void SaveData()
        {
            Global.FirstGameFinished.Value = false;
            Global.FirstGameCurrentHours.Value = 0;

            SaveData();
        }

        
    }
}