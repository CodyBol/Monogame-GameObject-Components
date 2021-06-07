

using System.Collections.Generic;
using System.Diagnostics;
using Engine;
using Engine.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TestProject.Component
{
    public class Player2 : BaseComponent, IUpdate, IMouse, ITrigger
    {
        private float speed = 5;
        private Layer _bulletLayer;

        public Player2(Layer bulletLayer)
        {
            _bulletLayer = bulletLayer;
        }

        public void Update() {
            //walk
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                GameObject.velocity.Y = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                GameObject.velocity.Y = speed;
            }
            else
            {
                GameObject.velocity.Y = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                GameObject.velocity.X = -speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
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

                GameCore.GameObjectManager.Instantiate(new GameObject(GameObject.BoundingBox, _bulletLayer, comp));
            }
        }

        public void onPressed(Vector2 mousePosition, int mouseButton) {
            Debug.WriteLine("pressed");
        }

        public void onHover(Vector2 mousePosition)
        {
            Debug.WriteLine("hover");
        }

        public void triggerEnter(GameObject collision)
        {
            GameCore.GameObjectManager.RemoveGameObject(collision);
        }
    }
}
