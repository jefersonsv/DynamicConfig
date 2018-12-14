using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicConfig
{
    public class Configuration
    {
        public static Configuration Global = new Configuration();

        public bool CaseSensitive;

        public CultureInfo CultureInfo;
    }
}
