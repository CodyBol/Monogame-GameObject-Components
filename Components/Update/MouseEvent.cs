using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;

namespace Component
{
    class MouseEvent : UpdateComponent
    {
        public void Update(GameObject gameObject) {
            if ((gameObject.rectangle.Left <= Mouse.GetState().X && gameObject.rectangle.Right >= Mouse.GetState().X) && (gameObject.rectangle.Top <= Mouse.GetState().Y && gameObject.rectangle.Bottom >= Mouse.GetState().Y)) {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    int button = Mouse.GetState().LeftButton == ButtonState.Pressed ? 0 : (Mouse.GetState().RightButton == ButtonState.Pressed ? 1 : 2);

                    gameObject.onPressed(Mouse.GetState().Position.ToVector2(), button);
                }
                else {
                    gameObject.onHover(Mouse.GetState().Position.ToVector2());
                }
            }
        }
    }
}
