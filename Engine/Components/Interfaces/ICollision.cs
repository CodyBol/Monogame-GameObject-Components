using GameObjects;
using Microsoft.Xna.Framework;

namespace Component
{
    public interface ICollision
    {
        public void collisionEnter(GameObject collision, Vector2 direction);
    }
}
