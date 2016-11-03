using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker.models
{
    public class BehaviorBeginArgs
    {
        public BehaviorBeginArgs(string[] values) //pattern 0 -> id; 1 -> type; 2 -> id; 3 -> type; ...
        {
            this.values = values;
        }

        public string[] values { get; private set; }
    }
}
