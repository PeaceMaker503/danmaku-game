using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker.models
{
    public class BehaviorEndArgs
    {
        public BehaviorEndArgs(string behaviorName, List<string> behaviorBuffer, int valuesCursor)
        {
            this.behaviorName = behaviorName;
            this.behaviorBuffer = behaviorBuffer;
            this.valuesCursor = valuesCursor;
        }

        public string behaviorName { get; set; }
        public List<string> behaviorBuffer { get; set; }
        public int valuesCursor { get; set; }
    }
}
