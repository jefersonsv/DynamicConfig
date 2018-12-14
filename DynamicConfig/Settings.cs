using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicConfig
{
    public abstract class Settings : DynamicObject
    {
        Configuration configuration;
        protected Dictionary<string, object> dictionary = new Dictionary<string, object>();

        internal Settings(Configuration configuration)
        {
            this.configuration = configuration;
        }

        // This property returns the number of elements
        // in the inner dictionary.
        public int Count
        {
            get
            {
                return dictionary.Count;
            }
        }

        public void TryParseItem(string item, string value)
        {
            if (!configuration.CaseSensitive)
                item = item.ToLower();

            if (configuration.CultureInfo == null)
            {
                if (bool.TryParse(value, out bool boolValue))
                    dictionary.Add(item, boolValue);
                else if (Int16.TryParse(value, out Int16 int16Value))
                    dictionary.Add(item, int16Value);
                else if (Int32.TryParse(value, out Int32 int32Value))
                    dictionary.Add(item, int32Value);
                else if (Int64.TryParse(value, out Int64 int64Value))
                    dictionary.Add(item, int64Value);
                else if (float.TryParse(value, out float floatValue))
                    dictionary.Add(item, floatValue);
                else if (double.TryParse(value, out double doubleValue))
                    dictionary.Add(item, doubleValue);
                else if (decimal.TryParse(value, out decimal decimalValue))
                    dictionary.Add(item, decimalValue);
                else if (TimeSpan.TryParse(value, out TimeSpan timeSpanValue))
                    dictionary.Add(item, timeSpanValue);
                else if (DateTime.TryParse(value, out DateTime dateTimeValue))
                    dictionary.Add(item, dateTimeValue);
                else
                    dictionary.Add(item, value);
            }
            else
            {
                if (bool.TryParse(value, out bool boolValue))
                    dictionary.Add(item, boolValue);
                else if (Int16.TryParse(value, System.Globalization.NumberStyles.Any, configuration.CultureInfo, out Int16 int16Value))
                    dictionary.Add(item, int16Value);
                else if (Int32.TryParse(value, System.Globalization.NumberStyles.Any, configuration.CultureInfo, out Int32 int32Value))
                    dictionary.Add(item, int32Value);
                else if (Int64.TryParse(value, System.Globalization.NumberStyles.Any, configuration.CultureInfo, out Int64 int64Value))
                    dictionary.Add(item, int64Value);
                else if (float.TryParse(value, System.Globalization.NumberStyles.Any, configuration.CultureInfo, out float floatValue))
                    dictionary.Add(item, floatValue);
                else if (double.TryParse(value, System.Globalization.NumberStyles.Any, configuration.CultureInfo, out double doubleValue))
                    dictionary.Add(item, doubleValue);
                else if (decimal.TryParse(value, System.Globalization.NumberStyles.Any, configuration.CultureInfo, out decimal decimalValue))
                    dictionary.Add(item, decimalValue);
                else if (TimeSpan.TryParse(value, out TimeSpan timeSpanValue))
                    dictionary.Add(item, timeSpanValue);
                else if (DateTime.TryParse(value, out DateTime dateTimeValue))
                    dictionary.Add(item, dateTimeValue);
                else
                    dictionary.Add(item, value);
            }
        }

        // If you try to get a value of a property 
        // not defined in the class, this method is called.
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = configuration.CaseSensitive ? binder.Name : binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            var val = dictionary.SingleOrDefault(w => w.Key == name);
            if (val.Key == null)
            {
                dictionary.Add(name, null);
            }

            return dictionary.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            string name = configuration.CaseSensitive ? binder.Name : binder.Name.ToLower();

            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            dictionary[name] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }

        // Converting an object to a specified type.
        public override bool TryConvert(
            ConvertBinder binder, out object result)
        {
            // Converting to string. 
            if (binder.Type == typeof(String))
            {
                result = dictionary["Textual"];
                return true;
            }

            // Converting to integer.
            if (binder.Type == typeof(int))
            {
                result = dictionary["Numeric"];
                return true;
            }

            // In case of any other type, the binder 
            // attempts to perform the conversion itself.
            // In most cases, a run-time exception is thrown.
            return base.TryConvert(binder, out result);
        }
    }
}
