using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace projectlndieFem
{
    public partial class GameOverController : ViewController
    {
        private void Start()
        {
            Global.RestData();
            //Global.Days.Value = 1;
            //Global.Coin.Value = 0;
            ////Global.FruitCount.Value = 0;
            ////Global.RadishCount.Value = 0;
            ////Global.ChineseCabbageCount.Value = 0;
            //// 게임 오버 UI 초기화
            //InitializeGameOverUI();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }
        private void InitializeGameOverUI()
        {
            // UI 초기화 코드 작성
        }
    }
}