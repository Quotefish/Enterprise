using System;
using NServiceBus;
using NServiceBus.Config;

namespace Quotefish.Messaging.Distributor 
{
    public class EndpointConfig : IConfigureThisEndpoint, IWantToRunAtStartup
    {
        public void Run()
        {
            Console.WriteLine("Quotefish.Messaging.Distributor running ...");
        }

        public void Stop()
        {

        }
    }

    public class ConfiguringTheDistributorWithTheFluentApi : INeedInitialization
    {
        public const string EndPointName = "Quotefish.Messaging.Distributor";

        public void Init()
        {
            Configure.Instance.RunDistributorWithNoWorkerOnItsEndpoint()
                .DefineEndpointName(EndPointName)
                .MsmqTransport()
                .DisableTimeoutManager()
                .MsmqSubscriptionStorage()
                .UnicastBus()
                .LoadMessageHandlers();
        }

    }
}