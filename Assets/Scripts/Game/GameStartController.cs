using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace ProjectlndieFarm
{
	public partial class GameStartController : ViewController
	{
		void Start()
		{
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
