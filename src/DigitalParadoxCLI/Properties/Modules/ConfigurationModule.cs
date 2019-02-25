using Autofac;
using DigitalParadoxCLI.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DigitalParadoxCLI.Properties.Modules
{
    internal class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory);

            config.AddEnvironmentVariables("GITHUB_");
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            config.AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"), optional: true, reloadOnChange: true);
            config.AddUserSecrets<IAppSettings>(optional: true, reloadOnChange: true);
            config.AddCommandLine(Environment.GetCommandLineArgs());

            var build = config.Build();

            builder.RegisterInstance(build)
                .AsImplementedInterfaces()
                .SingleInstance();
            var configuration = new Configuration.Configuration();
            build.Bind(configuration);

            builder.RegisterInstance(configuration)
                .AsImplementedInterfaces()
                .ExternallyOwned();

        }
    }
}
