using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;

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
            mTilemap = mGridController.Soil;
            mSprite = GetComponent<SpriteRenderer>();
            mSprite.enabled = false;
        }

       

        private ToolData mToolData = new ToolData();


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
                cellPos.x - playerCellPos.x == -1 && cellPos.y - playerCellPos.y == 0 ||
                cellPos.x - playerCellPos.x == 0 && cellPos.y - playerCellPos.y == 0
                )
            {
                if (cellPos.x < 10 && cellPos.x >= 0 && cellPos.y < 10 && cellPos.y >= 0)
                {
                    mToolData.ShowGrid = mShowGrid;
                    mToolData.CellPos = cellPos;
                    mToolData.Pen = mGridController.Pen;
                    mToolData.SoilTilemap = mTilemap;
                    //깽이 땅깨기
                    if (Global.CurrentTool.Value.Selectable(mToolData))
                    {
                        mToolData.GridCenterPos = ShowSelect(cellPos);

                        if (Input.GetMouseButton(0))
                        {
                            Global.CurrentTool.Value.Use(mToolData);
                            //땅깨기 땅있음
                           
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
