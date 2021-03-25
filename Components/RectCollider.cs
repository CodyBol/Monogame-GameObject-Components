using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Engine;
using GameObjects;

namespace Component
{
    public class RectCollider : BaseComponent, IUpdate
    {
        public Layer targetLayer;
        private bool check;

        public RectCollider(Layer layer, bool checkSelf)
        {
            if (layer == null) {
                throw new Exception("Layer name can not be null.");
            }

            targetLayer = layer;
            check = checkSelf;
        }

        public void Update()
        {
            if (check) {
            foreach (GameObject collide in GameCore.GameObjectManager.gameObjects.ToArray()) {
                if (collide != GameObject && collide.layer == targetLayer && collide.hasComponent<RectCollider>()) {

                        Rectangle collideRect = collide.getRealRect();
                        Rectangle gameObjectRect = GameObject.getRealRect();

                        if ((collideRect.Left - gameObjectRect.Width <= gameObjectRect.Left && collideRect.Right + gameObjectRect.Width >= gameObjectRect.Right) && (collideRect.Top - gameObjectRect.Height <= gameObjectRect.Top && collideRect.Bottom + gameObjectRect.Height >= gameObjectRect.Bottom))
                        {
                            //Left collision
                            if (GameObject.velocity.X < 0 && (gameObjectRect.Left >= collideRect.Left && gameObjectRect.Left <= collideRect.Right) || (gameObjectRect.X > collideRect.X && gameObjectRect.X + GameObject.velocity.X < collideRect.X))
                            {
                                bool cornerOverride = (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Left == collideRect.Right) || (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Left == collideRect.Right);

                                if ((gameObjectRect.Bottom <= collideRect.Bottom && gameObjectRect.Left == collideRect.Right) || (gameObjectRect.Top >= collideRect.Top && gameObjectRect.Left == collideRect.Right))
                                {
                                    if (!cornerOverride)
                                    {
                                        GameObject.onCollisionEnter(collide, collideRect, new Vector2(-1, 0));
                                    }
                                }
                            }

                            //Right collision
                            if (GameObject.velocity.X > 0 && (gameObjectRect.Right <= collideRect.Right && gameObjectRect.Right >= collideRect.Left) || (gameObjectRect.X < collideRect.X && gameObjectRect.X + GameObject.velocity.X > collideRect.X))
                            {
                                bool cornerOverride = (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Right == collideRect.Left) || (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Right == collideRect.Left);

                                if ((gameObjectRect.Bottom <= collideRect.Bottom && gameObjectRect.Right <= collideRect.Left) || (gameObjectRect.Top >= collideRect.Top && gameObjectRect.Right <= collideRect.Left))
                                {
                                    if (!cornerOverride)
                                    {
                                        GameObject.onCollisionEnter(collide, collideRect, new Vector2(1, 0));
                                    }
                                }
                            }

                            //Bottom collision
                            if (GameObject.velocity.Y > 0 && (gameObjectRect.Bottom >= collideRect.Top && gameObjectRect.Bottom <= collideRect.Bottom) || (gameObjectRect.Y < collideRect.Y && gameObjectRect.Y + GameObject.velocity.Y > collideRect.Y))
                            {
                                bool cornerOverride = (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Right == collideRect.Left) || (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Left == collideRect.Right);

                                if ((gameObjectRect.Right <= collideRect.Right && gameObjectRect.Bottom <= collideRect.Top) || (gameObjectRect.Left >= collideRect.Left && gameObjectRect.Bottom <= collideRect.Top))
                                {
                                    if (!cornerOverride)
                                    {
                                        GameObject.onCollisionEnter(collide, collideRect, new Vector2(0, 1));
                                    }
                                }
                            }
                            //Top collision
                            else if (GameObject.velocity.Y < 0 && (gameObjectRect.Top >= collideRect.Top && gameObjectRect.Top <= collideRect.Bottom) || (gameObjectRect.Y > collideRect.Y && gameObjectRect.Y + GameObject.velocity.Y < collideRect.Y))
                            {
                                bool cornerOverride = (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Left == collideRect.Right) || (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Right == collideRect.Left);

                                if ((gameObjectRect.Right <= collideRect.Right && gameObjectRect.Top >= collideRect.Bottom) || (gameObjectRect.Left >= collideRect.Left && gameObjectRect.Top >= collideRect.Bottom))
                                {
                                    if (!cornerOverride)
                                    {
                                        GameObject.onCollisionEnter(collide, collideRect, new Vector2(0, -1));
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
