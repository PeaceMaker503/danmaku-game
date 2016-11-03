using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.spell_maker.models
{
    public static class Delegates
    {
        public delegate void GrammarAction(GrammarArgs args);
        public delegate long LoopGetterAction(LoopGetterArgs args);
        public delegate void CaseAction(CaseArgs args);
        public delegate void LoopAction(LoopArgs args);
        public delegate bool CaseConditionAction(CaseConditionArgs args);
        public delegate string BehaviorBeginAction(BehaviorBeginArgs args);
        public delegate void BehaviorEndAction(BehaviorEndArgs args);
    }
}
