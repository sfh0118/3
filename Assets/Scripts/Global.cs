using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace projectlndieFem

{
    public class Global : Architecture<Global>
   
    {
        //첫날
        public static BindableProperty<int> Days = new BindableProperty<int>(Config.INIT_DAY);
        //시간
        public static BindableProperty<float> Hours = new BindableProperty<float>(10);//Config.INIT_HOURS);

        //금화(돈)코인
        public static BindableProperty<int> Coin = new BindableProperty<int>(Config.INIT_COIN);
        //시간(초단위)
        public static BindableProperty<float> FirstGameTotalHours = new BindableProperty<float>(15);
        public static BindableProperty<float> FirstGameCurrentHous = new BindableProperty<float>(0f);
        public static BindableProperty<bool> FirstGameFinished = new BindableProperty<bool>(false);


        //도구바
        public static BindableProperty<ITool> CurrentTool = new BindableProperty<ITool>(null);
        

        //식물 수확 
        public static EasyEvent<IPlant> OnPlantHarvest= new EasyEvent<IPlant>();

       

        public static Player Player =null;
        public static ToolController Mouse = null;


        public static bool HandRange1Unlock = false;
        public static bool ShovelRange1Unlock = false;
        public static bool WateringCanRange1Unlock = false;
        public static bool SeedRange1Unlock = false;

        public static void RestData()
        {
            //데이터 초기화

            Coin.Value = Config.INIT_COIN;
            Hours.Value = Config.INIT_HOURS;
            Days.Value = Config.INIT_DAY;
            //Interface.GetSystem<ISoilSystem>().ResetDate();
            //Interface.GetSystem<IChallengeSystem>().ResetDate();

        }
        public static void LoadData()
        {
            //데이터 불러오기
            Coin.Value = PlayerPrefs.GetInt(nameof(Coin), Config.INIT_COIN);
            Hours.Value = PlayerPrefs.GetFloat(nameof(Hours), Config.INIT_HOURS);
            Days.Value = PlayerPrefs.GetInt(nameof(Days), Config.INIT_DAY);
            //Interface.GetSystem<ISoilSystem>().LoadDate();
            //Interface.GetSystem<IChallengeSystem>().LoadDate();
        }
        public static void SaveData()
        {
            //데이터 저장
            PlayerPrefs.SetInt(nameof(Coin), Coin.Value);
            //PlayerPrefs.SetFloat(nameof(Hours), FruitCount.Value);
            PlayerPrefs.SetInt(nameof(Days), Days.Value);
            //Interface.GetSystem<ISoilSystem>().SaveDate();
            //Interface.GetSystem<IChallengeSystem>().SaveDate();
        }
        protected override void Init()
        {
            //this.RegisterSystem<IChallengeSystem>(new ChallengeSystem());
            //this.RegisterSystem<ISoilSystem>(new SoilSystem);
            this.RegisterSystem<IToolBarSystem>(new ToolBarSystem());

            LoadData();
            this.RegisterSystem<IToolBarSystem>(new ToolBarSystem());
            Global.Days.Register(day =>
            {
                ActionKit.NextFrame(() =>
                {

                    SaveData();
                }).StartGlobal();
            });
        }
        [RuntimeInitializeOnLoadMethod]
        public static void AutoInit()
        {
            var _ =  Global.Interface;
            Debug.Log(_.GetType().Name + ": initialized");
        }
    }

    
}
