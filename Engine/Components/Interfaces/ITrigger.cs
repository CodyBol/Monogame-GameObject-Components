using GameObjects;
using Microsoft.Xna.Framework;

namespace Component
{
    public interface ITrigger
    {
        public void triggerEnter(GameObject collision);
    }
}
