using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
    public class ToolWateringCan : ITool
    {
        public string Name { get; set; } = "watering_can";

        public int Range => Global.WateringCanRange1Unlock ? 2 : 1;


        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].Watered != true ;
                
        }
        public void Use(ToolData toolData)
        {

            var water = ResController.Instance.WaterPrefab
                .Instantiate()
                .Position(toolData.GridCenterPos);

            water.name = "water"; 

            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].Watered = true;
            AudioController.Get.SfxWater.Play();
            //???
            //ResController.Instance.WaterPrefab
            //    .Instantiate()
            //    .Position(toolData.GridCenterPos);

            //toolData.ShowGrid[toolData.CellPos.x,toolData.CellPos.y].Watered = true;
            //AudioController.Get.SfxWater.Play();
        }
    }


}