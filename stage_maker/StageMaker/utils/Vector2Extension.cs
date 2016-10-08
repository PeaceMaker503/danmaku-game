using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.utils
{
    public class Vector2Extension
    {
        public static Vector2 valueOf(float degree)
        {
            float cos = (float)Math.Cos(MathHelper.ToRadians(degree));
            float sin = -(float)Math.Sin(MathHelper.ToRadians(degree)); //Y est inversé dans la fenetre
            return new Vector2(cos, sin);
        }
    }
}
