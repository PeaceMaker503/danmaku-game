using Microsoft.Xna.Framework;
using StageMaker.models;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker
{
    public class SpellMaker
    {
        public SpellEvaluator spellEvaluator { get; private set; }

        public SpellMaker(string spellName, float time, long targetId, long particleId, Dictionary<string, string> spells)
        {
            this.spellEvaluator = new SpellEvaluator(spellName, time, targetId, particleId, spells);
        }
    }
}
