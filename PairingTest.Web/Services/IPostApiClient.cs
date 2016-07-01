using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public interface IPostApiClient
    {
        Task<object> Post(string requestUri, object data);
        Task<T> Post<T>(string requestUri, object data);
    }
}
