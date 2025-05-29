using UnityEngine;
using QFramework;


namespace projectlndieFem
{
    public partial class PlantChineseCabbage : ViewController, IPlant        
    {

        public int XCell { get; set; }
        public int YCell { get; set; }

        private PlantStates mState = PlantStates.Seed;
        public PlantStates State => mState;

        public int RipeDay { get; private set; }
        public void SetState(PlantStates newState)
        {
            if (newState != mState)
            {
                if (mState == PlantStates.Small && newState == PlantStates.Ripe)
                {
                    RipeDay = Global.Days.Value;
                }
                mState = newState;

                if (newState == PlantStates.Small)
                {
                    this.ClearSoilDigState();
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SmallPlantChineseCabbageSprite;

                }
                else if (newState == PlantStates.Ripe)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.RipeChineseCabbageSprite;
                }
                else if (newState == PlantStates.Seed)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SeedChineseCabbageSprite;
                }
                else if (newState == PlantStates.Old)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.OldSprite;
                }

                FindObjectOfType<GridController>().ShowGrid[XCell, YCell].PlantState = newState;



            }
        }

        private int mSeedStateDay = 0;
        private int mSmallStateDay = 0;
        public void Grow(SoilData soilData)
        {
            if (State == PlantStates.Seed)
            {
                if (soilData.Watered)
                {
                    mSeedStateDay++;
                    if (mSeedStateDay == 2)
                    {
                        //plant?? SmallPlant??
                        SetState(PlantStates.Small);
                    }
                }
            }
            else if (State == PlantStates.Small)
            {
                if (soilData.Watered)
                {
                    mSmallStateDay++;

                    if (mSmallStateDay == 2)
                    {
                        //plant?? Ripe??
                        SetState(PlantStates.Ripe);
                    }

                }
            }

        }


        public GameObject GameObject => gameObject;
    }
}
