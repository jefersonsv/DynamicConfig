[![Build Status](https://travis-ci.org/jefersonsv/DynamicConfig.svg?branch=master)](https://travis-ci.org/jefersonsv/DynamicConfig)
[![NuGet](https://img.shields.io/nuget/v/DynamicConfig-icon.svg)](https://www.nuget.org/packages/DynamicConfig/)
[![MIT Licence](https://badges.frapsoft.com/os/mit/mit.svg?v=103)](https://opensource.org/licenses/mit-license.php)

# DynamicConfig
Access appSettings and connectionStrings of config files with dynamic object

# Features
* Change settings globally
* Change settings by instance
* Read appSetttings configuration section as dynamic object
* Read connectionStrings configuration section as dynamic object
* Change values of appSettings if you want. (The change don't will be persisted in the app.Config or web.Config)
* Change values of connectionStrings if you want. (The change don't will be persisted in the app.Config or web.Config)
* Parse automatically _string_ type
* Parse automatically _bool_ type
* Parse automatically _Int16_ type
* Parse automatically _Int32_ type
* Parse automatically _Int64_ type
* Parse automatically _float_ type
* Parse automatically _double_ type
* Parse automatically _decimal_ type
* Parse automatically _TimeSpan_ type
* Parse automatically _DateTime_ type

## Getting started 

1. Start a new project and add Nuget Reference
2. PM> ` Install-Package DynamicConfig `
3. Created instance of AppSettingsDynamic or 

### Nuget package
https://www.nuget.org/packages/DynamicConfig/

## Global settings

You can change the settings globally. 
> These changes will be applied to instances created after change. All settings before instanced don't will be changed.

```c#
// Change global settings for these library
DynamicConfig.Configuration.Global.CultureInfo = new CultureInfo("en-US");
DynamicConfig.Configuration.Global.CaseSensitive = true; 
```

## Sample

```c#
dynamic connectionStrings = new ConnectionStringsDynamic(); // Use default settings

// Specify culture to use in instance
dynamic appSettings = new AppSettingsDynamic(new Configuration 
{
    CultureInfo = new CultureInfo("en-US")
});

string asString = appSettings.asString; // The value will be "lorem ipsum"
bool asBool = appSettings.asBool; // The value will be True
int asInt32 = appSettings.asInt32; // The value will be 2147483647

System.Console.WriteLine($"Key: {nameof(appSettings.asString).PadRight(15, ' ')} Type: {appSettings.asString.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asString}");
System.Console.WriteLine($"Key: {nameof(appSettings.asBool).PadRight(15, ' ')} Type: {appSettings.asBool.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asString}");
System.Console.WriteLine($"Key: {nameof(appSettings.asInt16).PadRight(15, ' ')} Type: {appSettings.asInt16.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asInt16}");
System.Console.WriteLine($"Key: {nameof(appSettings.asInt32).PadRight(15, ' ')} Type: {appSettings.asInt32.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asInt32}");
System.Console.WriteLine($"Key: {nameof(appSettings.asInt64).PadRight(15, ' ')} Type: {appSettings.asInt64.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asInt64}");
System.Console.WriteLine($"Key: {nameof(appSettings.asFloat).PadRight(15, ' ')} Type: {appSettings.asFloat.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asFloat}");
System.Console.WriteLine($"Key: {nameof(appSettings.asDouble).PadRight(15, ' ')} Type: {appSettings.asDouble.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asDouble}");
System.Console.WriteLine($"Key: {nameof(appSettings.asTimeSpan).PadRight(15, ' ')} Type: {appSettings.asTimeSpan.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asTimeSpan}");
System.Console.WriteLine($"Key: {nameof(appSettings.asDateTime).PadRight(15, ' ')} Type: {appSettings.asDateTime.GetType().Name.PadRight(15, ' ')} Value: {appSettings.asDateTime}");

System.Console.WriteLine($"CS: {connectionStrings.db}");

/* Results:
Key: asString        Type: String          Value: lorem ipsum
Key: asBool          Type: Boolean         Value: lorem ipsum
Key: asInt16         Type: Int16           Value: 32767
Key: asInt32         Type: Int32           Value: 2147483647
Key: asInt64         Type: Int64           Value: 9223372036854775807
Key: asFloat         Type: Single          Value: 1,234568E+09
Key: asDouble        Type: Double          Value: 1,23456789012346E+49
Key: asTimeSpan      Type: TimeSpan        Value: 4.03:04:20.0550000
Key: asDateTime      Type: DateTime        Value: 20/11/2018 04:20:55
CS: Data Source=127.0.0.1;Initial Catalog=master; User Id=sa;Password=sa
*/
```

## Thanks to
- [Travis CI](https://travis-ci.org/)
- [Open Source Initiative](https://opensource.org/)
- [NuGet](https://www.nuget.org)
- [Emoji](http://www.webpagefx.com/tools/emoji-cheat-sheet/)
- Thanks for all :smile:

### Author
- [Jeferson Tenorio](https://br.linkedin.com/in/jefersontenorio)
