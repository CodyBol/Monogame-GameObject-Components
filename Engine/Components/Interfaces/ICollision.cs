using Microsoft.Xna.Framework;

namespace Engine.Component
{
    public interface ICollision
    {
        public void collisionEnter(GameObject collision, Vector2 direction);
    }
}
