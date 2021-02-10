using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestProject.Component
{
    class TextRenderer : DrawComponent
    {
        public SpriteFont font;
        public string content;
        public Color color;

        public TextRenderer(SpriteFont spriteFont, string text, Color textColor)
        {
            font = spriteFont;
            content = text;
            color = textColor;
        }

        public void initialize(GameObject gameObject) {}

        public void Draw(GameObject gameObject, SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, content, gameObject.rectangle.Location.ToVector2(), color);
        }
    }
}
