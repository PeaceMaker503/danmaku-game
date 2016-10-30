using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker.models
{
    public class CaseArgs
    {
        public CaseArgs(string[] tokens, int valuesCursor, bool conditionState)
        {
            this.tokens = tokens;
            this.valuesCursor = valuesCursor;
            this.conditionState = conditionState;
        }

        public string[] tokens { get; private set; }
        public int valuesCursor { get; private set; }
        public bool conditionState { get; private set; }
    }
}
