using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Engine;
using GameObjects;

namespace Component
{
    public class RectTrigger : BaseComponent, IUpdate
    {
        public Layer targetLayer;
        private bool check;

        public RectTrigger(Layer layer, bool checkSelf)
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
                    if (collide != GameObject && collide.layer == targetLayer && collide.hasComponent<RectTrigger>())
                    {
                        if (GameObject.BoundingBox.CollidesWith(collide.BoundingBox))
                        {
                            GameObject.onTriggerEnter(collide);
                        }
                    }
                }
            }
        }
    }
}
