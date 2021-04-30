using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Engine.Misc
{
    public class BoundingBox
    {
        public Vector2 Position;
        public Vector2 Scale;

        public Vector2 Size;

        public BoundingBox()
        {
            Position = Vector2.Zero;
            Scale = Vector2.One;
            Size = Vector2.Zero;
        }

        public BoundingBox(Vector2 position, Vector2 scale, Vector2 size)
        {
            Position = position;
            Scale = scale;
            Size = size;
        }

        public BoundingBox Copy()
        {
            return new BoundingBox(Position, Scale, Size);
        }


        public Vector2 Left()
        {
            return new Vector2(Position.X - (Size.X / 2 * Scale.X), Position.Y);
        }

        public Vector2 Right()
        {
            return new Vector2(Position.X + (Size.X / 2 * Scale.X), Position.Y);
        }

        public Vector2 Top()
        {
            return new Vector2(Position.X, Position.Y - (Size.Y / 2 * Scale.Y));
        }

        public Vector2 Bottom()
        {
            return new Vector2(Position.X, Position.Y + (Size.Y / 2 * Scale.Y));
        }

        public float Width()
        {
            return Size.X * Scale.X;
        }

        public float Height()
        {
            return Size.Y * Scale.Y;
        }

        public bool CollidesWith(BoundingBox other)
        {
            return (other.Left().X <= Right().X && Left().X <= other.Right().X) && (other.Top().Y <= Bottom().Y && Top().Y <= other.Bottom().Y);
        }

        public Vector2 SmallestDistance(BoundingBox other)
        {
            float[] directions = new float[4];
            
            directions[0] = Math.Abs(other.Top().Y - Bottom().Y);
            directions[1] = Math.Abs(other.Right().X - Left().X);
            directions[2] = Math.Abs(other.Bottom().Y - Top().Y);
            directions[3] = Math.Abs(other.Left().X - Right().X);

            Vector2 direction = Vector2.Zero;
            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == directions.Min())
                {
                    switch (i)
                    {
                        case 0:
                            direction = new Vector2(0, -1);
                            break;
                        case 1:
                            direction = new Vector2(1, 0);
                            break;
                        case 2:
                            direction = new Vector2(0, 1);
                            break;
                        case 3:
                            direction = new Vector2(-1, 0);
                            break;
                    }
                }
            }

            return direction;
        }
    }
}