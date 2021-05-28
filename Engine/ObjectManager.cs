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

                    if (GameMain.DevMode && (gameObject.hasComponent<RectCollider>() || gameObject.hasComponent<RectTrigger>() || gameObject.hasComponent<MouseEvent>()))
                    {
                        Texture2D collisionLine = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                        collisionLine.SetData(new[] {Color.LimeGreen});
            
                        spriteBatch.Draw(collisionLine, new Vector2(gameObject.HitBox.Left().X, gameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(gameObject.HitBox.Width(), 1), SpriteEffects.None, 0);
                        spriteBatch.Draw(collisionLine, new Vector2(gameObject.HitBox.Left().X, gameObject.HitBox.Bottom().Y), null, Color.White, 0, Vector2.Zero, new Vector2(gameObject.HitBox.Width(), 1), SpriteEffects.None, 0);
                        spriteBatch.Draw(collisionLine, new Vector2(gameObject.HitBox.Right().X, gameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(1, gameObject.HitBox.Height()), SpriteEffects.None, 0);
                        spriteBatch.Draw(collisionLine, new Vector2(gameObject.HitBox.Left().X, gameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(1, gameObject.HitBox.Height()), SpriteEffects.None, 0);
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
