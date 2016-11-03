using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.models
{
    public class Config
    {
        public Dictionary<string, List<EnemyType>> enemyTypes { get; set; }
        public List<SpellLine> spells { get; set; }
    }
}
