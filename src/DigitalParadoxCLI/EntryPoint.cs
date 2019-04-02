using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace DigitalParadoxCLI
{
    public class EntryPoint : RootCommand
    {
        private readonly ILogger _log;
        private readonly IServiceProvider _services;


        public EntryPoint(ILogger log, IServiceProvider services, IEnumerable<Command> commands)
        {
            _log = log;
            _services = services;

            AddOption(new Option("verbosity", "sets how detailed the output should be", new Argument() { ArgumentType = typeof(LogEventLevel), Arity = new ArgumentArity(1, 1) }));
            AddOption(new Option("force", "force execution of command", new Argument() { ArgumentType = typeof(bool), Arity = new ArgumentArity(1, 1) }));

            commands.ToList()
                .ForEach(AddCommand);
             
        }
        
    }
}