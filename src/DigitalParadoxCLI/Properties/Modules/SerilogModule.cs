using Autofac;
using DigitalParadoxCLI.Configuration;
using Serilog;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace DigitalParadoxCLI.Properties.Modules
{
    internal class SerilogModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ILogger>(context =>
            {
                var conf = context.Resolve<ILoggerConfiguration>();
               
                var log = new LoggerConfiguration();

                log.ReadFrom.Configuration(context.Resolve<IConfiguration>());
                log.WriteTo.Console();
                log.MinimumLevel.Is(conf.Verbosity);

                return log.CreateLogger();
                
            });

        }
    }
}