using System;
using System.Collections.Generic;
using Engine.Component.Misc;
using Engine.Misc;
using Microsoft.Xna.Framework;

namespace Engine.Component
{
    public class BasicMovement : BaseComponent, IUpdate
    {
        public bool Moving = false;
        private Vector2 _target;
        private float _speed;
        
        public void MoveTowards(Vector2 target, float speed)
        {
            _target = target;
            _speed = speed;
            Moving = true;
        }
        
        public Vector2 DistanceBetween(Vector2 target)
        {
            return target - GameObject.BoundingBox.Position;
        }
        
        public Vector2 GetDirectionVector(Vector2 target)
        {
            Vector2 distance = DistanceBetween(target);
            
            distance.Normalize();
            
            return distance;
        }
        

        public void Update()
        {
            if (Moving)
            {
                //Vector2 direction = GameObject.BoundingBox.Position - _target.BoundingBox.Position;
                Vector2 distance = DistanceBetween(_target);

                GameObject.Velocity = GetDirectionVector(_target) * _speed;

                if (Math.Abs(distance.X) < _speed && Math.Abs(distance.Y) < _speed)
                {
                    GameObject.BoundingBox.Position = _target;
                    _target = Vector2.Zero;
                    _speed = 0;
                    Moving = false;
                }
            }
        }
    }
}
