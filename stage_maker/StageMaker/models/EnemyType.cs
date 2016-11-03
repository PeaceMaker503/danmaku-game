using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.models
{
    public class EnemyType
    {
        public EnemyType(string type, string imagePath, int x, int y, int width, int height)
        {
            this.type = type;
            this.imagePath = imagePath;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public string type { get; set; }
        public string imagePath { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
