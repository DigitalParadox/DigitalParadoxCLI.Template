using System.Collections.Generic;
using System.Data.Common;

namespace DigitalParadoxCLI.Configuration
{
    public interface IConnectionStrings
    {
        Dictionary<string, DbConnectionStringBuilder> ConnectionStrings { get; set; }
    }
}