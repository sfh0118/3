using UnityEngine;
using QFramework;


namespace projectlndieFem
{
    public interface IPlant
    {
        GameObject GameObject { get; }

        PlantStates State { get; }

        void SetState(PlantStates state);

        void Grow(SoilData soilData);

        int RipeDay { get; }
        public int XCell { get; set; }
        public int YCell { get; set; }

    }

    public static class PlantExtensions
    {
        public static void ClearSoilDigState(this IPlant self)
        {
            Object.FindObjectOfType<GridController>().Soil.SetTile(new Vector3Int(self.XCell, self.YCell), null);
        }
        
    }
    public partial class Plant : ViewController, IPlant
    {

        public int XCell { get; set; }
        public int YCell { get; set; }

        private PlantStates mState = PlantStates.Seed;
        public PlantStates State => mState;
        
        public void SetState(PlantStates newState)
        {
            if (newState != mState)
            {
                if (mState == PlantStates.Small && newState == PlantStates.Ripe)
                {
                    RipeDay = Global.Days.Value;
                }
                mState = newState;

                //
                if (newState == PlantStates.Small)
                {
                    this.ClearSoilDigState();
                    GetComponent<SpriteRenderer>().sprite = ResController.Instance.SmallPlantSprite;

                }
                else if (newState == PlantStates.Ripe)
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
                    //plant에서 Ripe변환
                    SetState(PlantStates.Ripe);

                }
            }
        }
        public int RipeDay { get; private set; }
        void Start()
        {
            // Code Here
        }
        public GameObject GameObject => gameObject;
    }
}
