using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Misc
{
    public class SpriteSheet : Sprite
    {
        public Rectangle SpriteDimensions;
        public Vector2 Offset;
        public readonly SpriteSheetType SheetType;

        public List<Sprite> Sprites;

        public SpriteSheet(Texture2D texture2D, Rectangle spriteDimensions, Vector2 offset, SpriteSheetType type = SpriteSheetType.SpriteSheet) : base(texture2D)
        {
            SpriteDimensions = spriteDimensions;
            Offset = offset;
            Sprites = new List<Sprite>();
            SheetType = type;
            
            int maxColumns = Texture2D.Width / (SpriteDimensions.Width + (int)(Offset.X));
            int maxRows = Texture2D.Height / (SpriteDimensions.Height + (int)(Offset.Y));

            for (int row = 0; row < maxRows; row++)
            {
                for (int column = 0; column < maxColumns; column++)
                {
                    Vector2 sizeOffset = new Vector2(SpriteDimensions.Width * column, SpriteDimensions.Height * row) + new Vector2(Offset.X * column + 1, Offset.Y * row + 1);
                    Sprite childSprite = new Sprite(Texture2D, new Rectangle((int)sizeOffset.X, (int)sizeOffset.Y, SpriteDimensions.Width, SpriteDimensions.Height));
                    
                    Sprites.Add(childSprite);
                }
            }
        }
    }
}