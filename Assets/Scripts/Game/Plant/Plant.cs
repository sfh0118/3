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

        string GetName();
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
    public partial class Plant : ViewController, IPlant,IController
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
        public string GetName() => Name;
        public List<PlantState> States = new List<PlantState>();
        

        public int XCell { get; set; }
        public int YCell { get; set; }

        public PlantStates State
        {
            get => mSoilSystem.SoilGrid[XCell, YCell].PlantState; 
            private set => mSoilSystem.SoilGrid[XCell,YCell].PlantState = value; 
        }
        private ISoilSystem mSoilSystem;

        private void Awake()
        {
            mSoilSystem = this.GetSystem<ISoilSystem>();
        }

        private void OnDestroy()
        {
            mSoilSystem = null;
        }
        public void SetState(PlantStates newState)
        {
            if (State == PlantStates.Small && newState == PlantStates.Ripe)
            {
                RipeDay = Global.Days.Value;
            }

            var plantState = States.FirstOrDefault(s => s.State == newState);

            State = newState;
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

            }
        }
        private int mDayInCurrentState
        {
            get => mSoilSystem.SoilGrid[XCell, YCell].DaysInCurrentState;
            set => mSoilSystem.SoilGrid[XCell, YCell].DaysInCurrentState = value;

        }
        public void Grow(SoilData soilData)
        {
            if (State == PlantStates.Ripe) return;
            if (soilData.Watered)
            {
                mDayInCurrentState++;
                var plantState = States.FirstOrDefault(s => s.State == State);
                
                if (mDayInCurrentState >= plantState.Days)
                {
                    var currentStateIndex = States.FindIndex(s => s.State == State);
                    currentStateIndex++;
                    
                    var nexPlantState = States[currentStateIndex];
                    SetState(nexPlantState.State);

                    if(nexPlantState.State == PlantStates.Ripe)
                    {
                        UIMessageQueue.Push(this.GetComponent<SpriteRenderer>().sprite,"수확 가능");
                    }
                    mDayInCurrentState = 0;
                }
            }

        }

        

        public int RipeDay { get; private set; }
       
        public GameObject GameObject => gameObject;
        public IArchitecture GetArchitecture()
        {
            return Global.Interface;
        }
    }
}
