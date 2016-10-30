using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker.models
{
    public class LoopArgs
    {
        public LoopArgs(string[] tokens, long times, int valuesCursor)
        {
            this.tokens = tokens;
            this.times = times;
            this.valuesCursor = valuesCursor;
        }

        public long times { get; private set; }
        public string[] tokens { get; private set; }
        public int valuesCursor { get; private set; }
    }
}
