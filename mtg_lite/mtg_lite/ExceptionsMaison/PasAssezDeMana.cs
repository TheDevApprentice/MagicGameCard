using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.ExceptionsMaison
{
    public class PasAssezDeMana : Exception
    {
        public PasAssezDeMana(string message) : base(message) { }
    }
}
