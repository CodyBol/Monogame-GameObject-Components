using Microsoft.Xna.Framework.Graphics;
using GameObjects;

namespace Component
{
    interface DrawComponent : BaseComponent
    {
        public void Draw(GameObject gameObject, SpriteBatch spriteBatch) { }
    }
}
