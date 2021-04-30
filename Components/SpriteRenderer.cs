using System;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameObjects;

namespace Component
{
    public class SpriteRenderer : BaseComponent, IDraw
    {
        public Texture2D sprite;
        public float rotation;
        public SpriteEffects SpriteEffect = SpriteEffects.None; 

        public SpriteRenderer(Texture2D spr)
        {
            sprite = spr;
        }

        public SpriteRenderer(Texture2D spr, float angleDegrees)
        {
            sprite = spr;
            rotation = MathUtility.DegreesToRadian(angleDegrees);
        }

        public SpriteRenderer(Texture2D spr, float angleDegrees = 0, SpriteEffects spriteEffect = SpriteEffects.None)
        {
            sprite = spr;
            rotation = MathUtility.DegreesToRadian(angleDegrees);;
            SpriteEffect = spriteEffect;
        }

        public void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.Draw(sprite, gameObject.rectangle, Color.White);

            Vector2 origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            spriteBatch.Draw(sprite, GameObject.BoundingBox.Position, null, Color.White, rotation, origin, GameObject.BoundingBox.Scale, SpriteEffect, 0f);
        }
    }
}
