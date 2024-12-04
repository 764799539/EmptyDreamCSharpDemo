using Configuration_Native.Binds;
using Configuration_Native.Custom.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;

#region Json
// 构建配置对象
ConfigurationBuilder JsonBuilder = new();
JsonBuilder.AddJsonFile("appsettings.json");
IConfiguration JsonConfiguration = JsonBuilder.Build();

// 读取配置信息
string? JsonApplicationName = JsonConfiguration["ApplicationInfo:ApplicationName"];
string? JsonVersion = JsonConfiguration["ApplicationInfo:Version"];

Console.WriteLine($"JsonConfiguration:{JsonApplicationName}:{JsonVersion}");

//// 配置绑定的读取配置信息
//ApplicationInfo Info = new();
//JsonConfiguration.GetSection("ApplicationInfo").Bind(Info);
//Console.WriteLine($"JsonConfiguration:{Info.ApplicationName}:{Info.Version}");
#endregion

#region XML
// 构建配置对象
ConfigurationBuilder XMLBuilder = new();
XMLBuilder.AddXmlFile("appsettings.xml");
IConfiguration XMLConfiguration = XMLBuilder.Build();

// 读取配置信息
string? XMLApplicationName = XMLConfiguration["ApplicationInfo:ApplicationName"];
string? XMLVersion = XMLConfiguration["ApplicationInfo:Version"];

Console.WriteLine($"XMLConfiguration:{XMLApplicationName}:{XMLVersion}");
#endregion

#region Yaml
// 构建配置对象
ConfigurationBuilder YamlBuilder = new();
YamlBuilder.AddYamlFile("appsettings.yaml");
IConfiguration YamlConfiguration = YamlBuilder.Build();

// 读取配置信息
string? YamlApplicationName = YamlConfiguration["ApplicationInfo:ApplicationName"];
string? YamlVersion = YamlConfiguration["ApplicationInfo:Version"];

Console.WriteLine($"YamlConfiguration:{YamlApplicationName}:{YamlVersion}");
#endregion

#region 命令行
// 构建配置对象
// dotnet run --ApplicationName=Configuration_Native_CommandLine --Version=1.0.0
ConfigurationBuilder CommandLineBuilder = new();
CommandLineBuilder.AddCommandLine(args);
IConfiguration CommandLineConfiguration = CommandLineBuilder.Build();

// 读取配置信息
string? CommandLineApplicationName = CommandLineConfiguration["ApplicationName"];
string? CommandLineVersion = CommandLineConfiguration["Version"];

Console.WriteLine($"CommandLineConfiguration:{CommandLineApplicationName}:{CommandLineVersion}");
#endregion

#region 自定义
// 构建配置对象
ConfigurationBuilder CustomBuilder = new();

// 声明配置源
//TextConfigurationSource CustomSource = new TextConfigurationSource("appsettings.txt");
//CustomBuilder.Add(CustomSource);
// 封装后
CustomBuilder.AddText("appsettings.txt");

IConfiguration CustomConfiguration = CustomBuilder.Build();

// 读取配置信息
string? CustomApplicationName = CustomConfiguration["ApplicationInfo.ApplicationName"];
string? CustomVersion = CustomConfiguration["ApplicationInfo.Version"];

Console.WriteLine($"CustomConfiguration:{CustomApplicationName}:{CustomVersion}");
#endregion