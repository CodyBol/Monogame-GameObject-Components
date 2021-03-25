using GameObjects;
using Microsoft.Xna.Framework;

namespace Component
{
    public interface ICollision
    {
        public void collisionEnter(GameObject collision, Rectangle collideRect, Vector2 direction);
    }
}
