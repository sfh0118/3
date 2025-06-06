using QFramework;
using UnityEngine;



namespace projectlndieFem
{
    public class ToolSeed : ITool,IController
    {
        public string Name { get; set; } = "seed";
        
        public ToolbarSlot Slot { get; set; }


        public int Range => Global.SeedRange1Unlock ? 2 : 1;
        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant != true &&
                   Slot.Count > 0;


        }
        public void Use(ToolData toolData)
        {
            this.SendCommand(new SubItemCountCommand(Slot.ItemId, 1));

            var itemConfig = Config.ItemForName[Slot.ItemId];

            var plantGameObj = ResController.Instance.LoadPrefab(itemConfig.PlantPrefabName)
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
