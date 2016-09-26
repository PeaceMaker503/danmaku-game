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

namespace gameLIB.components.stage
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

        public static String get(this String s, String param, StageMaker.Type type)
        {
            String r = String.Empty;
            int i1, i2, i3;
            if (type == StageMaker.Type.Number)
            {
                if (s.Contains(param))
                {
                    i1 = s.IndexOf(param);
                    String sub = s.Substring(i1);
                    i2 = sub.IndexOf("=");
                    i3 = sub.IndexOf(",");
                    r = sub.Substring(i2 + 1, i3 - 1 - i2).Trim();
                }
            }
            else if (type == StageMaker.Type.Vector)
            {
                if (s.Contains(param))
                {
                    i1 = s.IndexOf(param);
                    String sub = s.Substring(i1);
                    i2 = sub.IndexOf("=");
                    i3 = sub.IndexOf(")");
                    r = sub.Substring(i2 + 1, i3 - i2).Trim();
                }
            }
            return r;
        }

        public static String get(this String s, StageMaker.Type type)
        {
            String r = String.Empty;
            int i1, i2, i3;
            if (type == StageMaker.Type.Time)
            {
                if (s.Contains("time"))
                {
                    i1 = s.IndexOf("time");
                    String sub = s.Substring(i1);
                    i2 = sub.IndexOf("=");
                    i3 = sub.IndexOf(")");
                    r = sub.Substring(i2 + 1, i3 - 1 - i2).Trim();
                }
            }
            else if (type == StageMaker.Type.ID)
            {
                if (s.Contains("aId"))
                {
                    i1 = s.IndexOf("aId");
                    String sub = s.Substring(i1);
                    i2 = sub.IndexOf("=");
                    i3 = sub.IndexOf(",");
                    r = sub.Substring(i2 + 1, i3 - 1 - i2).Trim();
                }
            }
            else if (type == StageMaker.Type.Type)
            {
                if (s.Contains("type"))
                {
                    i1 = s.IndexOf("type");
                    String sub = s.Substring(i1);
                    i2 = sub.IndexOf("=");
                    i3 = sub.IndexOf(",");
                    r = sub.Substring(i2 + 1, i3 - 1 - i2).Trim();
                }
            }
            else if (type == StageMaker.Type.Particle)
            {
                if (s.Contains("particle"))
                {
                    i1 = s.IndexOf("particle");
                    String sub = s.Substring(i1);
                    i2 = sub.IndexOf("=");
                    i3 = sub.IndexOf(",");
                    r = sub.Substring(i2 + 1, i3 - 1 - i2).Trim();
                }
            }
            return r;
        }

    }
}
