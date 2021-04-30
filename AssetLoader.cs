using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;
using Engine.Misc;
using Microsoft.Xna.Framework;

namespace TestProject
{
    public class AssetLoader
    {
        private Dictionary<string, Sprite> sprites;
        private Dictionary<string, SpriteFont> fonts;
        private ContentManager content;

        /**
         * creates the AssetLoader with the needed information
         */
        public AssetLoader(ContentManager Content) 
        {
            content = Content;
            clearFullLoader();
        }

        /**
         * clears the AssetLoader
         */
        public void clearFullLoader()
        {
            clearSpriteLoader();
            clearFontLoader();
        }

        /**
         * clears the AssetLoader
         */
        public void clearSpriteLoader() {
            sprites = new Dictionary<string, Sprite>();
        }

        /**
         * clears the AssetLoader
         */
        public void clearFontLoader()
        {
            fonts = new Dictionary<string, SpriteFont>();
        }

        /**
         * adds multiple fonts to the AssetLoader
         */
        public void addFontsToLoader(List<string> fontNames)
        {
            foreach (string fontName in fontNames)
            {
                addFontToLoader(fontName);
            }
        }

        /**
         * adds a single font to the AssetLoader
         */
        public void addFontToLoader(string fontName)
        {
            fonts.Add(fontName, content.Load<SpriteFont>("fonts/" + fontName));
        }

        /**
        * get a single font
        */
        public SpriteFont getFont(string fontName)
        {
            if (fonts.ContainsKey(fontName))
            {
                return fonts[fontName];
            }

            throw new Exception("The requested sprite [" + fontName + "] is not loaded in the AssetLoader");
        }

        /**
         * adds multiple sprites to the AssetLoader
         */
        public void addSpritesToLoader(List<string> spriteNames) {
            foreach (string spriteName in spriteNames)
            {
                addSpriteToLoader(spriteName);
            }
        }

        /**
         * adds a single sprite to the AssetLoader
         */
        public void addSpriteToLoader(string spriteName)
        {
            Sprite sprite = new Sprite(content.Load<Texture2D>(spriteName));
            
            sprites.Add(spriteName, sprite);
        }

        /**
         * adds a single sprite to the AssetLoader
         */
        public void AddSpriteSheetToLoader(string spriteName, Rectangle singleDimensions, Vector2 offset, SpriteSheetType type = SpriteSheetType.SpriteSheet)
        {
            SpriteSheet sheet = new SpriteSheet(content.Load<Texture2D>(spriteName), singleDimensions, offset, type);
            
            sprites.Add(spriteName, sheet);
        }

        /**
         * get a single sprite
         */
        public Sprite getSprite(string spriteName) 
        {
            if (sprites.ContainsKey(spriteName))
            {
                return sprites[spriteName];
            }

            throw new Exception("The requested sprite [" + spriteName + "] is not loaded in the AssetLoader");
        }

        /**
         * get a single sprite
         */
        public SpriteSheet getSpriteSheet(string spriteName) 
        {
            if (sprites.ContainsKey(spriteName))
            {
                return sprites[spriteName] as SpriteSheet;
            }

            throw new Exception("The requested sprite [" + spriteName + "] is not loaded in the AssetLoader");
        }
    }
}
