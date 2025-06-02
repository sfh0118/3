using UnityEngine;
using QFramework;
using System.Collections.Generic;
using System.Linq;


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
        [System.Serializable]
        public class PlantState
        {
            public PlantStates State;
            public Sprite Sprite;
            public bool ShowDigState = false;
            public int Days = 1;
        }
        public string Name;
        public List<PlantState> States = new List<PlantState>();
        

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

                var plantState = States.FirstOrDefault(s => s.State == newState);

                mState = newState;
                if (plantState != null)
                {

                    if (plantState.ShowDigState)
                    {

                    }
                    else
                    {
                        this.ClearSoilDigState();
                    }
                    GetComponent<SpriteRenderer>().sprite = plantState.Sprite;

                    FindObjectOfType<GridController>().ShowGrid[XCell, YCell].PlantState = newState;
                }


            }
        }
        private int mDayInCurrentState = 0;
        public void Grow(SoilData soilData)
        {
            if (mState == PlantStates.Ripe) return;
            if (soilData.Watered)
            {
                mDayInCurrentState++;
                var plantState = States.FirstOrDefault(s => s.State == mState);

                if (mDayInCurrentState >= plantState.Days)
                {
                    var currentStateIndex = States.FindIndex(s => s.State == mState);
                    currentStateIndex++;
                    var nexPlantState = States[currentStateIndex];
                    SetState(nexPlantState.State);
                    mDayInCurrentState = 0;
                }
            }

        }
        public int RipeDay { get; private set; }
       
        public GameObject GameObject => gameObject;
    }
}
