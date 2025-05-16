using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
    public class ToolWateringCan : ITool
    {
        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].Watered != true &&
                   Global.CurrentTool.Value == Constant.TOOL_WATERING_SCAN;
                
        }
        public void Use(ToolData toolData)
        {
            //???
            ResController.Instance.WaterPrefab
                .Instantiate()
                .Position(toolData.GridCenterPos);

            toolData.ShowGrid[toolData.CellPos.x,toolData.CellPos.y].Watered = true;
            AudioController.Get.SfxWater.Play();
        }
    }


}