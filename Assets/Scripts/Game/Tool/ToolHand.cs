using QFramework;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace projectlndieFem
{
    public class ToolHand : ITool, IController
    {
        public string Name { get; set; } = "hand";

        public int Range => Global.HandRange1Unlock ? 2 : 1;

        public bool Selectable(ToolData toolData)
        {
            return toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] != null &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant &&
                   toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].PlantState == PlantStates.Ripe;

        }
        public void Use(ToolData toolData)
        {
            Global.OnPlantHarvest.Trigger(PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y]);

            if (PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] as Plant)
            {
                Global.FruitCount.Value++;

            }
            else if (PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] as PlantRadish)
            {
                Global.RadishCount.Value++;
            }
            else if (PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] as PlantChineseCabbage)
            {
                Global.ChineseCabbageCount.Value++;
            }
            else if (PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] as PlantCarrot)
            {
                this.SendCommand(new AddItemCountCommand("carrot", 1));

            }

            Object.Destroy(PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y].GameObject);
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] = null;

            AudioController.Get.SfxHarvest.Play();
        }
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }

}


