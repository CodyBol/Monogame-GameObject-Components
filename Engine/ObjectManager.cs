using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Engine.Component;

namespace Engine
{
    public class ObjectManager
    {
        public List<GameObject> GameObjects;
        
        public void Instantiate(GameObject obj)
        {
            obj.initialize();
            GameObjects.Add(obj);
        }

        public void initGameObjects()
        {
            foreach (GameObject gameObject in GameObjects.ToArray())
            {
                gameObject.initialize();
            }
        }

        public void UpdateGameObjects() 
        {
            foreach (GameObject gameObject in GameObjects.ToArray())
            {
                gameObject.Update();
            }
        }

        public void RenderGameObjects(SpriteBatch spriteBatch, Dictionary<string, Layer> layers) {
            foreach (KeyValuePair<string, Layer> stringLayer in layers)
            {
                foreach (GameObject gameObject in GameObjects.ToArray())
                {

                    if (stringLayer.Value == gameObject.Layer)
                    {
                        gameObject.Draw(spriteBatch);
                    }
                }
            }
        }

        public void RemoveGameObject(GameObject toRemove)
        {
            int i = 0;
            foreach (GameObject gameObject in GameObjects.ToArray())
            {
                if (gameObject == toRemove)
                {
                    GameObjects.RemoveAt(i);
                    return;
                }
                i++;
            }
        }
    }
}
