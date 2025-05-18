using QFramework;

namespace projectlndieFem
{
    public class ToolSeedChineseCabbage : ITool
    {
        public string Name { get; set; } = "Seed_Chinese_Cabbage";

        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant != true &&
                   Global.ChineseCabbageSeedCount.Value > 0;
        }
        public void Use(ToolData toolData)
        {
            Global.ChineseCabbageSeedCount.Value--;
            //????
            var plantGameObj = ResController.Instance.PlantChineseCabbagePrefab
                .Instantiate()
                .Position(toolData.GridCenterPos);


            var plant = plantGameObj.GetComponent<PlantChineseCabbage>();

            plant.XCell = toolData.CellPos.x;
            plant.YCell = toolData.CellPos.y;

            PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;

            AudioController.Get.SfxSeed.Play();
        }
    }

}