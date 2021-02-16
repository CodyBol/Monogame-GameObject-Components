using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;

namespace Component
{
    class RectTrigger : UpdateComponent
    {
        public Layer targetLayer;
        private bool check;

        public RectTrigger(Layer layer, bool checkSelf)
        {
            if (layer == null)
            {
                throw new Exception("Layer name can not be null.");
            }

            targetLayer = layer;
            check = checkSelf;
        }

        public void initialize(GameObject gameObject) { }

        public void Update(GameObject gameObject)
        {
            if (check)
            {
                foreach (GameObject collide in GameObjectManager.gameObjects)
                {
                    if (collide != gameObject && collide.layer == targetLayer && collide.hasComponent<RectTrigger>())
                    {

                        Rectangle collideRect = collide.getRealRect();
                        Rectangle gameObjectRect = gameObject.getRealRect();

                        if ((collideRect.Left - gameObjectRect.Width <= gameObjectRect.Left && collideRect.Right + gameObjectRect.Width >= gameObjectRect.Right) && (collideRect.Top - gameObjectRect.Height <= gameObjectRect.Top && collideRect.Bottom + gameObjectRect.Height >= gameObjectRect.Bottom))
                        {

                            //Left collision
                            if ((gameObjectRect.Left >= collideRect.Left && gameObjectRect.Left <= collideRect.Right) || (gameObjectRect.X > collideRect.X && gameObjectRect.X + gameObject.velocity.X < collideRect.X))
                            {
                                gameObject.onTriggerEnter(collide, collideRect, new Vector2(-1, 0));
                            }

                            //Right collision
                            if ((gameObjectRect.Right <= collideRect.Right && gameObjectRect.Right >= collideRect.Left) || (gameObjectRect.X < collideRect.X && gameObjectRect.X + gameObject.velocity.X > collideRect.X))
                            {
                                gameObject.onTriggerEnter(collide, collideRect, new Vector2(1, 0));

                            }

                            //Bottom collision
                            if ((gameObjectRect.Bottom >= collideRect.Top && gameObjectRect.Bottom <= collideRect.Bottom) || (gameObjectRect.Y < collideRect.Y && gameObjectRect.Y + gameObject.velocity.Y > collideRect.Y))
                            {
                                gameObject.onTriggerEnter(collide, collideRect, new Vector2(0, 1));
                            }
                            //Top collision
                            else if ((gameObjectRect.Top >= collideRect.Top && gameObjectRect.Top <= collideRect.Bottom) || (gameObjectRect.Y > collideRect.Y && gameObjectRect.Y + gameObject.velocity.Y < collideRect.Y))
                            {
                                gameObject.onTriggerEnter(collide, collideRect, new Vector2(0, -1));
                            }
                        }
                    }
                }
            }
        }
    }
}
