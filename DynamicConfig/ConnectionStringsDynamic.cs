using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicConfig
{
    public class ConnectionStringsDynamic : Settings
    {
        public ConnectionStringsDynamic() : base(new Configuration())
        {
            Constructor();
        }

        public ConnectionStringsDynamic(Configuration configuration) : base(configuration)
        {
            Constructor();
        }

        void Constructor()
        {
            // Read AppSettings
            foreach (System.Configuration.ConnectionStringSettings item in ConfigurationManager.ConnectionStrings)
            {
                TryParseItem(item.Name, item.ConnectionString);
            }
        }
    }
}
