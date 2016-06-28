using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PairingTest.Web.Services;

namespace PairingTest.Web.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IServiceUriProvider>()
                    .ImplementedBy<ServiceUriProvider>()
                    .LifestylePerWebRequest());
            container.Register(
                Component
                    .For<IGetApiClient>()
                    .ImplementedBy<WebApiClient>()
                    .LifestylePerWebRequest());
            container.Register(
                Component
                    .For<IQuestionnaireService>()
                    .ImplementedBy<QuestionnaireService>()
                    .LifestylePerWebRequest());
        }
    }
}