using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage.instructions
{
    public abstract class Instruction
    {
        public String type { get; set; }
        public int id { get; set; }

        public Instruction(String _type, int _id)
        {
            type = _type;
            id = _id;
        }

        public abstract void run(Stage s);
    }
}
