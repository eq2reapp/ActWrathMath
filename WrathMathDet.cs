using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT_Plugin
{
    public class WrathMathDet
    {
        public string Player;
        public int Number;
        public bool IsLabomination = false;

        public override string ToString()
        {
            return $"{Player}: {Number}";
        }
    }
}
