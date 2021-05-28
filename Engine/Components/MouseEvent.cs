using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;
using Microsoft.Xna.Framework;
using BoundingBox = Engine.Misc.BoundingBox;

namespace Component
{
    public class MouseEvent : BaseComponent, IUpdate
    {
        public void Update() {
            BoundingBox gameObjectRect = GameObject.HitBox;


            if ((gameObjectRect.Left().X <= Mouse.GetState().X && gameObjectRect.Right().X >= Mouse.GetState().X) && (gameObjectRect.Top().Y <= Mouse.GetState().Y && gameObjectRect.Bottom().Y >= Mouse.GetState().Y)) {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    int button = Mouse.GetState().LeftButton == ButtonState.Pressed ? 0 : (Mouse.GetState().RightButton == ButtonState.Pressed ? 1 : 2);

                    GameObject.onPressed(Mouse.GetState().Position.ToVector2(), button);
                }
                else {
                    GameObject.onHover(Mouse.GetState().Position.ToVector2());
                }
            }
        }
    }
}
