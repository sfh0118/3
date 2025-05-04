namespace projectlndieFem
{
    public abstract class Challenge
    {
        public enum States
        {
            NotStart,
            Started,
            Finished
        }
        public States State = States.NotStart;

        public int StartDate = 0;
        public abstract string Name { get; }

        public abstract void OnStart();
        public abstract bool CheckFinish(); 

        public abstract void OnFinish();
    }
}