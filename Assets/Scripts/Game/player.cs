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

        public Font Font;

        public Rigidbody2D mRigidbody2D;
        public Animator Animator;
        private void Awake()
        {
            Global.Player = this;
            mRigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
        }

        private GUIStyle mLabelsyle;
        private GUIStyle mCoinStyle;


        void Start()
        {
            mLabelsyle = new GUIStyle("Label")
            {
                font = Font,
            };

            mCoinStyle = new GUIStyle("Label")
            {
                font = Font,
                normal = { textColor = Color.yellow },
            };

            Debug.Log("게임 시작");

            Global.Days.Register(day =>
            {
                Global.Hours.Value = Random.Range(8, 12+1);
                Global.Coin.Value -= Random.Range(10,20);
                if(Global.FirstGameFinished.Value)
                {
                    Global.Coin.Value += Random.Range(5, 15);
                }
                //다음날
                ChallengeSystem.CarrotHarvestCountInCurrentDay.Value = 0;
                ChallengeSystem.PotatoHarvestCountInCurrentDay.Value = 0;
                ChallengeSystem.TomatoHarvestCountInCurrentDay.Value = 0;
                ChallengeSystem.BeanHarvestCountInCurrentDay.Value = 0;
                ChallengeSystem.PumpkinHarvestCountInCurrentDay.Value = 0;


                //식물 상태변경
                var soilDatas = FindObjectOfType<GridController>().ShowGrid;

                PlantController.Instance.Plants.ForEach((x, y, plant) =>
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
                        Debug.Log($"[물 제거] 이전 상태: {soilData.Watered}");
                        soilData.Watered = false;
                        Debug.Log($"[물 제거] 이후 상태: {soilData.Watered}");
                    }
                });
                foreach (var water in SceneManager.GetActiveScene().GetRootGameObjects()
                .Where(gameObj => gameObj .name.StartsWith("water")))
                {
                    water.DestroySelf();
                }
                if (Global.Coin.Value < 0)
                {
                    ActionKit.Delay(2.0f, () =>
                    {
                        SceneManager.LoadScene("GameOver");
                    }).Start(this);
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

    


        private void Update()
        {
           
            var cellPosition = Grid.WorldToCell(transform.position);

            var grid = FindObjectOfType<GridController>().ShowGrid;
            var tileWorldPos = Grid.CellToWorld(cellPosition);
            tileWorldPos.x += Grid.cellSize.x * 0.5f;
            tileWorldPos.y += Grid.cellSize.y * 0.5f;


            if (Input.GetMouseButtonDown(1))
            {


                if (cellPosition.x < grid.Width && cellPosition.x >= 0 && cellPosition.y < grid.Height && cellPosition.y >= 0)
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

            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");

            var direction = new Vector2(horizontalInput, verticalInput).normalized;

            var targetVelocity = direction * 5; // Adjust speed as needed
            mRigidbody2D.velocity = Vector2.Lerp(mRigidbody2D.velocity, targetVelocity, 1 - Mathf.Exp(-Time.deltaTime * 10));

            if (horizontalInput == 0  && verticalInput == 0)
            {
                if(Animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRightWalk"))
                {
                    Animator.Play("PlayerRightIdle");
                }
                else if (Animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLeftWalk"))
                {
                    Animator.Play("PlayerLeftIdle");

                }
                if (AudioController.Get.IsWalkPlaying) 
                {
                    AudioController.Get.StopWalk();
                }

            }
            else 
            {
                if (horizontalInput > 0)
                {
                    Animator.Play("PlayerRightWalk");
                }
                else
                {
                    Animator.Play("PlayerLeftWalk");
                }
                if (!AudioController.Get.IsWalkPlaying) 
                {
                    AudioController.Get.PlayWalk();
                }
            }
        }
        private void OnDestroy()
        {
            Global.Player = null;
        }
    }
}
