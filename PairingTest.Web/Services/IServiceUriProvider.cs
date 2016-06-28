using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public interface IServiceUriProvider
    {
        string BaseUri { get; }
    }
}
