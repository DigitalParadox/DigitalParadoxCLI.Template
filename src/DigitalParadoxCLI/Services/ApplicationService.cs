using System.Threading.Tasks;
using DigitalParadoxCLI.Configuration;
using Serilog;

namespace DigitalParadoxCLI
{
    public class ApplicationService
    {
       
        private readonly ILogger _log;
        private readonly IConfiguration _config;

        public ApplicationService( ILogger log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public async Task Execute()
        {
             await Task.Run((() => _log.Information("Hello World!")));
        }
    }
}
