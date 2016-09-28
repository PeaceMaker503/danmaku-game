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
using gameLIB.components.stage.instructions;

namespace gameLIB.components.stage
{
    public class Task
    {
        private Instruction _instruction;
        public bool hasRun { get; set; }
        public double time { get; set; }

        public Task(double _time, Instruction i)
        {
            time = _time;
            _instruction = i;
            hasRun = false;
        }

        public void run(Stage s)
        {
            if (!hasRun)
            {
                _instruction.run(s);
                hasRun = true;
            }
        }
    }
}
