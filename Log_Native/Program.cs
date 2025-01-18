// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Logging;


#region 控制台日志输出

#endregion
// 创建日志对象
ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
    // 配置Console日志
    builder.AddConsole();
});

// 创建ILogger接口
ILogger logger = loggerFactory.CreateLogger<Program>();

// 输出日志
logger.LogInformation("Logs");