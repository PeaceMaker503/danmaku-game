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

namespace gameLIB.components.stage
{
    public class Task
    {
        private Instruction _instruction;
        private bool _hasRun;
        private double _time;

        public Task(double time, Instruction i)
        {
            Time = time;
            _instruction = i;
            _hasRun = false;
        }

        public void run(Stage s)
        {
            if (!_hasRun)
            {
                _instruction.run(s);
                _hasRun = true;
            }
        }

        public bool hasRun
        {
            get { return _hasRun; }
            set { _hasRun = value; }
        }

        public double Time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
            }
        }
    }
}
