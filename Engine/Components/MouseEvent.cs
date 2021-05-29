using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using GameObjects;
using Microsoft.Xna.Framework;
using TestProject;
using BoundingBox = Engine.Misc.BoundingBox;

namespace Component
{
    public class MouseEvent : BaseComponent, IUpdate, IDraw
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
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameMain.DevMode && (GameObject.hasComponent<RectCollider>() || GameObject.hasComponent<RectTrigger>() || GameObject.hasComponent<MouseEvent>()))
            {
                Texture2D collisionLine = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                collisionLine.SetData(new[] {Color.OrangeRed});
            
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(GameObject.HitBox.Width(), 1), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Bottom().Y), null, Color.White, 0, Vector2.Zero, new Vector2(GameObject.HitBox.Width(), 1), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Right().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(1, GameObject.HitBox.Height()), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(1, GameObject.HitBox.Height()), SpriteEffects.None, 0);
            }
        }
    }
}
