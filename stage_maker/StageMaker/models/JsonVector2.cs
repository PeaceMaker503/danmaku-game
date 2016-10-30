using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StageMaker.models
{
    public sealed class JsonVector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public static readonly string Zero = "{X:0.0, Y:0.0}";

        public JsonVector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public JsonVector2(Vector2 v)
        {
            this.X = v.X;
            this.Y = v.Y;
        }

        public static JsonVector2 operator *(JsonVector2 v1, JsonVector2 v2)
        {
            return new JsonVector2(v1.X * v2.X, v1.Y * v2.Y);
        }

        public override string ToString()
        {
            return "{X: " + X.ToString().Replace(",", ".") + ", Y:" + Y.ToString().Replace(",", ".") + "}";
        }

        public static JsonVector2 convertString(string s)
        {
            if (s.StartsWith("{X:") && s.EndsWith("}") && s.Count(c => c == ',') == 1)
            {
                string sx = s.substring(3, s.IndexOf(",") - 1).Trim();
                string sy = s.substring(s.NthIndexOf(":", 2) + 1, s.Length-2).Trim();
                if (sx.Count(c => c == '.') <= 1 && sy.Count(c => c == '.') <=  1)
                {
                    sx = sx.Replace(".", ",");
                    sy = sy.Replace(".", ",");
                    float x, y;
                    if (float.TryParse(sx, out x) && float.TryParse(sy, out y))
                    {
                        return new JsonVector2(x, y);
                    }
                    else return null;
                }
                else return null;
            }
            else return null;
        }
    }
}
