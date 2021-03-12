using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;

namespace Component
{
    class Player : BaseComponent, IUpdate, IMouse, ICollision
    {
        private float speed = 5;

        public void Update() {
            //walk
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                GameObject.velocity.Y = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                GameObject.velocity.Y = speed;
            }
            else
            {
                GameObject.velocity.Y = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                GameObject.velocity.X = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                GameObject.velocity.X = speed;
            }
            else
            {
                GameObject.velocity.X = 0;
            }
        }

        public void onPressed(Vector2 mousePosition, int mouseButton) {
            Debug.WriteLine("pressed");
        }

        public void onHover(Vector2 mousePosition)
        {
            Debug.WriteLine("hover");
        }

        public void collisionEnter(GameObject collision, Rectangle collideRect, Vector2 direction) {
            //Debug.WriteLine("test");
        }
    }
}
