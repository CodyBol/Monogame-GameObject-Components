using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestProject.Component
{
    class Player : ScriptComponent
    {

        public Player() 
        {

        }

        public void collisionEnter(GameObject collision, Vector2 direction) {
            Debug.Write("test");
        }
    }
}
