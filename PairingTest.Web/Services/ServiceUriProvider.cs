using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PairingTest.Web.Services
{
    public class ServiceUriProvider : IServiceUriProvider
    {
        public string BaseUri
        {
            get
            {
                return ConfigurationManager.AppSettings["QuestionnaireServiceBaseUri"];
            }
        }
    }
}