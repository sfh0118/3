using QFramework;

namespace projectlndieFem
{
    public class ToolSeedRadish : ITool
    {
        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant != true &&
                   Global.CurrentTool.Value == Constant.TOOL_SEED_RADISH &&
                   Global.RadishSeedCount.Value > 0;
        }
        public void Use(ToolData toolData)
        {
            Global.RadishSeedCount.Value--;
            //????
            var plantGameObj = ResController.Instance.PlantRadishPrefab
                .Instantiate()
                .Position(toolData.GridCenterPos);


            var plant = plantGameObj.GetComponent<PlantRadish>();

            plant.XCell = toolData.CellPos.x;
            plant.YCell = toolData.CellPos.y;

            PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;

            AudioController.Get.SfxSeed.Play();
        }
    }
}