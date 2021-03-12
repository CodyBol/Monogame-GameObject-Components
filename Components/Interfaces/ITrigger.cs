using GameObjects;
using Microsoft.Xna.Framework;

namespace Component
{
    interface ITrigger
    {
        public void triggerEnter(GameObject collision, Rectangle collideRect, Vector2 direction);
    }
}
