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
        public static BindableProperty<int> Days = new BindableProperty<int>(defaultValue:1);

        //열매 수량
        public static BindableProperty<int> FruitCount= new BindableProperty<int>(defaultValue: 0);

        public static BindableProperty<string> CurrentTool = new BindableProperty<string>(Constant.TOOL_HAND);
    }

    public class Constant
    {
        public const string TOOL_HAND = "hand";
        public const string TOOL_SHOVEL = "shovel";
        public const string TOOL_SEED = "seed";

        public static string DisplayName(string tool)
        {
            switch (tool)
            {
                case TOOL_HAND:
                    return "손";
                case TOOL_SHOVEL:
                    return "삽";
                case TOOL_SEED:
                    return "씨아";
            }

            return string.Empty;
        }

        internal static object DisplayName(BindableProperty<string> currentTool)
        {
            throw new NotImplementedException();
        }
    }
}
