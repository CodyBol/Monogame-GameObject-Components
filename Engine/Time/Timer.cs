namespace Engine.Time
{
    public class Timer : ElapsedTime
    {
        public Timer() : base()
        {
        }

        public override float Millisec
        {
            get { return _millisec * Scale; }
            set { _millisec += value; }
        }

        public float Seconds
        {
            get { return (_millisec * Scale) / 1000; }
            set { _millisec += value * 1000; }
        }
    }
}