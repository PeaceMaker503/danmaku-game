using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker.models
{
    public class CaseConditionArgs
    {
        public CaseConditionArgs(dynamic values)
        {
            this.values = values;
        }

        public dynamic values { get; private set; }
    }
}
