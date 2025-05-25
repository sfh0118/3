﻿using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
    public interface ITool
    {
        Item Item { get; set; }
        string Name { get; set; }
        bool Selectable(ToolData toolData);
        void Use(ToolData toolData);
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
