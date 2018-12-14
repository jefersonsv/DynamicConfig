using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicConfig
{
    public class AppSettingsDynamic : Settings
    {
        public AppSettingsDynamic() : base(new Configuration())
        {
            Constructor();
        }

        public AppSettingsDynamic(Configuration configuration) : base(configuration)
        {
            Constructor();
        }

        void Constructor()
        {
            // Read AppSettings
            foreach (string item in ConfigurationManager.AppSettings)
            {
                var value = ConfigurationManager.AppSettings[item] as string;
                TryParseItem(item, value);
            }
        }
    }
}
