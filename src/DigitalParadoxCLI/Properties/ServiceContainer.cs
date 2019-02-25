using DigitalParadoxCLI.Properties.Modules;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;


namespace DigitalParadoxCLI.Properties
{

    internal static class ServiceContainer
    {

        static ContainerBuilder Builder { get; set; } = new ContainerBuilder();
        static IContainer Container { get; set; }
        //public static IServiceProvider ServiceProvider { get; set; }



        public static void ConfigureServices()
        {


            //Configure .net core services 



            //populate autofac with .netcore services if using Microsoft.Extensions.DependencyInjection
            //Builder.Populate(ServiceCollection);


            //register autofac services 
            Builder.RegisterModule<ConfigurationModule>();
            Builder.RegisterModule<SerilogModule>();

            Builder.RegisterType<ApplicationService>();
            
            //build service provider
            Container = Builder.Build();

            //set netcore injection service provider if using it 
            //ServiceProvider = new AutofacServiceProvider(Container);

            //Register Global Error Handling 
            var log = GetService<ILogger>();

 
            AppDomain.CurrentDomain.UnhandledException += (s, e) => log.Error(e.ExceptionObject as Exception, "** Crash!! ** { Message }");
            TaskScheduler.UnobservedTaskException += (s, e) => log.Error(e.Exception, "** Crash!! ** { Message }");

            //handle app exit tasks 
            AppDomain.CurrentDomain.ProcessExit += (s, e) => log.Information($"Application exited with code { Environment.ExitCode }");
        }

        public static T GetService<T>(params Parameter[] args)
        {
            return Container.Resolve<T>(args);
        }


    }
}
