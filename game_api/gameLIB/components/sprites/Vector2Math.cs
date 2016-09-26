using System;
using Microsoft.Xna.Framework;

namespace gameLIB.components.sprites
{
    public class Vector2Math
    {
        public static Vector2 calculateDirection(Vector2 position, Vector2 destination)
        {
            return Vector2.Normalize(new Vector2(destination.X - position.X, destination.Y - position.Y));
        }

        public static Vector2 rotateVector(Vector2 vector, float angle)
        {
            float rad = MathHelper.ToRadians(angle);
            return new Vector2((float)(vector.X * Math.Cos(rad) - vector.Y * Math.Sin(rad)), (float)(vector.X * Math.Sin(rad) + vector.Y * Math.Cos(rad)));
        }

        public static Vector2 rotatePoint(Vector2 point, Vector2 origin, float angle)
        {
            return Vector2.Transform(point - origin, Matrix.CreateRotationZ(MathHelper.ToRadians(angle))) + origin;
        }
    }
}
