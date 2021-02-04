using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace TestProject
{
    class SpriteLoader
    {
        private Dictionary<string, Texture2D> sprites;
        private ContentManager content;

        /**
         * creates the SpriteLoader with the needed information
         */
        public SpriteLoader(ContentManager Content, List<string> spriteNames) 
        {
            content = Content;
            clearLoader();

            addSpritesToLoader(spriteNames);
        }

        /**
         * clears the SpriteLoader
         */
        public void clearLoader() {
            sprites = new Dictionary<string, Texture2D>();
        }

        /**
         * adds multiple sprites to the SpriteLoader
         */
        public void addSpritesToLoader(List<string> spriteNames) {
            foreach (string spriteName in spriteNames)
            {
                addSpriteToLoader(spriteName);
            }
        }

        /**
         * adds a single sprite to the SpriteLoader
         */
        public void addSpriteToLoader(string spriteName) 
        {
            sprites.Add(spriteName, content.Load<Texture2D>(spriteName));
        }

        /**
         * get a single sprite
         */
        public Texture2D getSprite(string spriteName) 
        {
            
            return sprites[spriteName];
        }
    }
}
