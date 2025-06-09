using DG.Tweening;
using QFramework;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Progress;


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
                var itemConfig = Config.ItemForName[plant.Name.ToLower()];

                var icon = ResController.Instance.LoadSprite(itemConfig.IconName);
               
                UIMessageQueue.Push(icon, "+1");
                this.SendCommand(new AddItemCountCommand(plant.Name.ToLower(), 1));

                //if (plant.Name == "pumpkin")

                //{
                //    UIMessageQueue.Push(icon, "+1");
                //    this.SendCommand(new AddItemCountCommand("pumpkin", 1));
                //}
                //else if (plant.Name == "potato")
                //{
                //    UIMessageQueue.Push(icon, "+1");
                //    this.SendCommand(new AddItemCountCommand("potato", 1));
                //}
                //else if (plant.Name == "tomato")
                //{
                //    UIMessageQueue.Push(icon, "+1");
                //    this.SendCommand(new AddItemCountCommand("tomato", 1));
                //}
                //else if (plant.Name == "bean")
                //{
                //    UIMessageQueue.Push(icon, "+1");
                //    this.SendCommand(new AddItemCountCommand("bean", 1));
                //}
                //else if (plant.Name == "carrot")
                //{
                //    UIMessageQueue.Push(icon, "+1");
                //    this.SendCommand(new AddItemCountCommand("carrot", 1));
                //}
                //Debug.Log($"[DEBUG] Harvesting {plant.GetName()}");
                //_ = Config.ItemForName[plant.GetName()];
                //Debug.Log($"[DEBUG] Loaded item config: {itemConfig.IconName}");

                //UIMessageQueue.Push(ResController.Instance.LoadSprite(itemConfig.IconName), "+1");
                //Debug.Log($"[DEBUG] UIMessageQueue.Push called!");

                //plant.Harvest();
                //Debug.Log($"[DEBUG] Harvest done for {plant.GetName()}");

                var uiToolbar = UnityEngine.Object.FindObjectOfType<UIToolBar>();
                var collectionIconTemplate = uiToolbar.CollectionIconTemplate;
                var PlantWorldToScreenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, toolData.GridCenterPos);
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(uiToolbar.transform as RectTransform,
                PlantWorldToScreenPoint, null, out var plantPPosInToolbar))
                {

                    collectionIconTemplate.InstantiateWithParent(uiToolbar.transform)
                    .LocalPosition(plantPPosInToolbar)
                    .Show()
                    .Self(self =>
                    {
                        var plantId = plant.ItemId;

                        //if (string.IsNullOrEmpty(plantId))
                        //{
                        //    Debug.LogError($"Plant {plant.Name} has no ItemId assigned!");
                        //    self.DestroyGameObj();
                        //    return;
                        //}

                        var toPos = uiToolbar.ToolbarSlots
                            .FirstOrDefault(slot => slot.Data != null &&
                                    string.Equals(slot.Data.ItemId, plantId, StringComparison.OrdinalIgnoreCase));

                        //if (toPos == null)
                        //{
                        //    Debug.LogWarning($"No matching toolbar slot found for expected ID: {plantId}");
                        //    self.DestroyGameObj();
                        //    return;
                        //}

                            self.sprite = icon;

                             self.transform.localScale = Vector3.one * UnityEngine.Random.Range(0.5f, 1.0f);

                         Vector3 randomOffset = (new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), 1f, 0f)).normalized * 128.0f;

                         DOTween.Sequence()
                            .Append(self.transform.DOMove(self.transform.position + randomOffset, 0.3f)
                            .SetEase(Ease.OutCubic))
                            .Append(self.transform.DOMove(toPos.transform.position, 0.2f)
                            .SetEase(Ease.InCubic))
                            .OnComplete(() => { self.DestroyGameObj(); });
                             });


                    //collectionIconTemplate.InstantiateWithParent(uiToolbar.transform)
                    //    .LocalPosition(plantPPosInToolbar)
                    //    .Show()
                    //    .Self(self =>
                    //    {
                    //        var toPos = uiToolbar.ToolbarSlots.FirstOrDefault(slot => slot.Data != null && slot.Data.ItemId == plant.ItemId);
                    //        //var plantId = plant.ItemId;
                    //        self.sprite = icon;

                    //        self.transform.localScale = Vector3.one * UnityEngine.Random.Range(0.2f, 1.0f);

                    //        self.transform.DOMove(Vector3.one, 0.5f);
                    //        DOTween.Sequence()
                    //                    .Append(self.transform.DOScale(self.transform.position +
                    //                         new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), 1, 0).normalized * 128.0f, 0.3f)
                    //                        .SetEase(Ease.OutCubic))
                    //                    .Append(self.transform.DOMove(toPos.transform.position, 0.2f)
                    //                    .SetEase(Ease.InCubic)
                    //                    .OnComplete(() => { self.DestroyGameObj(); }));

                    //    });


                }
            }

            UnityEngine.Object.Destroy(PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y].GameObject);
            PlantController.Instance.Plants[toolData.CellPos.x, toolData.CellPos.y] = null;
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] = null;


           
            AudioController.Get.SfxHarvest.Play();
            CameraController.ShakeMiddle();
            }
        public float HourCost { get; } = 0.2f;
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }

}


