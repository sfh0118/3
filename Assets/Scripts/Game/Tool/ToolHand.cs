using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
    public class ToolHand : ITool
    {
        public string Name { get; set; } = "hand";
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
            }else if (PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] as PlantChineseCabbage)
            {
                Global.ChineseCabbageCount.Value++;
            }

            Object.Destroy(PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y].GameObject);
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y].HasPlant = false;

            AudioController.Get.SfxHarvest.Play();
        }
    }


}