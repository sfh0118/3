using UnityEngine;
using QFramework;


namespace projectlndieFem
{
    public partial class PlantCarrot : ViewController, IPlant
    {

        public int XCell { get; set; }
        public int YCell { get; set; }

        private PlantStates mState = PlantStates.Seed;
        public PlantStates State => mState;

        public string GetName() => "carrot";

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



                if (newState == PlantStates.Seed)
                {   
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.LoadSprite("CarrotSeed");
                }
                else if (newState == PlantStates.Small)
                {

                    this.ClearSoilDigState();
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.LoadSprite("CarrotSmail");

                }
                else if (newState == PlantStates.Middle)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.LoadSprite("CarrotMiddle");
                }
                else if (newState == PlantStates.Big)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.LoadSprite("CarrotBig");
                }
                else if (newState == PlantStates.Ripe)
                {
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.LoadSprite("CarrotRipe");
                }


                FindObjectOfType<GridController>().ShowGrid[XCell, YCell].PlantState = newState;



            }
        }
        public void Grow(SoilData soilData)
        {
            if (State == PlantStates.Seed)
            {
                if (soilData.Watered)
                {
                    //plant?? SmallPlant??
                    SetState(PlantStates.Small);
                }
            }
            else if (State == PlantStates.Small)
            {
                if (soilData.Watered)
                {
                    SetState(PlantStates.Middle);
                    
                }
            }
            else if (State == PlantStates.Middle)
            {
                if (soilData.Watered)
                {
                    SetState(PlantStates.Big);
                }
            }
            else if (State == PlantStates.Big)
            {
                if (soilData.Watered)
                {
                    SetState(PlantStates.Ripe);
                    UIMessageQueue.Push(this.GetComponent<SpriteRenderer>().sprite, "수확 가능");
                }
            }


        }


        public GameObject GameObject => gameObject;
    }
}
