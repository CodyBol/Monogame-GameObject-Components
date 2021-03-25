using GameObjects;
using Microsoft.Xna.Framework;

namespace Component
{
    public interface ITrigger
    {
        public void triggerEnter(GameObject collision, Rectangle collideRect, Vector2 direction);
    }
}
