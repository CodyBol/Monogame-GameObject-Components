using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;

namespace TestProject
{
    class Player : ScriptComponent
    {
        private Animate animate;
        private float speed = 5;

        public void initialize(GameObject gameObject) {
            animate = gameObject.getComponent<Animate>();
        }

        public void update(GameObject gameObject) {
            /*if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                animate.changeState("default");
            }
            else {
                animate.changeState("animate", false);
            }*/

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                gameObject.velocity.Y = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                gameObject.velocity.Y = speed;
            }
            else
            {
                gameObject.velocity.Y = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                gameObject.velocity.X = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                gameObject.velocity.X = speed;
            }
            else
            {
                gameObject.velocity.X = 0;
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
