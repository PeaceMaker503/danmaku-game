﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageMaker.models
{
    public sealed class ParticleMoveEvent
    {
        public float time { get; set; }
        public long particleId { get; set; }
        public string direction { get; set; }
        public string destination { get; set; }
        public float speed { get; set; }
    }
}
