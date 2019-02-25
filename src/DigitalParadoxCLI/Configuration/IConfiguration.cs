
using System;
using System.Collections.Generic;
using System.Data.Common;
using Serilog.Configuration;
using Serilog.Events;

namespace DigitalParadoxCLI.Configuration
{
    public interface IConfiguration :
        IAppSettings, IConnectionStrings, ILoggerConfiguration
    {

    }

    public interface ILoggerConfiguration
    {
        LogEventLevel Verbosity { get; set; }

    }


    public class Configuration : IConfiguration
    {

        public Configuration()
        {
            Verbosity = IsDevelopment ? LogEventLevel.Debug : LogEventLevel.Information;
        }

        public bool IsDevelopment { get; set; } = Environment.GetEnvironmentVariable("aspnetcore_environment").In("Development", "Debug");
        public LogEventLevel Verbosity { get; set; }
        public Dictionary<string, DbConnectionStringBuilder> ConnectionStrings { get; set; }
    }
}