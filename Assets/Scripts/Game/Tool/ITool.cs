﻿using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
    public interface ITool
    {
      
        string Name { get; set; }

        int Range { get;}
        bool Selectable(ToolData toolData);
        void Use(ToolData toolData);

        float HourCost { get; }
    }
    public class ToolData
    {
        public EasyGrid<SoilData> ShowGrid { get; set; }
        public Vector3Int CellPos { get; set; }
        public Tilemap SoilTilemap { get; set; }
        public TileBase Pen { get; set; }

        public Vector3 GridCenterPos { get; set; }
    }
}
