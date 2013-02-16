using System;
using System.IO;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NServiceBus;
using Quotefish.Core.Aop.Interceptors;
using log4net.Config;

namespace Quotefish.CategoryService 
{
    public class EndpointConfig : IConfigureThisEndpoint, IWantToRunAtStartup
    {
        public void Run()
        {
            Console.WriteLine("Quotefish Category Service Starting ");
        }

        public void Stop()
        {
        }
    }

    public class EndPointCustomization : IWantCustomInitialization
    {
        private const string LogFilePath = "Configuration/Log4net/Log4net.config";
        private const string WindsorConfigFilePath = "Configuration/Windsor/Windsor.config";
        private const string EndPointName = "CategoryService";
        private const string QuotefishAssemblyNamePrefix = "Quotefish";

        public void Init()
        {
            var container = new WindsorContainer();

            var path = AppDomain.CurrentDomain.BaseDirectory;

            SetLoggingLibrary
                .Log4Net(
                    () => XmlConfigurator
                            .ConfigureAndWatch(
                                new FileInfo(Path.Combine(path, LogFilePath))));

            string windsorConfigFilepath = Path.Combine(path, WindsorConfigFilePath);

            container.Install(Castle.Windsor.Installer.Configuration.FromXmlFile(windsorConfigFilepath));

            container
                .Register(
                    AllTypes
                        .FromAssemblyInDirectory(new AssemblyFilter(Environment.CurrentDirectory))
                        .Where(t => t.FullName.StartsWith(QuotefishAssemblyNamePrefix))
                        .WithServiceDefaultInterfaces());

            BasedOnDescriptor descriptor
                = AllTypes
                    .FromAssemblyInDirectory(new AssemblyFilter(Environment.CurrentDirectory))
                    .Where(t => t.FullName.StartsWith(QuotefishAssemblyNamePrefix))
                    .WithServiceDefaultInterfaces();

            container
                .Register(descriptor
                .Configure(c =>
                {
                    var a = c.LifeStyle.Is(LifestyleType.Transient)
                    .Interceptors(new InterceptorReference(typeof(LoggingInterceptor)))
                    .Anywhere;
                })
                .WithService.DefaultInterfaces());

            Configure.With()
                .DefineEndpointName(EndPointName)
                .EnlistWithDistributor()
                .Log4Net()
                .CastleWindsorBuilder(container)
                .XmlSerializer()
                .MsmqTransport()
                .DisableTimeoutManager()
                .MsmqSubscriptionStorage()
                .UnicastBus()
                .LoadMessageHandlers();

            //WindsorContainerAdapter windsorContainerAdapter = new WindsorContainerAdapter(container);
            //ServiceLocator.Configure(windsorContainerAdapter);

        }
    }
}
