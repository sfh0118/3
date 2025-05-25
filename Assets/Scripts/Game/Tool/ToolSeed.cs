using QFramework;
using UnityEngine;



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
            plant.XCell = toolData.CellPos.x;
            plant.YCell = toolData.CellPos.y;

            PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;

            AudioController.Get.SfxSeed.Play();


        }

    }
}
