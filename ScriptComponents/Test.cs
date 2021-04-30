using System;
using Engine;
using Engine.Misc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameObjects;

namespace Component
{
    public class Test : BaseComponent, IDraw
    {
        public Sprite sprite;
        public float SheetOffset;
        public Vector2 SheetIndividualSize;
        
        public float rotation;
        public SpriteEffects SpriteEffect = SpriteEffects.None; 

        public Test(Sprite spr)
        {
            sprite = spr;
        }

        public void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.Draw(sprite, gameObject.rectangle, Color.White);

            Vector2 origin = new Vector2(sprite.Size.Width / 2, sprite.Size.Height / 2);
            spriteBatch.Draw(sprite.Texture2D, GameObject.BoundingBox.Position, sprite.Size, Color.White, rotation, origin, GameObject.BoundingBox.Scale, SpriteEffect, 0f);


        }
    }
}