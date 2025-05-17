using QFramework;

namespace projectlndieFem
{
    public class ToolSeed : ITool
    {
        public string Name { get; set; } = "seed";
        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant != true &&
                   Global.FruitSeedCount.Value > 0;
        }
        public void Use(ToolData toolData) 
        {
            Global.FruitSeedCount.Value--;
            //????
            var plantGameObj = ResController.Instance.PlantPrefab
                .Instantiate()
                .Position(toolData.GridCenterPos);


            var plant = plantGameObj.GetComponent<Plant>();

            plant.XCell = toolData.CellPos.x;
            plant.YCell = toolData.CellPos.y;

            PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;

            AudioController.Get.SfxSeed.Play();
        }
    }
}