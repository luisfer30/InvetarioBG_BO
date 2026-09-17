using Serilog;

namespace InventoryAPI.Dependencies
{
    public static class Logs
    {
        public static void LoggerDI(this ConfigureHostBuilder host ,IConfiguration conf)
        {
            var ruta = conf.GetValue<string>("rutaLog");

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Information().Enrich
                            .FromLogContext().WriteTo
                            .Console().WriteTo
                            .File($"{ruta}/log-.txt", rollingInterval: RollingInterval.Day)
                            .CreateLogger();

            host.UseSerilog();

        }
    }
}
