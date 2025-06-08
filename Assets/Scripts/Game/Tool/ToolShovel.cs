using DG.Tweening;
using QFramework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace projectlndieFem
{
    public class ToolShovel : ITool
    {
        public string Name { get; set; } = "shovel";


        public int Range => Global.ShovelRange1Unlock ? 2 : 1;

        public bool Selectable(ToolData toolData)
        {
            return  toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] == null;
        }
        public void Use(ToolData toolData)
        {
            toolData.SoilTilemap.SetTile(toolData.CellPos, toolData.Pen);
            toolData.ShowGrid[toolData.CellPos.x, toolData.CellPos.y] = new SoilData();
            AudioController.Get.SfxShoveDig.Play();

            var toolController = Object.FindObjectOfType<ToolController>();
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            toolController.DigFx.Position(mousePos.x, mousePos.y);
            toolController.DigFx.GetComponent<ParticleSystem>().Play();
            CameraController.ShakeHeavy();

        }

        public float HourCost { get; } = 0.5f;
    }
    

}