using Serilog;
using System;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace AuthenticatedServiceHost
{
    // to continue on https://www.youtube.com/watch?v=EWBgqfhAT9U
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticatedService" in both code and config file together.
    public class AuthenticatedService : IAuthenticatedService
    {
        private static ILogger Logger = Log.ForContext<AuthenticatedService>();

        //public static void Configure(ServiceConfiguration config)
        //{
        //    Logger.Debug("starting service configuration...");
        //    config.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
        //    config.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
        //    config.AddServiceEndpoint(typeof(IAuthenticatedService), new WSHttpBinding(), "");
        //    //config.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexNamedPipeBinding(), "mex");
        //    Logger.Debug("...service configuration completed");
        //}

        public string[] GetUserName()
        {
            Logger.Information("{@ServicePrimaryIdentity} {@ServiceWindowsIdentity} {@CurrentWindowsIdentity}", ServiceSecurityContext.Current.PrimaryIdentity, ServiceSecurityContext.Current.WindowsIdentity, WindowsIdentity.GetCurrent());
            return new string[] { ServiceSecurityContext.Current.PrimaryIdentity?.Name, ServiceSecurityContext.Current.WindowsIdentity?.Name, WindowsIdentity.GetCurrent()?.Name };
        }
    }
}
