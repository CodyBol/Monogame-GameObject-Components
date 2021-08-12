using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using Engine;
using Engine.Component;

namespace TestProject.Component
{
    public class Player : BaseComponent, IUpdate, ILateUpdate, IMouse, ITrigger
    {
        private float speed = 5;
        private Camera camera;
        private Layer _bulletLayer;

        public Player(Camera cam, Layer bulletLayer)
        {
            camera = cam;
            _bulletLayer = bulletLayer;
        }

        public void Update() {
            //walk
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                GameObject.Velocity.Y = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                GameObject.Velocity.Y = speed;
            }
            else
            {
                GameObject.Velocity.Y = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                GameObject.Velocity.X = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                GameObject.Velocity.X = speed;
            }
            else
            {
                GameObject.Velocity.X = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                if (GameObject.getComponent<BasicMovement>().Moving == false)
                {
                    GameObject.getComponent<BasicMovement>().MoveTowards(new Vector2(0), 10f);
                }
            }
        }

        public void LateUpdate() 
        {
            camera.Target = GameObject.BoundingBox.Position;
        }

        public void OnPressed(Vector2 mousePosition, int mouseButton) {
            Debug.WriteLine("pressed");
        }

        public void OnHover(Vector2 mousePosition)
        {
            Debug.WriteLine("hover");
        }

        public void TriggerEnter(GameObject collision)
        {
            GameCore.GameObjectManager.RemoveGameObject(collision);
        }
    }
}
