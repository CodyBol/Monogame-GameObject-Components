using System;
using Engine;
using Engine.Misc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameObjects;

namespace Component
{
    public class SpriteRenderer : BaseComponent, IDraw
    {
        public Sprite sprite;
        public float rotation;
        public SpriteEffects SpriteEffect = SpriteEffects.None;
        public int SheetIndex;

        public SpriteRenderer(Sprite spr)
        {
            sprite = spr;
        }

        public SpriteRenderer(SpriteSheet spr, int index)
        {
            sprite = spr;
            SheetIndex = index;
        }

        public SpriteRenderer(Sprite spr, float angleDegrees)
        {
            sprite = spr;
            rotation = MathUtility.DegreesToRadian(angleDegrees);
        }

        public SpriteRenderer(Sprite spr, float angleDegrees = 0, SpriteEffects spriteEffect = SpriteEffects.None)
        {
            sprite = spr;
            rotation = MathUtility.DegreesToRadian(angleDegrees);;
            SpriteEffect = spriteEffect;
        }

        public void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.Draw(sprite, gameObject.rectangle, Color.White);

            if (sprite is SpriteSheet)
            {
                SpriteSheet sheet = sprite as SpriteSheet;
                Sprite currentSprite = sheet.Sprites[SheetIndex];
                
                Vector2 origin = new Vector2(currentSprite.Size.Width / 2, currentSprite.Size.Height / 2);
                spriteBatch.Draw(currentSprite.Texture2D, GameObject.BoundingBox.Position, currentSprite.Size, Color.White, rotation, origin, GameObject.BoundingBox.Scale, SpriteEffect, 0f);
            }
            else
            {
                Vector2 origin = new Vector2(sprite.Size.Width / 2, sprite.Size.Height / 2);
                spriteBatch.Draw(sprite.Texture2D, GameObject.BoundingBox.Position, null, Color.White, rotation, origin, GameObject.BoundingBox.Scale, SpriteEffect, 0f);
            }
        }
    }
}
