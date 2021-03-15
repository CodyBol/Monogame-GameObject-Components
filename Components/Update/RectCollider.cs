using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;

namespace Component
{
    class RectCollider : BaseComponent, IStart, ILateUpdate
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

        public void Start() 
        { 
        
        }

        public void LateUpdate()
        {
            if (check) {
            foreach (GameObject collide in GameObjectManager.gameObjects) {
                if (collide != GameObject && collide.layer == targetLayer && collide.hasComponent<RectCollider>()) {
                        Rectangle collideRect = collide.rectangle;
                        Rectangle gameObjectRect = GameObject.rectangle;

                        if (GameObject.rectangle.Intersects(collideRect)) {
                            if (GameObject.velocity.X < 0 && (gameObjectRect.Left >= collideRect.Left && gameObjectRect.Left <= collideRect.Right) || (gameObjectRect.X > collideRect.X && gameObjectRect.X + GameObject.velocity.X < collideRect.X))
                            {
                                bool cornerOverride = (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Left == collideRect.Right) || (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Left == collideRect.Right);

                                if (!cornerOverride)
                                {
                                    GameObject.onCollisionEnter(collide, collideRect, new Vector2(-1, 0));
                                }
                            }

                            if (GameObject.velocity.X > 0 && (gameObjectRect.Right <= collideRect.Right && gameObjectRect.Right >= collideRect.Left) || (gameObjectRect.X < collideRect.X && gameObjectRect.X + GameObject.velocity.X > collideRect.X))
                            {
                                bool cornerOverride = (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Right == collideRect.Left) || (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Right == collideRect.Left);

                                if (!cornerOverride)
                                {
                                    GameObject.onCollisionEnter(collide, collideRect, new Vector2(1, 0));
                                }
                            }

                            if (GameObject.velocity.Y > 0 && (gameObjectRect.Bottom >= collideRect.Top && gameObjectRect.Bottom <= collideRect.Bottom) || (gameObjectRect.Y < collideRect.Y && gameObjectRect.Y + GameObject.velocity.Y > collideRect.Y))
                            {
                                bool cornerOverride = (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Right == collideRect.Left) || (gameObjectRect.Bottom == collideRect.Top && gameObjectRect.Left == collideRect.Right);

                                if (!cornerOverride)
                                {
                                    GameObject.onCollisionEnter(collide, collideRect, new Vector2(0, 1));
                                }
                            }
                            else if (GameObject.velocity.Y < 0 && (gameObjectRect.Top >= collideRect.Top && gameObjectRect.Top <= collideRect.Bottom) || (gameObjectRect.Y > collideRect.Y && gameObjectRect.Y + GameObject.velocity.Y < collideRect.Y))
                            {
                                bool cornerOverride = (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Left == collideRect.Right) || (gameObjectRect.Top == collideRect.Bottom && gameObjectRect.Right == collideRect.Left);

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
