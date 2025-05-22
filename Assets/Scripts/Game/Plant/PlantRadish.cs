using UnityEngine;
using QFramework;


namespace projectlndieFem
{
	public partial class PlantRadish : ViewController,IPlant
	{

        public int XCell { get;  set; }
        public int YCell { get;  set; }

        private PlantStates mState = PlantStates.Seed;
        public PlantStates State => mState;

        public int RipeDay { get; private set; }
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
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SmallPlantRadishSprite;

                } else if (newState == PlantStates.Ripe)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.RipeRadishSprite;
                }
                else if (newState == PlantStates.Seed)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SeedRadishSprite;
                }
                else if (newState == PlantStates.Old)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.OldSprite;
                }

                FindObjectOfType<GridController>().ShowGrid[XCell, YCell].PlantState = newState;



            }
        }
        private int mSmallStateDay = 0;
        public void Grow(SoilData soilData)
        {
            if (State == PlantStates.Seed)
            {
                if (soilData.Watered)
                {
                    //plant에서 SmallPlant변환
                    SetState(PlantStates.Small);
                }
            }
            else if (State == PlantStates.Small)
            {
                if (soilData.Watered)
                {
                    mSmallStateDay++;

                    if (mSmallStateDay == 2)
                    {
                        //plant에서 Ripe변환
                        SetState(PlantStates.Ripe);
                    }
                    
                }
            }
        
        }

        
        public GameObject GameObject => gameObject;
    }
}
