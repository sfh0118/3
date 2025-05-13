using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using UnityEditor.Experimental.GraphView;

namespace projectlndieFem
{
	public partial class ToolController : ViewController
	{
        private GridController mGridController;
        private Grid mGrid;
        private EasyGrid<SoilData> mShowGrid;
        private Camera mMainCamera;
        private SpriteRenderer mSprite;
        private Tilemap mTilemap;

        private void Awake()
        {
            Global.Mouse = this;
        }
        private void OnDestroy()
        {
            Global.Mouse = null;
        }
        private void Start()
        {
            mGridController = FindObjectOfType<GridController>();
            mShowGrid = mGridController.ShowGrid;

            mGrid = mGridController.GetComponent<Grid>();
            mMainCamera = Camera.main;
            mTilemap = mGridController.Tilemap;
            mSprite = GetComponent<SpriteRenderer>();
            mSprite.enabled = false;
        }

        private void Update()
		{
            var playerCellPos = mGrid.WorldToCell(Global.Player.Position());

            var worldMousePos = mMainCamera.ScreenToWorldPoint(Input.mousePosition);

            Icon.Position(worldMousePos.x + 0.5f, worldMousePos.y - 0.5f);

            var cellPos = mGrid.WorldToCell(worldMousePos);

            mSprite.enabled = false;

            if (
                cellPos.x - playerCellPos.x == -1 && cellPos.y - playerCellPos.y == 1 ||
                cellPos.x - playerCellPos.x == 0 && cellPos.y - playerCellPos.y == 1 ||
                cellPos.x - playerCellPos.x == 1 && cellPos.y - playerCellPos.y == 1 ||
                cellPos.x - playerCellPos.x == 1 && cellPos.y - playerCellPos.y == 0 ||
                cellPos.x - playerCellPos.x == 1 && cellPos.y - playerCellPos.y == -1 ||
                cellPos.x - playerCellPos.x == 0 && cellPos.y - playerCellPos.y == -1 ||
                cellPos.x - playerCellPos.x == -1 && cellPos.y - playerCellPos.y == -1 ||
                cellPos.x - playerCellPos.x == -1 && cellPos.y - playerCellPos.y == 0
                )
            {
                if (cellPos.x < 10 && cellPos.x >= 0 && cellPos.y < 10 && cellPos.y >= 0)
                {
                    //깽이 땅깨기
                    if (Global.CurrentTool.Value == Constant.TOOL_SHOVEL && mShowGrid[cellPos.x, cellPos.y] == null)
                    {
                        ShowSelect(cellPos);

                        if (Input.GetMouseButton(0))
                        {
                            //땅깨기 땅있음
                            mTilemap.SetTile(cellPos, mGridController.pen);
                            mShowGrid[cellPos.x, cellPos.y] = new SoilData();
                            AudioController.Get.SfxShoveDig.Play();
                        }
                    }
                    else if (mShowGrid[cellPos.x, cellPos.y] != null &&
                                mShowGrid[cellPos.x, cellPos.y].HasPlant != true &&
                                Global.CurrentTool.Value == Constant.TOOL_SEED)
                    {
                        if (Global.FruitSeedCount.Value > 0)
                        {

                            var gridCenterPos = ShowSelect(cellPos);

                            //씨앗 심기
                            if (Input.GetMouseButton(0))
                            {
                                Global.FruitSeedCount.Value--;
                                //씨앗심기
                                var plantGameObj = ResController.Instance.PlantPrefab
                                    .Instantiate()
                                    .Position(gridCenterPos);


                                var plant = plantGameObj.GetComponent<Plant>();

                                plant.XCell = cellPos.x;
                                plant.YCell = cellPos.y;

                                PlantController.Instance.Plants[cellPos.x, cellPos.y] = plant;
                                mShowGrid[cellPos.x, cellPos.y].HasPlant = true;

                                AudioController.Get.SfxSeed.Play();
                            }
                        }
                    }
                    else if (mShowGrid[cellPos.x, cellPos.y] != null &&
                               mShowGrid[cellPos.x, cellPos.y].HasPlant != true &&
                               Global.CurrentTool.Value == Constant.TOOL_SEED_RADISH)
                    {
                        if (Global.RadishSeedCount.Value > 0)
                        {
                            //씨앗 심기
                            //무 씨앗 심기
                            var gridCenterPos = ShowSelect(cellPos);
                            //무 씨앗 심기
                            if (Input.GetMouseButton(0))
                            {
                                Global.RadishSeedCount.Value--;
                                //씨앗심기
                                //무 씨앗심기
                                var plantGameObj = ResController.Instance.PlantRadishPrefab
                                    .Instantiate()
                                    .Position(gridCenterPos);

                                var plant = plantGameObj.GetComponent<PlantRadish>();
                                plant.XCell = cellPos.x;
                                plant.YCell = cellPos.y;

                                PlantController.Instance.Plants[cellPos.x, cellPos.y] = plant;
                                mShowGrid[cellPos.x, cellPos.y].HasPlant = true;

                                AudioController.Get.SfxSeed.Play();
                            }
                        }
                    }
                    else if (mShowGrid[cellPos.x, cellPos.y] != null &&
                                mShowGrid[cellPos.x, cellPos.y].Watered != true &&
                                Global.CurrentTool.Value == Constant.TOOL_WATERING_SCAN)
                    {

                        var gridCenterPos = ShowSelect(cellPos);
                        //물주기
                        if (Input.GetMouseButton(0))
                        {
                            //물주기
                            ResController.Instance.WaterPrefab
                                .Instantiate()
                                .Position(gridCenterPos);

                            mShowGrid[cellPos.x, cellPos.y].Watered = true;
                            AudioController.Get.SfxWater.Play();

                        }
                    }
                    else if (mShowGrid[cellPos.x, cellPos.y] != null &&
                            mShowGrid[cellPos.x, cellPos.y].HasPlant &&
                            mShowGrid[cellPos.x, cellPos.y].PlantState == PlantStates.Ripe &&
                            Global.CurrentTool.Value == Constant.TOOL_HAND)
                    {
                        ShowSelect(cellPos);

                        if (Input.GetMouseButton(0))
                        {   //수확
                            Global.OnPlantHarvest.Trigger(PlantController.Instance.Plants[cellPos.x, cellPos.y]);

                            if (PlantController.Instance.Plants[cellPos.x, cellPos.y] as Plant)
                            {
                                Global.FruitCount.Value++;

                            }else if (PlantController.Instance.Plants[cellPos.x, cellPos.y] as PlantRadish)
                            {
                                Global.RadishCount.Value++;
                            }

                            Destroy(PlantController.Instance.Plants[cellPos.x, cellPos.y].GameObject);
                            mShowGrid[cellPos.x, cellPos.y].HasPlant = false;

                            AudioController.Get.SfxHarvest.Play();
                        }

                    }
                }
            }
            else
            {
                mSprite.enabled = false;
            }
            

        }
		
        Vector3 ShowSelect(Vector3Int cellPos)
        {
            var gridOriginPos = mGrid.CellToWorld(cellPos);
            var gridCenterPos = gridOriginPos + mGrid.cellSize * 0.5f;
            transform.Position(gridCenterPos.x, gridCenterPos.y);
            mSprite.enabled = true;
            return gridCenterPos;
        }
	}
}
