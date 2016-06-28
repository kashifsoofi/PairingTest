using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public interface IGetApiClient
    {
        Task<object> Get(string requestUri);
        Task<T> Get<T>(string requestUri);
    }
}
