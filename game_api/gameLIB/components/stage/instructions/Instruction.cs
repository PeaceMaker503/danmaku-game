using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage.instructions
{
    public abstract class Instruction
    {
        public String type { get; set; }
        public ulong id { get; set; }

        public Instruction(String _type, ulong _id)
        {
            type = _type;
            id = _id;
        }

        public abstract void run(Stage s);
    }
}
