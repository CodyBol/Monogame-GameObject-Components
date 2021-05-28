using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Engine.Misc
{
    public class HitBox
    {
        public Vector2 Scale;
        public Vector2 Size;

        public HitBox()
        {
            Scale = Vector2.One;
            Size = Vector2.Zero;
        }

        public HitBox(Vector2 scale, Vector2 size)
        {
            Scale = scale;
            Size = size;
        }

        public HitBox(Vector2 scale)
        {
            Scale = scale;
            Size = Vector2.Zero;
        }

        public HitBox Copy()
        {
            return new HitBox(Scale, Size);
        }
    }
}