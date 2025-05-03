using projectlndieFem;

namespace ProjectlndieFarm
{
    public class SoilData
    {
        public bool HasPlant { get; set; } = false;
        public bool Watered { get; set; } = false;

        public PlantStates PlantState { get; set; } = PlantStates.Seed;
      
    }
}