using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;
using Microsoft.Xna.Framework;

namespace Component
{
    class MouseEvent : BaseComponent, IUpdate
    {
        public void Update() {
            Rectangle gameObjectRect = GameObject.getRealRect();


            if ((gameObjectRect.Left <= Mouse.GetState().X && gameObjectRect.Right >= Mouse.GetState().X) && (gameObjectRect.Top <= Mouse.GetState().Y && gameObjectRect.Bottom >= Mouse.GetState().Y)) {
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
