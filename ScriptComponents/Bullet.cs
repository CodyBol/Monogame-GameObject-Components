using Microsoft.Xna.Framework;

namespace Component
{
    public class Bullet : BaseComponent, IUpdate
    {
        public void Update()
        {
            GameObject.velocity = new Vector2(0, 20);
        }
    }
}