using Serilog;
using Serilog.Events;
using System.IO;
using System.Reflection;

namespace ShopBridge_api.StartupExtension
{
    public static class LogSettingsExtension
    {
        public static void SetupSerilog()
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: baseDir + @"/Logs/log-.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                )
                .CreateLogger();
        }
    }
}
