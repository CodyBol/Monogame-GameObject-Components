using Component;
using GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Engine.Time;
using TestProject;

namespace Engine.GameStates
{
    public abstract class GameState
    {
        public bool initialized = false;
        public ObjectManager GameObjectManager;
        public ElapsedTime ElapsedTime;
        public List<Timer> Timers;

        protected Dictionary<string, Layer> layers;
        protected Camera _camera;

        public GameState()
        {
            GameObjectManager = new ObjectManager();
            ElapsedTime = new ElapsedTime();
            Timers = new List<Timer>();
        }

        public virtual void Initialize()
        {

            initialized = true;
            GameObjectManager.initGameObjects();
            Reset();
        }

        public virtual void Update(GameTime gameTime)
        {
            ElapsedTime.Millisec = (float) gameTime.ElapsedGameTime.TotalMilliseconds;

            foreach (Timer timer in Timers)
            {
                timer.Millisec = ElapsedTime.Millisec;
            }

            GameObjectManager.UpdateGameObjects();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: (_camera != null ? _camera.Transform : new Matrix()));

            GameObjectManager.RenderGameObjects(spriteBatch, layers);

            spriteBatch.End();
        }

        public virtual void Reset()
        {
            ElapsedTime.Millisec = 0;
            Timers = new List<Timer>();
        }
    }
}
