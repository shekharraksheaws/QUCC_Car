using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.SqlHelper
{
    public interface ISqlHelper : IDisposable
    {
        string MySqlConnectionString { get; set; }
    }
}
