using Component;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameObjects;
using Microsoft.Xna.Framework;
using TestProject;

namespace Engine
{
    public class ObjectManager
    {
        public List<GameObject> gameObjects;
        
        public void Instantiate(GameObject obj)
        {
            obj.initialize();
            gameObjects.Add(obj);
        }

        public void initGameObjects()
        {
            foreach (GameObject gameObject in gameObjects.ToArray())
            {
                gameObject.initialize();
            }
        }

        public void UpdateGameObjects() 
        {
            foreach (GameObject gameObject in gameObjects.ToArray())
            {
                gameObject.Update();
            }
        }

        public void RenderGameObjects(SpriteBatch spriteBatch, Dictionary<string, Layer> layers) {
            foreach (KeyValuePair<string, Layer> stringLayer in layers)
            {
                foreach (GameObject gameObject in gameObjects.ToArray())
                {

                    if (stringLayer.Value == gameObject.layer)
                    {
                        gameObject.Draw(spriteBatch);
                    }
                }
            }
        }

        public void RemoveGameObject(GameObject toRemove)
        {
            int i = 0;
            foreach (GameObject gameObject in gameObjects.ToArray())
            {
                if (gameObject == toRemove)
                {
                    gameObjects.RemoveAt(i);
                    return;
                }
                i++;
            }
        }
    }
}
