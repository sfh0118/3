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

        //열매 수량
        public static BindableProperty<int> FruitCount= new BindableProperty<int>( 0);

        //
        public static BindableProperty<int> FruitSeedCount = new BindableProperty<int>(5);
      
        //무 수량
        public static BindableProperty<int> RadishCount = new BindableProperty<int>(0);
        
        //
        public static BindableProperty<int> RadishSeedCount = new BindableProperty<int>(5);

        //;
        public static BindableProperty<string> CurrentTool = new BindableProperty<string>(Constant.TOOL_HAND);


        //식물 수확 
        public static EasyEvent<IPlant> OnPlantHarvest= new EasyEvent<IPlant>();

       

        public static Player Player =null;
        public static ToolController Mouse = null;
    }

    public class Constant
    {
        public const string TOOL_HAND = "hand";
        public const string TOOL_SHOVEL = "shovel";
        public const string TOOL_SEED = "seed";
        public const string TOOL_WATERING_SCAN = "watering_scan";
        /// <summary>
        /// 씨앗 무
        /// </summary>
        public const string TOOL_SEED_RADISH = "seed_radish";

        public static string DisplayName(string tool)
        {
            switch (tool)
            {
                case TOOL_HAND:
                    return "손";
                case TOOL_SHOVEL:
                    return "깽이";
                case TOOL_SEED:
                    return "씨앗";
                case TOOL_WATERING_SCAN:
                    return "물뿌리개";
                case TOOL_SEED_RADISH:
                    return "무";
            }

            return string.Empty;
        }

    }
}
