using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace projectlndieFem
{
	public partial class GameStartController : ViewController
	{
		void Start()
		{

            Global.RestData();
            // Code Herer
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene("Game");
			}
        }
    }
}
