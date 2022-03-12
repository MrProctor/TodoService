using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    $"Logs\\log-{DateTime.Now:yyyyMMdd}.log",
                    LogEventLevel.Error,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
                    fileSizeLimitBytes: 5000000,
                    rollOnFileSizeLimit: true)
                .WriteTo.File(
                    $"Logs\\info-{DateTime.Now:yyyyMMdd}.log",
                    LogEventLevel.Information,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
                    fileSizeLimitBytes: 5000000,
                    rollOnFileSizeLimit: true)
                .CreateLogger();
            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json");
                    builder.AddJsonFile("appsettings.Development.json");
                    builder.Build();
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
