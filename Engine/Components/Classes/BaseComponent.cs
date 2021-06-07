namespace Engine.Component
{
    public abstract class BaseComponent
    {
        protected GameObject GameObject;

        public virtual void Init(GameObject gameObject) 
        {
            GameObject = gameObject;
        }
    }
}
