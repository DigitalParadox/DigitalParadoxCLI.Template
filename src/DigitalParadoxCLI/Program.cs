using System;
using System.Collections.ObjectModel;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;
using Autofac.Builder;
using DigitalParadoxCLI.Properties;
using Microsoft.Extensions.DependencyInjection;


namespace DigitalParadoxCLI
{
    class Program
    {

        static async Task Main(string[] args)
        {
            ServiceContainer.ConfigureServices();
            var entry = ServiceContainer.GetService<EntryPoint>();
            
            await entry.InvokeAsync(args);
        }


    }
}
