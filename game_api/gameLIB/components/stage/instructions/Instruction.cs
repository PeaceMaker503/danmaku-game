using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage.instructions
{
    public abstract class Instruction
    {
        public abstract void run(Stage s);
    }
}
