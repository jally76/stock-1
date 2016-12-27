﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stock.Client.Web.StockWebServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StockWebServiceReference.StockWebServiceSoap")]
    public interface StockWebServiceSoap {
        
        // CODEGEN: Generating message contract since element name codes from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetStockPrice", ReplyAction="*")]
        Stock.Client.Web.StockWebServiceReference.GetStockPriceResponse GetStockPrice(Stock.Client.Web.StockWebServiceReference.GetStockPriceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetStockPrice", ReplyAction="*")]
        System.Threading.Tasks.Task<Stock.Client.Web.StockWebServiceReference.GetStockPriceResponse> GetStockPriceAsync(Stock.Client.Web.StockWebServiceReference.GetStockPriceRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetStockPriceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetStockPrice", Namespace="http://tempuri.org/", Order=0)]
        public Stock.Client.Web.StockWebServiceReference.GetStockPriceRequestBody Body;
        
        public GetStockPriceRequest() {
        }
        
        public GetStockPriceRequest(Stock.Client.Web.StockWebServiceReference.GetStockPriceRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetStockPriceRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string codes;
        
        public GetStockPriceRequestBody() {
        }
        
        public GetStockPriceRequestBody(string codes) {
            this.codes = codes;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetStockPriceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetStockPriceResponse", Namespace="http://tempuri.org/", Order=0)]
        public Stock.Client.Web.StockWebServiceReference.GetStockPriceResponseBody Body;
        
        public GetStockPriceResponse() {
        }
        
        public GetStockPriceResponse(Stock.Client.Web.StockWebServiceReference.GetStockPriceResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetStockPriceResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetStockPriceResult;
        
        public GetStockPriceResponseBody() {
        }
        
        public GetStockPriceResponseBody(string GetStockPriceResult) {
            this.GetStockPriceResult = GetStockPriceResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface StockWebServiceSoapChannel : Stock.Client.Web.StockWebServiceReference.StockWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockWebServiceSoapClient : System.ServiceModel.ClientBase<Stock.Client.Web.StockWebServiceReference.StockWebServiceSoap>, Stock.Client.Web.StockWebServiceReference.StockWebServiceSoap {
        
        public StockWebServiceSoapClient() {
        }
        
        public StockWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StockWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Stock.Client.Web.StockWebServiceReference.GetStockPriceResponse Stock.Client.Web.StockWebServiceReference.StockWebServiceSoap.GetStockPrice(Stock.Client.Web.StockWebServiceReference.GetStockPriceRequest request) {
            return base.Channel.GetStockPrice(request);
        }
        
        public string GetStockPrice(string codes) {
            Stock.Client.Web.StockWebServiceReference.GetStockPriceRequest inValue = new Stock.Client.Web.StockWebServiceReference.GetStockPriceRequest();
            inValue.Body = new Stock.Client.Web.StockWebServiceReference.GetStockPriceRequestBody();
            inValue.Body.codes = codes;
            Stock.Client.Web.StockWebServiceReference.GetStockPriceResponse retVal = ((Stock.Client.Web.StockWebServiceReference.StockWebServiceSoap)(this)).GetStockPrice(inValue);
            return retVal.Body.GetStockPriceResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Stock.Client.Web.StockWebServiceReference.GetStockPriceResponse> Stock.Client.Web.StockWebServiceReference.StockWebServiceSoap.GetStockPriceAsync(Stock.Client.Web.StockWebServiceReference.GetStockPriceRequest request) {
            return base.Channel.GetStockPriceAsync(request);
        }
        
        public System.Threading.Tasks.Task<Stock.Client.Web.StockWebServiceReference.GetStockPriceResponse> GetStockPriceAsync(string codes) {
            Stock.Client.Web.StockWebServiceReference.GetStockPriceRequest inValue = new Stock.Client.Web.StockWebServiceReference.GetStockPriceRequest();
            inValue.Body = new Stock.Client.Web.StockWebServiceReference.GetStockPriceRequestBody();
            inValue.Body.codes = codes;
            return ((Stock.Client.Web.StockWebServiceReference.StockWebServiceSoap)(this)).GetStockPriceAsync(inValue);
        }
    }
}
