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

        public void initialize(GameObject gameObject) {
            animate = gameObject.getComponent<Animate>();
        }

        public void update(GameObject gameObject) {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                animate.changeState("default");
            }
            else {
                animate.changeState("animate", false);
            }
        }

        public void collisionEnter(GameObject collision, Vector2 direction) {
            Debug.Write("test");
        }
    }
}
