using UnityEngine;
using QFramework;
using projectlndieFem;
using UnityEngine.SceneManagement;


namespace projectlndieFem
{
	public partial class GamePassController : ViewController
	{
		void Start()
		{
            Global.RestData();
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
