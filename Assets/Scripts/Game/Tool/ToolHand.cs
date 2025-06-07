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
                var plant = PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] as Plant;
                if (plant.Name == "pumpkin")

                {
                    UIMessageQueue.Push(ResController.Instance.LoadSprite(Config.ItemForName[plant.Name].IconName), "+1");
                    this.SendCommand(new AddItemCountCommand("pumpkin", 1));
                }
                else if (plant.Name == "potato")
                {
                    UIMessageQueue.Push(ResController.Instance.LoadSprite(Config.ItemForName[plant.Name].IconName), "+1");
                    this.SendCommand(new AddItemCountCommand("potato", 1));
                }
                else if (plant.Name == "tomato")
                {
                    UIMessageQueue.Push(ResController.Instance.LoadSprite(Config.ItemForName[plant.Name].IconName), "+1");
                    this.SendCommand(new AddItemCountCommand("tomato", 1));
                }
                else if (plant.Name == "bean")
                {
                    UIMessageQueue.Push(ResController.Instance.LoadSprite(Config.ItemForName[plant.Name].IconName), "+1");
                    this.SendCommand(new AddItemCountCommand("bean", 1));
                }
                else if (plant.Name == "carrot")
                {
                    UIMessageQueue.Push(ResController.Instance.LoadSprite(Config.ItemForName[plant.Name].IconName), "+1");
                    this.SendCommand(new AddItemCountCommand("carrot", 1));
                }

                Debug.Log($"[DEBUG] Harvesting {plant.GetName()}");
                var itemConfig = Config.ItemForName[plant.GetName()];
                Debug.Log($"[DEBUG] Loaded item config: {itemConfig.IconName}");

                UIMessageQueue.Push(ResController.Instance.LoadSprite(itemConfig.IconName), "+1");
                Debug.Log($"[DEBUG] UIMessageQueue.Push called!");

                plant.Harvest();
                Debug.Log($"[DEBUG] Harvest done for {plant.GetName()}");

            }

            Object.Destroy(PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y].GameObject);
            PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = null;
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] = null;

            AudioController.Get.SfxHarvest.Play();
        }
        public float HourCost { get; } = 0.2f;
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }

}


