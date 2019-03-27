using Serilog;

namespace DigitalParadoxCLI
{
    public class ApplicationController
    {
        private readonly ILogger _log;

        public ApplicationController(ILogger log )
        {
            _log = log;
        }
        

    }


}
