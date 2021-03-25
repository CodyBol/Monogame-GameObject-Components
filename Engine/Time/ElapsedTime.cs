namespace Engine.Time
{
    public class ElapsedTime
    {
        protected float _millisec;
        protected  float _scale;

        public ElapsedTime()
        {
            Reset();
        }

        public virtual float Millisec
        {
            get { return _millisec * Scale; }
            set { _millisec = value; }
        }

        public virtual float Seconds
        {
            get { return (_millisec * Scale) / 1000; }
            set { _millisec = value * 1000; }
        }

        public float Scale => _scale;

        public void Reset(bool complete = false)
        {
            if (complete)
            {
                _millisec = 0;
                _scale = 1;
            }
        }
    }
}