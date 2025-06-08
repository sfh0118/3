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
            var toolController = Object.FindObjectOfType<ToolController>();
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            toolController.WaterFx.Position(mousePos.x, mousePos.y);
            toolController.WaterFx.GetComponent<ParticleSystem>().Play();
            AudioController.Get.SfxWater.Play();
            CameraController.ShakeSlight();
            //???
            //ResController.Instance.WaterPrefab
            //    .Instantiate()
            //    .Position(toolData.GridCenterPos);

            //toolData.ShowGrid[toolData.CellPos.x,toolData.CellPos.y].Watered = true;
            //AudioController.Get.SfxWater.Play();
        }

        public float HourCost { get; } = 0.3f;
    }


}