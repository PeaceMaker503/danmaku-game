using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage
{
    public abstract class Instruction
    {
        private String _type;
        private String _id;

        public Instruction(String type, String id)
        {
            _type = type;
            _id = id;
        }
        public abstract void run(Stage s);

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
    }
}
