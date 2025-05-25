using QFramework;

namespace projectlndieFem
{
    public class ToolSeed : ITool
    {
        public string Name { get; set; } = "seed";
        public Item Item { get; set; }
        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant != true &&
                   Item.Count.Value > 0; 





        }
        public void Use(ToolData toolData)
        {
            Item.Count.Value--;

            var plantGameObj = ResController.Instance.LoadPrefab(Item.PlantPrefabName)
                .Instantiate()
                .Position(toolData.GridCenterPos);

            var plant = plantGameObj.GetComponent<IPlant>();

            PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;

            AudioController.Get.SfxSeed.Play();
           

        }

    }
}
//if(Item.PlantPrefabName == "Plant")
//{
//    var plantGameObj = ResController.Instance.LoadPrefab(Item.PlantPrefabName)
//        .Instantiate()
//        .Position(toolData.GridCenterPos);
//    var plant = plantGameObj.GetComponent<IPlant>();
//    PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
//    toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;
//    AudioController.Get.SfxSeed.Play();
//}
//else if (Item.PlantPrefabName == "PlantRadish")
//{
//    var plantGameObj = ResController.Instance.LoadPrefab(Item.PlantPrefabName)
//        .Instantiate()
//        .Position(toolData.GridCenterPos);
//    var plant = plantGameObj.GetComponent<IPlant>();
//    PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
//    toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;
//    AudioController.Get.SfxSeed.Play();
//}
//else if (Item.PlantPrefabName == "PlantChineseCabbage")
//{
//    var plantGameObj = ResController.Instance.LoadPrefab(Item.PlantPrefabName)
//                .Instantiate()
//                .Position(toolData.GridCenterPos);
//    var plant = plantGameObj.GetComponent<IPlant>();
//    PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
//    toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;
//    AudioController.Get.SfxSeed.Play();
//}