using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace projectlndieFem

{
    public class Global
    {
        //첫날
        public static BindableProperty<int> Days = new BindableProperty<int>(1);

        //금화(돈)코인
        public static BindableProperty<int> Coin = new BindableProperty<int>();

        //열매 수량
        public static BindableProperty<int> FruitCount= new BindableProperty<int>( 0);

        //
        public static BindableProperty<int> FruitSeedCount = new BindableProperty<int>(5);
      
        //무 수량
        public static BindableProperty<int> RadishCount = new BindableProperty<int>(0);
        public static BindableProperty<int> ChineseCabbageCount = new BindableProperty<int>(0);

        //지금 도구
        public static BindableProperty<ITool> CurrentTool = new BindableProperty<ITool>(Config.Items[0].Tool);


        //식물 수확 
        public static EasyEvent<IPlant> OnPlantHarvest= new EasyEvent<IPlant>();

       

        public static Player Player =null;
        public static ToolController Mouse = null;


        public static bool HandRange1Unlock = false;
        public static bool ShovelRange1Unlock = false;
        public static bool WateringCanRange1Unlock = false;
        public static bool SeedRange1Unlock = false;
    }

    
}
