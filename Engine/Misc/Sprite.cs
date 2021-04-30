using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Misc
{
    public class Sprite
    {
        public Texture2D Texture2D;
        public Rectangle Size;

        public Sprite(Texture2D texture2D)
        {
            Texture2D = texture2D;
            
            Size = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
        }

        public Sprite(Texture2D texture2D, Rectangle size)
        {
            Texture2D = texture2D;
            Size = size;
        }
    }
}