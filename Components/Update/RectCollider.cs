using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestProject.Component
{
    class RectCollider : UpdateComponent
    {
        public string layer;
        private bool check;

        public RectCollider(string layerName, bool checkSelf)
        {
            if (layerName == null) {
                throw new Exception("Layer name can not be null.");
            }

            layer = layerName;
            check = checkSelf;
        }

        public void initialize(GameObject gameObject) {}

        public void Update(GameObject gameObject)
        {
            if (check) {
            foreach (GameObject collide in GameObjectManager.gameObjects) {
                if (collide != gameObject && (collide.hasComponent<RectCollider>() && collide.getComponent<RectCollider>().layer.Equals(layer))) {

                        if ((collide.rectangle.Left - gameObject.rectangle.Width <= gameObject.rectangle.Left && collide.rectangle.Right + gameObject.rectangle.Width >= gameObject.rectangle.Right) && (collide.rectangle.Top - gameObject.rectangle.Height <= gameObject.rectangle.Top && collide.rectangle.Bottom + gameObject.rectangle.Height >= gameObject.rectangle.Bottom))
                        {
                            //Left collision
                            if (gameObject.velocity.X < 0 && (gameObject.rectangle.Left >= collide.rectangle.Left && gameObject.rectangle.Left <= collide.rectangle.Right) || (gameObject.rectangle.X > collide.rectangle.X && gameObject.rectangle.X + gameObject.velocity.X < collide.rectangle.X))
                            {
                                bool cornerOverride = (gameObject.rectangle.Bottom == collide.rectangle.Top && gameObject.rectangle.Left == collide.rectangle.Right) || (gameObject.rectangle.Top == collide.rectangle.Bottom && gameObject.rectangle.Left == collide.rectangle.Right);

                                if ((gameObject.rectangle.Bottom <= collide.rectangle.Bottom && gameObject.rectangle.Left == collide.rectangle.Right) || (gameObject.rectangle.Top >= collide.rectangle.Top && gameObject.rectangle.Left == collide.rectangle.Right))
                                {
                                    if (!cornerOverride)
                                    {
                                        gameObject.onCollisionEnter(collide, new Vector2(-1, 0));
                                    }
                                }
                            }

                            //Right collision
                            if (gameObject.velocity.X > 0 && (gameObject.rectangle.Right <= collide.rectangle.Right && gameObject.rectangle.Right >= collide.rectangle.Left) || (gameObject.rectangle.X < collide.rectangle.X && gameObject.rectangle.X + gameObject.velocity.X > collide.rectangle.X))
                            {
                                bool cornerOverride = (gameObject.rectangle.Top == collide.rectangle.Bottom && gameObject.rectangle.Right == collide.rectangle.Left) || (gameObject.rectangle.Bottom == collide.rectangle.Top && gameObject.rectangle.Right == collide.rectangle.Left);

                                if ((gameObject.rectangle.Bottom <= collide.rectangle.Bottom && gameObject.rectangle.Right <= collide.rectangle.Left) || (gameObject.rectangle.Top >= collide.rectangle.Top && gameObject.rectangle.Right <= collide.rectangle.Left))
                                {
                                    if (!cornerOverride)
                                    {
                                        gameObject.onCollisionEnter(collide, new Vector2(1, 0));
                                    }
                                }
                            }

                            //Bottom collision
                            if (gameObject.velocity.Y > 0 && (gameObject.rectangle.Bottom >= collide.rectangle.Top && gameObject.rectangle.Bottom <= collide.rectangle.Bottom) || (gameObject.rectangle.Y < collide.rectangle.Y && gameObject.rectangle.Y + gameObject.velocity.Y > collide.rectangle.Y))
                            {
                                bool cornerOverride = (gameObject.rectangle.Bottom == collide.rectangle.Top && gameObject.rectangle.Right == collide.rectangle.Left) || (gameObject.rectangle.Bottom == collide.rectangle.Top && gameObject.rectangle.Left == collide.rectangle.Right);

                                if ((gameObject.rectangle.Right <= collide.rectangle.Right && gameObject.rectangle.Bottom <= collide.rectangle.Top) || (gameObject.rectangle.Left >= collide.rectangle.Left && gameObject.rectangle.Bottom <= collide.rectangle.Top))
                                {
                                    if (!cornerOverride)
                                    {
                                        gameObject.onCollisionEnter(collide, new Vector2(0, 1));
                                    }
                                }
                            }
                            //Top collision
                            else if (gameObject.velocity.Y < 0 && (gameObject.rectangle.Top >= collide.rectangle.Top && gameObject.rectangle.Top <= collide.rectangle.Bottom) || (gameObject.rectangle.Y > collide.rectangle.Y && gameObject.rectangle.Y + gameObject.velocity.Y < collide.rectangle.Y))
                            {
                                bool cornerOverride = (gameObject.rectangle.Top == collide.rectangle.Bottom && gameObject.rectangle.Left == collide.rectangle.Right) || (gameObject.rectangle.Top == collide.rectangle.Bottom && gameObject.rectangle.Right == collide.rectangle.Left);

                                if ((gameObject.rectangle.Right <= collide.rectangle.Right && gameObject.rectangle.Top >= collide.rectangle.Bottom) || (gameObject.rectangle.Left >= collide.rectangle.Left && gameObject.rectangle.Top >= collide.rectangle.Bottom))
                                {
                                    if (!cornerOverride)
                                    {
                                        gameObject.onCollisionEnter(collide, new Vector2(0, -1));
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
