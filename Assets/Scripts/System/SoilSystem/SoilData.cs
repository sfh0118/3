
namespace projectlndieFem
{
    public class SoilData
    {
        public bool HasPlant { get; set; } = false;
        public bool Watered { get; set; } = false;

        public string PlantName { get; set; }
        public PlantStates PlantState { get; set; } = PlantStates.Seed;

    }
}