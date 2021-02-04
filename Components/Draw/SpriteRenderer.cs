using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestProject.Component
{
    class SpriteRenderer : DrawComponent
    {
        public Texture2D sprite;

        public SpriteRenderer(Texture2D spr)
        {
            sprite = spr;
        }

        public void initialize(GameObject gameObject) {}

        public void Draw(GameObject gameObject, SpriteBatch spriteBatch) {
            spriteBatch.Draw(sprite, gameObject.rectangle, Color.White);
        }
    }
}
