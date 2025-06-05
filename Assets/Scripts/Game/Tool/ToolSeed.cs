using QFramework;
using UnityEngine;



namespace projectlndieFem
{
    public class ToolSeed : ITool,IController
    {
        public string Name { get; set; } = "seed";
        
        public Item Item { get; set; }


        public int Range => Global.SeedRange1Unlock ? 2 : 1;
        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant != true &&
                   Item.Count.Value > 0;


        }
        public void Use(ToolData toolData)
        {
            this.SendCommand(new SubItemCountCommand(Item.Name, 1));

            var plantGameObj = ResController.Instance.LoadPrefab(Item.PlantPrefabName)
                .Instantiate()
                .Position(toolData.GridCenterPos);

            var plant = plantGameObj.GetComponent<IPlant>();
            plant.XCell = toolData.CellPos.x;
            plant.YCell = toolData.CellPos.y;

            PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = plant;
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = true;

            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].PlantName = plant.GetName();
            AudioController.Get.SfxSeed.Play();


        }
        public float HourCost { get; } = 0.2f;
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }

    }
}
