
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestProject;

namespace Engine.Component
{
    public class RectTrigger : BaseComponent, IUpdate, IDraw
    {
        public Layer TargetLayer;
        private bool _check;

        public RectTrigger(bool checkSelf)
        {
            TargetLayer = GameObject.Layer;
            _check = checkSelf;
        }

        public RectTrigger(Layer layer, bool checkSelf)
        {
            if (layer == null)
            {
                throw new Exception("Layer name can not be null.");
            }

            TargetLayer = layer;
            _check = checkSelf;
        }

        public void Update()
        {
            if (_check)
            {
                foreach (GameObject collide in GameCore.GameObjectManager.GameObjects.ToArray())
                {
                    if (collide != GameObject && collide.Layer == TargetLayer && collide.hasComponent<RectTrigger>())
                    {
                        if (GameObject.HitBox.CollidesWith(collide.HitBox))
                        {
                            GameObject.onTriggerEnter(collide);
                        }
                    }
                }
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameMain.DevMode && (GameObject.hasComponent<RectCollider>() || GameObject.hasComponent<RectTrigger>() || GameObject.hasComponent<MouseEvent>()))
            {
                Texture2D collisionLine = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                collisionLine.SetData(new[] {Color.Yellow});
            
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(GameObject.HitBox.Width(), 1), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Bottom().Y), null, Color.White, 0, Vector2.Zero, new Vector2(GameObject.HitBox.Width(), 1), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Right().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(1, GameObject.HitBox.Height()), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(1, GameObject.HitBox.Height()), SpriteEffects.None, 0);
            }
        }
    }
}
