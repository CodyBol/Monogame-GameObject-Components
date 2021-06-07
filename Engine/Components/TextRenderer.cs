﻿

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Component
{
    public class TextRenderer : BaseComponent, IDraw
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

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, content, GameObject.BoundingBox.Position, color);
        }
    }
}
