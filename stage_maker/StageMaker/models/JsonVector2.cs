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

        public static readonly JsonVector2 Zero = new JsonVector2(0,0);

        public JsonVector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return JsonHelper.JsonSerializeWithoutQuoteInNames(this);
        }
    }
}
