using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.models
{
    public class OpenJsonResults
    {
        public OpenJsonResults(long idEnemy, List<SpellLine> spells)
        {
            this.idEnemy = idEnemy;
            this.spells = spells;
        }

        public long idEnemy { get; set; }
        public List<SpellLine> spells { get; set; }
        public long particleId { get; set; }
    }
}
