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
                    if (collide != gameObject && collide.layer == targetLayer && collide.hasComponent<RectCollider>())
                    {

                        Rectangle collideRect = new Rectangle(collide.rectangle.X - collide.rectangle.Width / 2,
                            collide.rectangle.Y - collide.rectangle.Height / 2,
                            collide.rectangle.Width, collide.rectangle.Height);

                        Rectangle gameObjectRect = new Rectangle(gameObject.rectangle.X - gameObject.rectangle.Width / 2,
                            gameObject.rectangle.Y - gameObject.rectangle.Height / 2,
                            gameObject.rectangle.Width, gameObject.rectangle.Height);

                        if ((collideRect.Left - gameObjectRect.Width <= gameObjectRect.Left && collideRect.Right + gameObjectRect.Width >= gameObjectRect.Right) && (collideRect.Top - gameObjectRect.Height <= gameObjectRect.Top && collideRect.Bottom + gameObjectRect.Height >= gameObjectRect.Bottom))
                        {
                            //Left collision
                            if (gameObject.velocity.X < 0 && (gameObjectRect.Left >= collideRect.Left && gameObjectRect.Left <= collideRect.Right) || (gameObjectRect.X > collideRect.X && gameObjectRect.X + gameObject.velocity.X < collideRect.X))
                            {
                                bool cornerOverride = (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Left == collideRect.Right) || (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Left == collideRect.Right);

                                if ((gameObjectRect.Bottom <= collideRect.Bottom && gameObjectRect.Left == collideRect.Right) || (gameObjectRect.Top >= collideRect.Top && gameObjectRect.Left == collideRect.Right))
                                {
                                    if (!cornerOverride)
                                    {
                                        gameObject.onTriggerEnter(collide, collideRect, new Vector2(-1, 0));
                                    }
                                }
                            }

                            //Right collision
                            if (gameObject.velocity.X > 0 && (gameObjectRect.Right <= collideRect.Right && gameObjectRect.Right >= collideRect.Left) || (gameObjectRect.X < collideRect.X && gameObjectRect.X + gameObject.velocity.X > collideRect.X))
                            {
                                bool cornerOverride = (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Right == collideRect.Left) || (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Right == collideRect.Left);

                                if ((gameObjectRect.Bottom <= collideRect.Bottom && gameObjectRect.Right <= collideRect.Left) || (gameObjectRect.Top >= collideRect.Top && gameObjectRect.Right <= collideRect.Left))
                                {
                                    if (!cornerOverride)
                                    {
                                        gameObject.onTriggerEnter(collide, collideRect, new Vector2(1, 0));
                                    }
                                }
                            }

                            //Bottom collision
                            if (gameObject.velocity.Y > 0 && (gameObjectRect.Bottom >= collideRect.Top && gameObjectRect.Bottom <= collideRect.Bottom) || (gameObjectRect.Y < collideRect.Y && gameObjectRect.Y + gameObject.velocity.Y > collideRect.Y))
                            {
                                bool cornerOverride = (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Right == collideRect.Left) || (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Left == collideRect.Right);

                                if ((gameObjectRect.Right <= collideRect.Right && gameObjectRect.Bottom <= collideRect.Top) || (gameObjectRect.Left >= collideRect.Left && gameObjectRect.Bottom <= collideRect.Top))
                                {
                                    if (!cornerOverride)
                                    {
                                        gameObject.onTriggerEnter(collide, collideRect, new Vector2(0, 1));
                                    }
                                }
                            }
                            //Top collision
                            else if (gameObject.velocity.Y < 0 && (gameObjectRect.Top >= collideRect.Top && gameObjectRect.Top <= collideRect.Bottom) || (gameObjectRect.Y > collideRect.Y && gameObjectRect.Y + gameObject.velocity.Y < collideRect.Y))
                            {
                                bool cornerOverride = (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Left == collideRect.Right) || (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Right == collideRect.Left);

                                if ((gameObjectRect.Right <= collideRect.Right && gameObjectRect.Top >= collideRect.Bottom) || (gameObjectRect.Left >= collideRect.Left && gameObjectRect.Top >= collideRect.Bottom))
                                {
                                    if (!cornerOverride)
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
    }
}
