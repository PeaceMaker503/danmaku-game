using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker.models
{
    public class LoopGetterArgs
    {
        public LoopGetterArgs(string times)
        {
            this.times = times;
        }

        public string times { get; private set; }
    }
}
