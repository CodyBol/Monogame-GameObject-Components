using Microsoft.Xna.Framework.Graphics;

namespace TestProject.Component
{
    interface DrawComponent : BaseComponent
    {
        public void Draw(GameObject gameObject, SpriteBatch spriteBatch) { }
    }
}
