using gameLIB.utils;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace gameLIB.components.stage.parser.models
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

        public override string ToString()
        {
            return JsonHelper.JsonSerializeWithoutQuoteInNames(this);
        }
    }
}
