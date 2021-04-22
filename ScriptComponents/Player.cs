using Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using Engine;
using GameObjects;

namespace Component
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

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                List<BaseComponent> comp = new List<BaseComponent>();
                comp.Add(new SpriteRenderer(GameCore.assetLoader.getSprite("spr_blue_invader")));
                comp.Add(new Bullet());

                GameCore.GameObjectManager.Instantiate(new GameObject(GameObject.getRealRect(), _bulletLayer, comp));
            }
        }

        public void LateUpdate() 
        {
            camera.Target = new Vector2(GameObject.rectangle.X, GameObject.rectangle.Y);
        }

        public void onPressed(Vector2 mousePosition, int mouseButton) {
            Debug.WriteLine("pressed");
        }

        public void onHover(Vector2 mousePosition)
        {
            Debug.WriteLine("hover");
        }

        public void triggerEnter(GameObject collision, Rectangle collideRect, Vector2 direction)
        {
            GameCore.GameObjectManager.RemoveGameObject(collision);
        }
    }
}
