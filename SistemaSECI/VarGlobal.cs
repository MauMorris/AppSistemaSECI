using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSECI
{
    static class VarGlobal
    {
        private static string _globalEnd = string.Empty;

        public static string GlobalEnd
        {
            get
            {
                return _globalEnd;
            }
            set
            {
                _globalEnd = value;
            }
        }
    }
}
