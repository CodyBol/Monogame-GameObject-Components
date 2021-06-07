using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Component
{
    public class TextRenderer : BaseComponent, IDraw
    {
        public SpriteFont Font;
        public string Content;
        public Color Color;

        public TextRenderer(SpriteFont spriteFont, string text, Color textColor)
        {
            Font = spriteFont;
            Content = text;
            Color = textColor;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(Font, Content, GameObject.BoundingBox.Position, Color);
        }
    }
}
