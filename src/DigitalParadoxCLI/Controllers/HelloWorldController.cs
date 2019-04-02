using System.CommandLine;
using System.CommandLine.DragonFruit;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace DigitalParadoxCLI
{
    public class HelloWorldController : Command
    {
        private readonly ILogger _log;

        public HelloWorldController(ILogger log ) : base(name: "hello-world")
        {
           
            _log = log;
            AddOption(new Option("repeat"));
            AddOption(new Option("name"));
            
            Handler = CommandHandler.Create<int, string>(delegate(int i, string s)
            {
                Execute(i, s);
            });
        }

        private void Execute(int repeat, string name)
        {
            for (int i = 0; i <= repeat; i++)
            {
               _log.Information($"Hello {name}!!"); 
            }
        }
    }


}
