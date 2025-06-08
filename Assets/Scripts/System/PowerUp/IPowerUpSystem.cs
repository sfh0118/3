using QFramework;
using UnityEngine;
namespace projectlndieFem
{
    public interface IPowerUpSystem : ISystem
    {
        void LoadData();
        void SaveData();
        void ResetData();
       
    }
    public class PowerUpSystem : AbstractSystem, IPowerUpSystem
    {
        protected override void OnInit()
        {
        }
        public void LoadData()
        {
            Global.HandRange1Unlock = PlayerPrefs.GetInt(nameof(Global.HandRange1Unlock), 0) == 1;
            Global.WateringCanRange1Unlock = PlayerPrefs.GetInt(nameof(Global.WateringCanRange1Unlock), 0) == 1;
            Global.ShovelRange1Unlock = PlayerPrefs.GetInt(nameof(Global.ShovelRange1Unlock), 0) == 1;
            Global.SeedRange1Unlock = PlayerPrefs.GetInt(nameof(Global.SeedRange1Unlock), 0) == 1;
        }
        public void SaveData()
        {
            PlayerPrefs.SetInt(nameof(Global.HandRange1Unlock), Global.HandRange1Unlock ? 1 : 0);
            PlayerPrefs.SetInt(nameof(Global.WateringCanRange1Unlock), Global.WateringCanRange1Unlock ? 1 : 0);
            PlayerPrefs.SetInt(nameof(Global.ShovelRange1Unlock), Global.ShovelRange1Unlock ? 1 : 0);
            PlayerPrefs.SetInt(nameof(Global.SeedRange1Unlock), Global.SeedRange1Unlock ? 1 : 0);
        }
        public void ResetData()
        {
            Global.HandRange1Unlock = false;
            Global.WateringCanRange1Unlock = false;
            Global.ShovelRange1Unlock = false;
            Global.SeedRange1Unlock = false;
            SaveData();
        }
       
    }

}