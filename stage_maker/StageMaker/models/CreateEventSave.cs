using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.models
{
    public sealed class CreateEventSave
    {
        public float time { get; set; }
        public ulong targetId { get; set; }
    }
}
