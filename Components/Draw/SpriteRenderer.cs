using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameObjects;

namespace Component
{
    class SpriteRenderer : BaseComponent, IDraw
    {
        public Texture2D sprite;
        public float rotation;

        public SpriteRenderer(Texture2D spr)
        {
            sprite = spr;
        }

        public SpriteRenderer(Texture2D spr, float angle)
        {
            sprite = spr;
            rotation = angle;
        }

        public void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.Draw(sprite, gameObject.rectangle, Color.White);

            Vector2 origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            spriteBatch.Draw(sprite, GameObject.rectangle, null, Color.White, rotation, origin, SpriteEffects.None, 0f);


        }
    }
}
