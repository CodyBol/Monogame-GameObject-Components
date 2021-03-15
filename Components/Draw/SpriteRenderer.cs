using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameObjects;
using System.Diagnostics;

namespace Component
{
    class SpriteRenderer : BaseComponent, IDraw
    {
        public Texture2D sprite;
        public float rotation;
        public SpriteEffects SpriteEffect = SpriteEffects.None;
        public Vector2 SpriteOrigin;

        public SpriteRenderer(Texture2D spr)
        {
            sprite = spr;
        }

        public SpriteRenderer(Texture2D spr, float angle)
        {
            sprite = spr;
            rotation = angle;
        }

        public SpriteRenderer(Texture2D spr, float angle = 0, SpriteEffects spriteEffect = SpriteEffects.None)
        {
            sprite = spr;
            rotation = angle;
            SpriteEffect = spriteEffect;
        }

        public override void Init(GameObject gameObject)
        {
            base.Init(gameObject);

            GameObject.size = new Vector2(sprite.Width, sprite.Height);

            SpriteOrigin = GameObject.size / 2;

            GameObject.rectangle = GameObject.NormalizeRectangle();
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(sprite, GameObject.position, null, Color.White, rotation, SpriteOrigin, GameObject.scale, SpriteEffect, 0f);
        }        
    }
}
