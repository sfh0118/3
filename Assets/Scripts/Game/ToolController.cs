﻿using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using DG.Tweening;

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

        bool ToolInRange(Vector3Int mouseCellPos, Vector3Int playerCellPos, int range = 1)
        {
            //range 1 3x3
            //range 2 5x5
            //range 3 7x7
            //1 + 2 * range
            var offsetCellx = -range;
            var offsetCelly = -range;
            var borderwidth = 1 + 2 * range;

            for (var i = 0; i < 1 + 2 * range; i++)
            {
                for (var j = 0; j < 1 + 2 * range; j++)
                {
                    var cellx = offsetCellx + i;
                    var celly = offsetCelly + j;

                    if (mouseCellPos.x - playerCellPos.x == cellx && mouseCellPos.y - playerCellPos.y == celly)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void Update()
        {
            var playerCellPos = mGrid.WorldToCell(Global.Player.Position());

            var worldMousePos = mMainCamera.ScreenToWorldPoint(Input.mousePosition);

            Icon.Position(worldMousePos.x + 0.5f, worldMousePos.y - 0.5f);

            var mouseCellPos = mGrid.WorldToCell(worldMousePos);

            mSprite.enabled = false;




            if (Global.CurrentTool.Value != null && ToolInRange(mouseCellPos, playerCellPos, Global.CurrentTool.Value.Range))
            {
                if (mouseCellPos.x < mShowGrid.Width && mouseCellPos.x >= 0 && mouseCellPos.y < mShowGrid.Height && mouseCellPos.y >= 0)
                {
                    mToolData.ShowGrid = mShowGrid;
                    mToolData.CellPos = mouseCellPos;
                    mToolData.Pen = mGridController.Pen;
                    mToolData.SoilTilemap = mTilemap;
                    //깽이 땅깨기
                    if (Global.CurrentTool.Value.Selectable(mToolData))
                    {
                        Icon.Alpha(1.0f);
                        if(Global.Hours.Value >= Global.CurrentTool.Value.HourCost)
                        {

                            TimeNotEnoughIcon.Hide();
                            mToolData.GridCenterPos = ShowSelect(mouseCellPos);

                            if (Input.GetMouseButton(0))
                            {
                                Global.CurrentTool.Value.Use(mToolData);
                                var rotateAngle = RandomUtility.Choose(-360, 360);
                                Icon.transform.DORotate(new Vector3(0, 0, rotateAngle), 0.3f, 
                                    RotateMode.FastBeyond360)
                                    .SetEase(Ease.OutCubic);
                                //땅깨기 땅있음
                                Global.Hours.Value -= Global.CurrentTool.Value.HourCost;

                            }
                        }
                        else
                        {

                            TimeNotEnoughIcon.Show();
                        }
                       
                    }
                    else
                    {
                        Icon.Alpha(0.5f);
                        TimeNotEnoughIcon.Hide();
                    }


                }
            }
            else
            {

                mSprite.enabled = false;
                Icon.Alpha(0.5f);
                TimeNotEnoughIcon.Hide();
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
