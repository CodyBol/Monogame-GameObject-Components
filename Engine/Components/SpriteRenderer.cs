﻿using Engine.Misc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Component
{
    public class SpriteRenderer : BaseComponent, ILateInit, IDraw
    {
        public Sprite sprite;
        public float Rotation;
        public SpriteEffects SpriteEffect = SpriteEffects.None;
        public int SheetIndex;

        public SpriteRenderer(Sprite spr = null)
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
            Rotation = MathUtility.DegreesToRadian(angleDegrees);
        }

        public SpriteRenderer(Sprite spr, float angleDegrees = 0, SpriteEffects spriteEffect = SpriteEffects.None)
        {
            sprite = spr;
            Rotation = MathUtility.DegreesToRadian(angleDegrees);;
            SpriteEffect = spriteEffect;
        }
        
        
        public void LateInit()
        {
            if (GameObject.BoundingBox.Size == Vector2.Zero)
            {
                Vector2 size = Vector2.Zero;
                if (!(sprite is SpriteSheet))
                {
                    size = new Vector2(sprite.Size.Width, sprite.Size.Height);
                }
                else
                {
                    SpriteSheet sheet = sprite as SpriteSheet;
                    size = new Vector2(sheet.SpriteDimensions.Size.X, sheet.SpriteDimensions.Size.Y);
                }

                GameObject.BoundingBox.Size = size;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (sprite is SpriteSheet)
            {
                SpriteSheet sheet = sprite as SpriteSheet;
                Sprite currentSprite = sheet.Sprites[SheetIndex];
                
                Vector2 origin = new Vector2(currentSprite.Size.Width / 2, currentSprite.Size.Height / 2);
                spriteBatch.Draw(currentSprite.Texture2D, GameObject.BoundingBox.Position, currentSprite.Size, Color.White, Rotation, origin, GameObject.BoundingBox.Scale, SpriteEffect, 0f);
            }
            else
            {
                Vector2 origin = new Vector2(sprite.Size.Width / 2, sprite.Size.Height / 2);
                spriteBatch.Draw(sprite.Texture2D, GameObject.BoundingBox.Position, null, Color.White, Rotation, origin, GameObject.BoundingBox.Scale, SpriteEffect, 0f);
            }
        }
    }
}
