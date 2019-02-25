using DigitalParadoxCLI.Properties;
using Serilog;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;

namespace DigitalParadoxCLI
{
    class Program
    {
        private readonly IHostingEnvironment _env;


        static Task<int> Main(string[] args)
            => new HostBuilder()
                .RunCommandLineApplicationAsync<Program>(args);

        static void OldMain(string[] args)
        {

            ServiceContainer.ConfigureServices();
            var log = ServiceContainer.GetService<ILogger>();

            var app = ServiceContainer.GetService<ApplicationService>();

            Cli(args);
        }

        private static void Cli(string[] args)
        {
            CommandLineApplication cli = new CommandLineApplication();

            cli.Name = ProductName;
            cli.FullName = ProductName;

            cli.VersionOption(
                "-v|--version",
               ShortFormVersion, 
               LongFormVersion);

            cli.HelpOption("-h|--help");
            if (cli.IsShowingInformation)
            {

            }
            cli.ShowHelp();
            cli.Execute(args);
        }

        private void OnExecute()
        {
            
        }

        public Program(IHostingEnvironment env)
        {
            _env = env;
            env.ApplicationName = ProductName;

        }

        private static string ProductName { get; } = typeof(Program).Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
        private static string ShortFormVersion { get; } = typeof(Program).Assembly.GetName().Version.ToString();
        private static string LongFormVersion { get; } = FileVersionInfo.GetVersionInfo(typeof(Program).Assembly.Location).ProductVersion;
    }
}
