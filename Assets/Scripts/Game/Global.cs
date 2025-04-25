using QFramework;
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
    }
}
