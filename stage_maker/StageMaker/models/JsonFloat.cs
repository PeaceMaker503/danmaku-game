using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StageMaker.models
{
    public sealed class JsonFloat
    {
        public float f { get; set; }

        public static readonly JsonFloat Zero = new JsonFloat(0);

        public JsonFloat(float f)
        {
            this.f = f;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(f);
        }
    }
}
