﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCValidator.creditCardService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webservicex.net", ConfigurationName="creditCardService.CCCheckerSoap")]
    public interface CCCheckerSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webservicex.net/ValidateCardNumber", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ValidateCardNumber(string cardType, string cardNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webservicex.net/ValidateCardNumber", ReplyAction="*")]
        System.Threading.Tasks.Task<string> ValidateCardNumberAsync(string cardType, string cardNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CCCheckerSoapChannel : CCValidator.creditCardService.CCCheckerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CCCheckerSoapClient : System.ServiceModel.ClientBase<CCValidator.creditCardService.CCCheckerSoap>, CCValidator.creditCardService.CCCheckerSoap {
        
        public CCCheckerSoapClient() {
        }
        
        public CCCheckerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CCCheckerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CCCheckerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CCCheckerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ValidateCardNumber(string cardType, string cardNumber) {
            return base.Channel.ValidateCardNumber(cardType, cardNumber);
        }
        
        public System.Threading.Tasks.Task<string> ValidateCardNumberAsync(string cardType, string cardNumber) {
            return base.Channel.ValidateCardNumberAsync(cardType, cardNumber);
        }
    }
}
