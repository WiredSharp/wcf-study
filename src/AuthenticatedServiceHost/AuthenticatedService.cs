using Serilog;
using System;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace AuthenticatedServiceHost
{
    // to continue on https://www.youtube.com/watch?v=EWBgqfhAT9U
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticatedService" in both code and config file together.
    public class AuthenticatedService : IAuthenticatedService, IImpersonationService
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
            IIdentity ctxPrimary = ServiceSecurityContext.Current?.PrimaryIdentity;
            WindowsIdentity ctxWinId = ServiceSecurityContext.Current?.WindowsIdentity;
            WindowsIdentity current = WindowsIdentity.GetCurrent();

            Logger.Information("{0}/{1}/{2} {3}/{4}/{5} {6}/{7}/{8}"
                , ctxPrimary?.Name
                , ctxPrimary?.IsAuthenticated
                , ctxPrimary?.AuthenticationType
                , ctxWinId?.Name
                , ctxWinId?.IsAuthenticated
                , ctxWinId?.AuthenticationType
                , current?.Name
                , current?.IsAuthenticated
                , current?.AuthenticationType);
            return new string[] { ctxPrimary?.Name
                , ctxWinId?.Name
                , current?.Name };
        }

        public string[] Impersonate()
        {
            try
            {
                IIdentity ctxPrimary = ServiceSecurityContext.Current?.PrimaryIdentity;
                WindowsIdentity ctxWinId = ServiceSecurityContext.Current?.WindowsIdentity;
                WindowsIdentity current = WindowsIdentity.GetCurrent();
                using (ctxWinId.Impersonate())
                {
                    var client = new Authentication.AuthenticatedServiceClient();
                    return client.GetUserName();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "unable to impersonate");
                return new string[] { ex.Message };
            }
        }
    }
}
