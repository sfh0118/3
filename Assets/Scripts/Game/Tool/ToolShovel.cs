using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
    public class ToolShovel : ITool
    {
        public string Name { get; set; } = "shovel";


        public int Range => Global.ShovelRangelUnlock ? 2 : 1;

        public bool Selectable(ToolData toolData)
        {
            return  toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] == null;
        }
        public void Use(ToolData toolData)
        {
            toolData.SoilTilemap.SetTile(toolData.CellPos, toolData.Pen);
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] = new SoilData();
            AudioController.Get.SfxShoveDig.Play();

        }
    }
    

}