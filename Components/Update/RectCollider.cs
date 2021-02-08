using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestProject.Component
{
    class RectCollider : UpdateComponent
    {
        public Rectangle RectangleHitBox;

        public RectCollider(Rectangle hitBox)
        {
            RectangleHitBox = hitBox;
        }

        public void initialize(GameObject gameObject) {}

        public void Update(GameObject gameObject)
        {

            foreach (GameObject collide in GameObjectManager.gameObjects) {
                if (collide != gameObject) {

                    if ((collide.rectangle.Left - gameObject.rectangle.Width <= gameObject.rectangle.Left && collide.rectangle.Right + gameObject.rectangle.Width >= gameObject.rectangle.Right) && (collide.rectangle.Top - gameObject.rectangle.Height <= gameObject.rectangle.Top && collide.rectangle.Bottom + gameObject.rectangle.Height >= gameObject.rectangle.Bottom))
                    {
                        //Left collision
                        if (gameObject.velocity.X < 0 && (gameObject.rectangle.Left >= collide.rectangle.Left && gameObject.rectangle.Left <= collide.rectangle.Right) || (gameObject.rectangle.X > collide.rectangle.X && gameObject.rectangle.X + gameObject.velocity.X < collide.rectangle.X))
                        {
                            if ((gameObject.rectangle.Bottom <= collide.rectangle.Bottom && gameObject.rectangle.Left >= collide.rectangle.Right) || gameObject.rectangle.Top >= collide.rectangle.Top && (gameObject.rectangle.Left >= collide.rectangle.Right)) {
                                gameObject.rectangle.X = collide.rectangle.Right;
                                gameObject.velocity.X = 0;
                            }
                        }

                        //Right collision
                        if (gameObject.velocity.X > 0 && (gameObject.rectangle.Right <= collide.rectangle.Right && gameObject.rectangle.Right >= collide.rectangle.Left) || (gameObject.rectangle.X < collide.rectangle.X && gameObject.rectangle.X + gameObject.velocity.X > collide.rectangle.X))
                        {
                            if ((gameObject.rectangle.Bottom <= collide.rectangle.Bottom && gameObject.rectangle.Right <= collide.rectangle.Left) || (gameObject.rectangle.Top >= collide.rectangle.Top && gameObject.rectangle.Right <= collide.rectangle.Left))
                            {
                                gameObject.rectangle.X = collide.rectangle.Left - gameObject.rectangle.Width;
                                gameObject.velocity.X = 0;
                            }
                        }

                        //Bottom collision
                        if (gameObject.velocity.Y > 0 && (gameObject.rectangle.Bottom >= collide.rectangle.Top && gameObject.rectangle.Bottom <= collide.rectangle.Bottom) || (gameObject.rectangle.Y < collide.rectangle.Y && gameObject.rectangle.Y + gameObject.velocity.Y > collide.rectangle.Y))
                        {
                            if ((gameObject.rectangle.Right <= collide.rectangle.Right && gameObject.rectangle.Bottom <= collide.rectangle.Top) || (gameObject.rectangle.Left >= collide.rectangle.Left && gameObject.rectangle.Bottom <= collide.rectangle.Top))
                            {
                                gameObject.velocity.Y = 0;
                                gameObject.rectangle.Y = collide.rectangle.Top - gameObject.rectangle.Height;
                            }
                        }
                        //Top collision
                        else if (gameObject.velocity.Y < 0 && (gameObject.rectangle.Top >= collide.rectangle.Top && gameObject.rectangle.Top <= collide.rectangle.Bottom) || (gameObject.rectangle.Y > collide.rectangle.Y && gameObject.rectangle.Y + gameObject.velocity.Y < collide.rectangle.Y))
                        {
                            if ((gameObject.rectangle.Right <= collide.rectangle.Right && gameObject.rectangle.Top >= collide.rectangle.Bottom) || (gameObject.rectangle.Left >= collide.rectangle.Left && gameObject.rectangle.Top >= collide.rectangle.Bottom))
                            {
                                gameObject.velocity.Y = 0;
                                gameObject.rectangle.Y = collide.rectangle.Bottom;
                            }
                        }
                    }
                }
            }

            gameObject.rectangle.X += (int)gameObject.velocity.X;
            gameObject.rectangle.Y += (int)gameObject.velocity.Y;
        }
    }
}
