using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestProject;
using BoundingBox = Engine.Misc.BoundingBox;

namespace Engine.Component
{
    public class RectCollider : BaseComponent, IUpdate, IDraw
    {
        public Layer TargetLayer;
        private bool _check;

        public RectCollider(Layer layer, bool checkSelf)
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
                    if (collide != GameObject && collide.Layer == TargetLayer && collide.hasComponent<RectCollider>())
                    {
                        BoundingBox futureBox = GameObject.HitBox.Copy();
                        futureBox.Position += GameObject.Velocity;
                        if (GameObject.HitBox.CollidesWith(collide.HitBox) &&
                            futureBox.CollidesWith(collide.HitBox))
                        {
                            GameObject.onCollisionEnter(collide, GameObject.HitBox.SmallestDistance(collide.HitBox));
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
                collisionLine.SetData(new[] {Color.LimeGreen});
            
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(GameObject.HitBox.Width(), 1), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Bottom().Y), null, Color.White, 0, Vector2.Zero, new Vector2(GameObject.HitBox.Width(), 1), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Right().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(1, GameObject.HitBox.Height()), SpriteEffects.None, 0);
                spriteBatch.Draw(collisionLine, new Vector2(GameObject.HitBox.Left().X, GameObject.HitBox.Top().Y), null, Color.White, 0, Vector2.Zero, new Vector2(1, GameObject.HitBox.Height()), SpriteEffects.None, 0);
            }
        }
    }
}