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
        //현재 도구
        public static BindableProperty<string> CurrentTool = new BindableProperty<string>(Constant.TOOL_HAND);

        //당일 열매수량
        public static BindableProperty<int> RipeAndHarvestCountInCurrentDay = new BindableProperty<int>(0);

        //당일 수확한 식물 수량
        public static BindableProperty<int> HarvestCountInCurrentDay = new BindableProperty<int>(0);

        public static List<Challenge> Challenges = new List<Challenge>()
        {
            new ChallengeHarvestAFruit(),
            new ChallengeRipeAndHarvestTwoFruitslnADay(),
            new ChallengeRipeAndHarvestFiveFruitslnADay(),

        };
        public static List<Challenge> ActiveChallenges = new List<Challenge>()
        {

        };

        public static List<Challenge> FinishedChallenges = new List<Challenge>()
        {

        };
        //식물 수확 
        public static EasyEvent<Plant> OnPlantHarvest= new EasyEvent<Plant>();

        public static EasyEvent<Challenge> OnChallengeFinish = new EasyEvent<Challenge>();

        public static Player Player =null;
    }

    public class Constant
    {
        public const string TOOL_HAND = "hand";
        public const string TOOL_SHOVEL = "shovel";
        public const string TOOL_SEED = "seed";
        public const string TOOL_WATERING_SCAN = "watering_scan";

        public static string DisplayName(string tool)
        {
            switch (tool)
            {
                case TOOL_HAND:
                    return "손";
                case TOOL_SHOVEL:
                    return "삽";
                case TOOL_SEED:
                    return "씨앗";
                case TOOL_WATERING_SCAN:
                    return "물뿌리개";
            }

            return string.Empty;
        }

    }
}
