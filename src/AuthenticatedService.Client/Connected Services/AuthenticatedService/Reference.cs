﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Authenticated.WCF.AuthenticatedService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticatedService.IAuthenticatedService")]
    public interface IAuthenticatedService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticatedService/GetUserName", ReplyAction="http://tempuri.org/IAuthenticatedService/GetUserNameResponse")]
        string[] GetUserName();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticatedService/GetUserName", ReplyAction="http://tempuri.org/IAuthenticatedService/GetUserNameResponse")]
        System.Threading.Tasks.Task<string[]> GetUserNameAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticatedServiceChannel : Authenticated.WCF.AuthenticatedService.IAuthenticatedService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticatedServiceClient : System.ServiceModel.ClientBase<Authenticated.WCF.AuthenticatedService.IAuthenticatedService>, Authenticated.WCF.AuthenticatedService.IAuthenticatedService {
        
        public AuthenticatedServiceClient() {
        }
        
        public AuthenticatedServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticatedServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticatedServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticatedServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetUserName() {
            return base.Channel.GetUserName();
        }
        
        public System.Threading.Tasks.Task<string[]> GetUserNameAsync() {
            return base.Channel.GetUserNameAsync();
        }
    }
}
