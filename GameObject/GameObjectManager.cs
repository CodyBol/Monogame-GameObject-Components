using Component;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameObjects
{
    static class GameObjectManager
    {
        public static List<GameObject> gameObjects;

        public static void initGameObjects()
        {
            foreach (GameObject gameObject in gameObjects.ToArray())
            {
                gameObject.initialize();
            }
        }

        public static void UpdateGameObjects() 
        {
            foreach (GameObject gameObject in gameObjects.ToArray())
            {
                gameObject.Update();
            }
        }

        public static void RenderGameObjects(SpriteBatch spriteBatch, Dictionary<string, Layer> layers) {
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

        public static void RemoveGameObject(GameObject toRemove)
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
