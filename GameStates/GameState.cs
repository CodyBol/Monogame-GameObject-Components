using Component;
using GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStates
{
    abstract class GameState
    {
        public virtual void Initialize()
        {
            GameObjectManager.initGameObjects();
        }

        public virtual void Update(GameTime gameTime)
        {
            GameObjectManager.UpdateGameObjects();
        }

        public virtual void Draw(SpriteBatch _spriteBatch, Dictionary<string, Layer> layers)
        {
            GameObjectManager.RenderGameObjects(_spriteBatch, layers);
        }
    }
}
