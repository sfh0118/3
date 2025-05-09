using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Globalization;

namespace projectlndieFem
{
    public partial class Player : ViewController
    {
        public Grid Grid;
        public Tilemap Tilemap;

        private void Awake()
        {
            Global.Player = this;

        }
        void Start()
        {


            Debug.Log("@@@@@");
            Global.Days.Register(day =>
            {

                Global.RipeAndHarvestCountInCurrentDay.Value = 0;
                Global.HarvestCountInCurrentDay.Value = 0;
                //식물 상태변경
                var soilDatas = FindObjectOfType<GridController>().ShowGrid;

                PlantController.Instance.plants.ForEach((x, y, plant) =>
                {
                    if (plant != null)
                    {
                        //성장
                        plant.Grow(soilDatas[x,y]);
                    

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
            GUILayout.Label("날수 :" + Global.Days.Value);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("열매 :" + Global.FruitCount.Value);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("무 :" + Global.RadishCount.Value);
            GUILayout.EndHorizontal();



            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label("다음날:F ");
            GUILayout.EndHorizontal();

           

            GUILayout.FlexibleSpace();

            //GUI.Label(new Rect(10, 360 - 24, 200, 24), "[1]손 [2]깽이 [3]씨앗 [4]물뿌리개");



        }



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Global.Days.Value++;

                AudioController.Get.SfxNextDay.Play();
            }
            var cellPosition = Grid.WorldToCell(transform.position);

            var grid = FindObjectOfType<GridController>().ShowGrid;
            var tileWorldPos = Grid.CellToWorld(cellPosition);
            tileWorldPos.x += Grid.cellSize.x * 0.5f;
            tileWorldPos.y += Grid.cellSize.y * 0.5f;


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

            
        }
        private void OnDestroy()
        {
            Global.Player = null;
        }
    }
}