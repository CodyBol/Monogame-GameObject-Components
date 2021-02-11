using GameObjects;

namespace Component
{
    interface UpdateComponent : BaseComponent
    {
        public void Update(GameObject gameObject) { }
    }
}
