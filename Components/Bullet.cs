using Engine.Component;
using Microsoft.Xna.Framework;

namespace TestProject.Component
{
    public class Bullet : BaseComponent, IUpdate
    {
        public void Update()
        {
            GameObject.Velocity = new Vector2(0, 20);
        }
    }
}