using System.ServiceModel;

namespace AuthenticatedServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthenticatedService" in both code and config file together.
    [ServiceContract]
    public interface IAuthenticatedService
    {
        [OperationContract]
        string[] GetUserName();
    }
}
