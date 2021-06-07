using Microsoft.Xna.Framework;

namespace Engine.Component
{
    public interface ICollision
    {
        public void CollisionEnter(GameObject collision, Vector2 direction);
    }
}
