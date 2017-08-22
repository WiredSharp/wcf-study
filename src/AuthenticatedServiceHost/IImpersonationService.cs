using System.ServiceModel;

namespace AuthenticatedServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImpersonationService" in both code and config file together.
    [ServiceContract]
    public interface IImpersonationService
    {
        [OperationContract]
        string[] Impersonate();
    }
}
