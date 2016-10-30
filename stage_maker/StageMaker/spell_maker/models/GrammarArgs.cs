using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker
{
    public class GrammarArgs
    {
        public GrammarArgs(dynamic values)
        {
            this.values = values;
        }

        public dynamic values { get; private set; }
    }
}
