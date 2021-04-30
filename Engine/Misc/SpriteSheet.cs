using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Misc
{
    public class SpriteSheet
    {
        public Rectangle SpriteDimensions;
        public Vector2 Offset;

        public List<Sprite> Sprites;

        public SpriteSheet(Texture2D texture2D, Rectangle spriteDimensions, Vector2 offset)
        {
            SpriteDimensions = spriteDimensions;
            Offset = offset;
            Sprites = new List<Sprite>();
            
            int maxColumns = texture2D.Width / (SpriteDimensions.Width + (int)(Offset.X * 2));
            int maxRows = texture2D.Height / (SpriteDimensions.Height + (int)(Offset.Y * 2));

            for (int row = 0; row < maxRows; row++)
            {
                for (int column = 0; column < maxColumns; column++)
                {
                    Vector2 sizeOffset = new Vector2(SpriteDimensions.Width * column, SpriteDimensions.Height * row) + new Vector2((Offset.X * 2) * column, (Offset.Y * 2) * row);
                    Sprite sprite = new Sprite() {Texture2D = texture2D, Size = new Rectangle((int)sizeOffset.X, (int)sizeOffset.Y, SpriteDimensions.Width, SpriteDimensions.Height)};
                    
                    Sprites.Add(sprite);
                }
            }
        }
    }
}