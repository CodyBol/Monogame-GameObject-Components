using System;

namespace Engine
{
    public static class MathUtility
    {
        public static float DegreesToRadian(float degrees)
        {
            return (float)((Math.PI / 180) * degrees);
        }
        
        public static float RadianToDegrees(float radians)
        {
            return (float)((180 / Math.PI) * radians);
        }
    }
}