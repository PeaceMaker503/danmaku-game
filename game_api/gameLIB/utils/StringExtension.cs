using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace gameLIB.utils
{
    public static class StringExtension
    {
        public const String VectorZero = "(0,0)";

        public static double toDouble(this String s)
        {
            s = s.Trim();
            if (s.Contains("."))
            {
                int i = s.IndexOf(".");
                int ent = Int32.Parse(s.Substring(0, i));
                String decStr = s.Substring(i + 1);
                int decI = Int32.Parse(s.Substring(i + 1));
                double p = Math.Pow(10, s.Substring(i + 1).Length);
                return ent + (decI / p);
            }
            else
            {
                return Int32.Parse(s.Substring(0));
            }
        }
    }
}
