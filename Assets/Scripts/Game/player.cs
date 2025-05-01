using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Globalization;

namespace ProjectlndieFarm
{
	public partial class player : ViewController
	{
        public Grid Grid;
        public Tilemap Tilemap;
        void Start()
		{
            Debug.Log("@@@@@");
            Global.Days.Register( day =>
            {
          
                Global.RipeAndHarvestCountInCurrentDay.Value = 0;
                var soilDatas = FindObjectOfType<GridController>().ShowGrid;

                plantController.Instance.plants.ForEach((x,y,plant) =>
                {
                    if (plant )
                    {
                        if (plant.State == PlantStates.Seed)
                        {
                            if(soilDatas[x,y].Watered)
                            {
                                //plant에서 SmallPlant변환
                                plant.SetState(PlantStates.Small);
                            }
                        }
                        else if (plant.State == PlantStates.Small)
                        {
                            if (soilDatas[x,y].Watered)
                            {
                                //plant에서 Ripe변환
                                plant.SetState(PlantStates.Ripe);
                                
                            }
                        }
                        
                    }
                });

                soilDatas.ForEach(soilData =>
                {
                    if (soilData != null)
                    {
                        soilData.Watered = false;
                    }
                });
                foreach (var water in SceneManager.GetActiveScene().GetRootGameObjects()
                .Where(gameObj => gameObj
                .name.StartsWith("water")))
                {
                    water.DestroySelf();
                }




            }).UnRegisterWhenGameObjectDestroyed(gameObject);

		}


        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(640, 360);
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("날수 :"+ Global.Days.Value);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("열매 :" + Global.FruitCount.Value);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("물:E");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("다음날:F " );
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);

            GUILayout.Label($"지금의도구:{Constant.DisplayName(Global.CurrentTool.Value)}");
            GUILayout.EndHorizontal();

            GUILayout.FlexibleSpace();

            GUI.Label(new Rect(10, 360-24    ,200 ,24), "[1]손 [2]삽 [3]씨아 [4물뿌리개");
     


        }



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Global.Days.Value++;
            }
            var cellPosition = Grid.WorldToCell(transform.position);

            var grid = FindObjectOfType<GridController>().ShowGrid;
            var tileWorldPos = Grid.CellToWorld(cellPosition);
            tileWorldPos.x += Grid.cellSize.x * 0.5f;
            tileWorldPos.y += Grid.cellSize.y * 0.5f;

            if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
            {
                //삽
                if (Global.CurrentTool.Value == Constant.TOOL_SHOVEL && grid[cellPosition.x, cellPosition.y] == null)
                {
                    TlieSelectController.Instance.Position(tileWorldPos);
                    TlieSelectController.Instance.Show();
                }
                else if (grid[cellPosition.x, cellPosition.y] != null &&
                    grid[cellPosition.x, cellPosition.y].HasPlant != true &&
                    Global.CurrentTool.Value == Constant.TOOL_SEED)
                {
                    TlieSelectController.Instance.Position(tileWorldPos);
                    TlieSelectController.Instance.Show();
                }
                //물주기
                else if (grid[cellPosition.x, cellPosition.y] != null &&
                    grid[cellPosition.x, cellPosition.y].Watered != true &&
                    Global.CurrentTool.Value == Constant.TOOL_WATERING_SCAN)
                {
                    TlieSelectController.Instance.Position(tileWorldPos);
                    TlieSelectController.Instance.Show();
                }
                else if (grid[cellPosition.x, cellPosition.y] != null &&
                        grid[cellPosition.x, cellPosition.y].HasPlant &&
                        grid[cellPosition.x, cellPosition.y].PlantState == PlantStates.Ripe &&
                        Global.CurrentTool.Value == Constant.TOOL_HAND)
                {
                    TlieSelectController.Instance.Position(tileWorldPos);
                    TlieSelectController.Instance.Show();
                }
                else
                {
                    TlieSelectController.Instance.Hide();
                }
             
            }
            else
            {
                TlieSelectController.Instance.Hide();
            }

            if (Input.GetMouseButtonDown(0))
            {
             
                if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
                {
                    //땅업음
                    if (grid[cellPosition.x, cellPosition.y] == null &&
                        Global.CurrentTool.Value == Constant.TOOL_SHOVEL)
                    {

                        //땅있음
                        Tilemap.SetTile(cellPosition, FindObjectOfType<GridController>().pen);
                        grid[cellPosition.x, cellPosition.y] = new SoilData();
                    }
                   
                    //땅있음 씨앗씨기
                    else if (grid[cellPosition.x, cellPosition.y] != null &&
                            grid[cellPosition.x, cellPosition.y].HasPlant != true &&
                            Global.CurrentTool.Value == Constant.TOOL_SEED)
                    {
                        //씨앗심기
                        var plantGameObj = ResController.Instance.PlantPrefab
                            .Instantiate()
                            .Position(tileWorldPos);


                        var plant = plantGameObj.GetComponent<Plant>();

                        plant.XCell = cellPosition.x;
                        plant.YCell = cellPosition.y;

                        plantController.Instance.plants[cellPosition.x, cellPosition.y] = plant;
                        grid[cellPosition.x, cellPosition.y].HasPlant = true;
                    }
                    else if (grid[cellPosition.x, cellPosition.y] != null&&
                            grid[cellPosition.x, cellPosition.y].Watered != true &&
                            Global.CurrentTool.Value == Constant.TOOL_WATERING_SCAN)
                    {
                        //물주기
                        ResController.Instance.WaterPrefab
                            .Instantiate()
                            .Position(tileWorldPos);

                        grid[cellPosition.x, cellPosition.y].Watered = true;
                    }
                    //열매 따기
                    else if (grid[cellPosition.x, cellPosition.y] != null &&
                            grid[cellPosition.x, cellPosition.y].HasPlant &&
                            grid[cellPosition.x, cellPosition.y].PlantState == PlantStates.Ripe &&
                            Global.CurrentTool.Value == Constant.TOOL_HAND)
                    {
                        Global.OnPlantHarvest.Trigger(plantController.Instance.plants[cellPosition.x, cellPosition.y]);

                        if (plantController.Instance.plants[cellPosition.x, cellPosition.y].RipeDay == Global.Days.Value)
                        {
                            Global.RipeAndHarvestCountInCurrentDay.Value++;
                        }
                        Destroy(plantController.Instance.plants[cellPosition.x, cellPosition.y].gameObject);
                        grid[cellPosition.x, cellPosition.y].HasPlant = false;
                        Global.FruitCount.Value++;

                    }

                }
                

            }

            if (Input.GetMouseButtonDown(1))
            {


                if (cellPosition.x < 10 && cellPosition.x >= 0 && cellPosition.y < 10 && cellPosition.y >= 0)
                {
                    if (grid[cellPosition.x, cellPosition.y] != null)
                    {
                        Tilemap.SetTile(cellPosition, null);
                        grid[cellPosition.x, cellPosition.y] = null;
                    }
                }

            }
       
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("GamePass");
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Global.CurrentTool.Value = Constant.TOOL_HAND;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Global.CurrentTool.Value = Constant.TOOL_SHOVEL;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Global.CurrentTool.Value = Constant.TOOL_SEED;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Global.CurrentTool.Value = Constant.TOOL_WATERING_SCAN;
            }
        }
    }
}
