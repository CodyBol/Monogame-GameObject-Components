using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Engine;
using Engine.Misc;
using GameObjects;
using BoundingBox = Engine.Misc.BoundingBox;

namespace Component
{
    public class RectCollider : BaseComponent, IUpdate
    {
        public Layer targetLayer;
        private bool check;

        public RectCollider(Layer layer, bool checkSelf)
        {
            if (layer == null)
            {
                throw new Exception("Layer name can not be null.");
            }

            targetLayer = layer;
            check = checkSelf;
        }

        public void Update()
        {
            if (check)
            {
                foreach (GameObject collide in GameCore.GameObjectManager.gameObjects.ToArray())
                {
                    if (collide != GameObject && collide.layer == targetLayer && collide.hasComponent<RectCollider>())
                    {
                        BoundingBox futureBox = GameObject.HitBox.Copy();
                        futureBox.Position += GameObject.velocity;
                        if (GameObject.HitBox.CollidesWith(collide.HitBox) &&
                            futureBox.CollidesWith(collide.HitBox))
                        {
                            GameObject.onCollisionEnter(collide, GameObject.HitBox.SmallestDistance(collide.HitBox));
                        }
                    }
                }
            }
        }
    }
}