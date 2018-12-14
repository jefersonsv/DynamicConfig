using DynamicConfig;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Sample
{
    class Program
    {
        static void Main(string[] args)
        {

            DynamicConfig.Configuration.Global.CaseSensitive = true;

            dynamic appSettings = new AppSettingsDynamic(new Configuration
            {
                CultureInfo = new CultureInfo("en-US")
            });
            dynamic connectionStrings = new ConnectionStringsDynamic();

            System.Console.WriteLine($"Key: {nameof(appSettings.asString).PadRight(15, ' ')} Type: {appSettings.asString.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asString}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asBool).PadRight(15, ' ')} Type: {appSettings.asBool.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asString}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asInt16).PadRight(15, ' ')} Type: {appSettings.asInt16.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asInt16}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asInt32).PadRight(15, ' ')} Type: {appSettings.asInt32.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asInt32}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asInt64).PadRight(15, ' ')} Type: {appSettings.asInt64.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asInt64}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asFloat).PadRight(15, ' ')} Type: {appSettings.asFloat.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asFloat}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asDouble).PadRight(15, ' ')} Type: {appSettings.asDouble.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asDouble}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asDecimal).PadRight(15, ' ')} Type: {appSettings.asDecimal.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asDecimal}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asTimeSpan).PadRight(15, ' ')} Type: {appSettings.asTimeSpan.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asTimeSpan}");
            System.Console.WriteLine($"Key: {nameof(appSettings.asDateTime).PadRight(15, ' ')} Type: {appSettings.asDateTime.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asDateTime}");

            System.Console.WriteLine($"CS: {connectionStrings.db}");
        }
    }
}
