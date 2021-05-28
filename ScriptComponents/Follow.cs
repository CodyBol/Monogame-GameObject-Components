using System;
using Engine;
using Engine.Misc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameObjects;

namespace Component
{
    public class Follow : BaseComponent, IUpdate, ILateUpdate
    {
        private GameObject _follow;
        private bool colorFound = false;

        public Follow(GameObject toFollow)
        {
            _follow = toFollow;
        }

        public void Update()
        {
            Random rnd = new Random();
            
            Color color = Color.White;
            color.A = (byte)rnd.Next(240, 250);

            GameObject.getComponent<SpriteRenderer>().Color = color;
        }

        public void LateUpdate()
        {
            GameObject.BoundingBox.Position = _follow.BoundingBox.Position;
        }
    }
}