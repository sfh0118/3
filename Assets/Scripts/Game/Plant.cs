using UnityEngine;
using QFramework;

namespace projectlndieFem
{
	public partial class Plant : ViewController
	{

		public int XCell;
        public int YCell;

        private PlantStates mState = PlantStates.Seed;
        public PlantStates State => mState;
        //???(???)
        public int RipeDay = -1;
        public void SetState(PlantStates newState)
		{
			if (newState != mState)
            {
                if(mState == PlantStates.Small && newState == PlantStates.Ripe)
                {
                    RipeDay = Global.Days.Value;
                }
                mState = newState;

                if (newState == PlantStates.Small)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SmallplantSprite;

                } else if (newState == PlantStates.Ripe)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.RipeSprite;
                }
                else if (newState == PlantStates.Seed)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SeedSprite;
                }
                else if (newState == PlantStates.Old)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.OldSprite;
                }

                FindObjectOfType<GridController>().ShowGrid[XCell, YCell].PlantState = newState;



            }
        }

        void Start()
		{
			// Code Here
		}
	}
}
