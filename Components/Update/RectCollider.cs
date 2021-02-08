using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestProject.Component
{
    class RectCollider : UpdateComponent
    {
        public Rectangle RectangleHitBox;
        private Vector2 prevCollision;

        public RectCollider(Rectangle hitBox)
        {
            RectangleHitBox = hitBox;
            prevCollision = Vector2.Zero;
        }

        public void initialize(GameObject gameObject) {}

        public void Update(GameObject gameObject)
        {

            foreach (GameObject collide in GameObjectManager.gameObjects) {
                if (collide != gameObject) {

                    prevCollision = Vector2.Zero;

                    if ((collide.rectangle.Left - gameObject.rectangle.Width <= gameObject.rectangle.Left && collide.rectangle.Right + gameObject.rectangle.Width >= gameObject.rectangle.Right) && (collide.rectangle.Top - gameObject.rectangle.Height <= gameObject.rectangle.Top && collide.rectangle.Bottom + gameObject.rectangle.Height >= gameObject.rectangle.Bottom))
                    {
                        //Left collision
                        if (gameObject.velocity.X < 0 && (gameObject.rectangle.Left >= collide.rectangle.Left && gameObject.rectangle.Left <= collide.rectangle.Right) || (gameObject.rectangle.X > collide.rectangle.X && gameObject.rectangle.X + gameObject.velocity.X < collide.rectangle.X))
                        {
                            //prevCollision.X = -1;
                            gameObject.velocity.X = 0;
                            gameObject.rectangle.X = collide.rectangle.Right;
                            Debug.WriteLine("coll left");
                        }

                        //Right collision
                        if (gameObject.velocity.X > 0 && (gameObject.rectangle.Right <= collide.rectangle.Right && gameObject.rectangle.Right >= collide.rectangle.Left) || (gameObject.rectangle.X < collide.rectangle.X && gameObject.rectangle.X + gameObject.velocity.X > collide.rectangle.X))
                        {
                            //prevCollision.X = 1;
                            gameObject.velocity.X = 0;
                            gameObject.rectangle.X = collide.rectangle.Left - gameObject.rectangle.Width;
                            Debug.WriteLine("coll right");
                        }

                        //Bottom collision
                        if (gameObject.velocity.Y > 0 && (gameObject.rectangle.Bottom >= collide.rectangle.Top && gameObject.rectangle.Bottom <= collide.rectangle.Bottom) || (gameObject.rectangle.Y < collide.rectangle.Y && gameObject.rectangle.Y + gameObject.velocity.Y > collide.rectangle.Y))
                        {
                            //prevCollision.Y = 1;
                            gameObject.velocity.Y = 0;
                            gameObject.rectangle.Y = collide.rectangle.Top - gameObject.rectangle.Height;
                            Debug.WriteLine("coll bottom");
                        }
                        //Top collision
                        else if (gameObject.velocity.Y < 0 && (gameObject.rectangle.Top >= collide.rectangle.Top && gameObject.rectangle.Top <= collide.rectangle.Bottom) || (gameObject.rectangle.Y > collide.rectangle.Y && gameObject.rectangle.Y + gameObject.velocity.Y < collide.rectangle.Y))
                        {
                            //prevCollision.Y = -1;
                            gameObject.velocity.Y = 0;
                            gameObject.rectangle.Y = collide.rectangle.Bottom;
                            Debug.WriteLine("coll top");
                        }
                    }
                }
            }

            gameObject.rectangle.X += (int)gameObject.velocity.X;
            gameObject.rectangle.Y += (int)gameObject.velocity.Y;
        }

        private void checkYCollision(GameObject gameObject, GameObject collide)
        {
            //Y collision
            if (collide.rectangle.Left - gameObject.rectangle.Width <= gameObject.rectangle.Left && collide.rectangle.Right + -gameObject.rectangle.Width >= gameObject.rectangle.Right)
            {

                //Bottom collision
                if (gameObject.velocity.Y > 0 && (gameObject.rectangle.Bottom >= collide.rectangle.Top && gameObject.rectangle.Bottom <= collide.rectangle.Bottom) || (gameObject.rectangle.Y < collide.rectangle.Y && gameObject.rectangle.Y + gameObject.velocity.Y > collide.rectangle.Y))
                {
                    gameObject.velocity.Y = 0;
                    gameObject.rectangle.Y = collide.rectangle.Top - gameObject.rectangle.Height;
                }
                //Top collision
                else if (gameObject.velocity.Y < 0 && (gameObject.rectangle.Top >= collide.rectangle.Top && gameObject.rectangle.Top <= collide.rectangle.Bottom) || (gameObject.rectangle.Y > collide.rectangle.Y && gameObject.rectangle.Y + gameObject.velocity.Y < collide.rectangle.Y))
                {
                    gameObject.velocity.Y = 0;
                    gameObject.rectangle.Y = collide.rectangle.Bottom;
                }
            }
        }

            private void checkXCollision(GameObject gameObject, GameObject collide)
            {
            //X collision
            if (collide.rectangle.Top - gameObject.rectangle.Height <= gameObject.rectangle.Top && collide.rectangle.Bottom + gameObject.rectangle.Height >= gameObject.rectangle.Bottom)
            {
                //Left collision
                if (gameObject.velocity.X < 0 && (gameObject.rectangle.Left >= collide.rectangle.Left && gameObject.rectangle.Left <= collide.rectangle.Right) || (gameObject.rectangle.X > collide.rectangle.X && gameObject.rectangle.X + gameObject.velocity.X < collide.rectangle.X))
                {
                    gameObject.velocity.X = 0;
                    gameObject.rectangle.X = collide.rectangle.Right;
                }

                //Right collision
                if (gameObject.velocity.X > 0 && (gameObject.rectangle.Right <= collide.rectangle.Right && gameObject.rectangle.Right >= collide.rectangle.Left) || (gameObject.rectangle.X < collide.rectangle.X && gameObject.rectangle.X + gameObject.velocity.X > collide.rectangle.X))
                {
                    gameObject.velocity.X = 0;
                    gameObject.rectangle.X = collide.rectangle.Left - gameObject.rectangle.Width;
                }
            }
        }
    }
}
