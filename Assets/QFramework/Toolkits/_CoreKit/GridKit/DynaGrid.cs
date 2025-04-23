/****************************************************************************
 * Copyright (c) 2016 ~ 2024 liangxiegame UNDER MIT License
 *
 * https://qframework.cn
 * https://github.com/liangxiegame/QFramework
 ****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example
{
    public class DynaGrid : MonoBehaviour
    {
        void Start()
        {
            var grid = new EasyGrid<string>(4, 4);

            grid.Fill("빈칸");
            grid[2, 3] = "안녕하세요";
            grid.ForEach((x, y, content) => Debug.Log($"({x},{y}):{content}"));

            grid.Clear();

        }
    }
}
