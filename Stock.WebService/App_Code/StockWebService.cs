using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web.Services;
using System.Web.Services.Protocols;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;
using Newtonsoft.Json;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class StockWebService : WebService
{
    public StockWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /// <summary>
    /// Get stock price by code
    /// </summary>
    /// <param name="codes">Stock codes</param>
    /// <example>DDD,MMM</example>
    /// <returns></returns>
    [WebMethod]
    public string GetStockPrice(string codes)
    {
        var prices = new Dictionary<string, int>();
        var codeArray = codes.Split(',');

        var random = new Random();

        foreach (var code in codeArray)
        {
            if(prices.Keys.Contains(code))
                continue;
            prices.Add(code, random.Next(1, 1000));
        }

        var result = JsonConvert.SerializeObject(prices);

        return result;
    }

    /// <summary>
    /// Get stock price by code
    /// </summary>
    /// <param name="codes">Stock codes</param>
    /// <example>DDD,MMM</example>
    /// <returns></returns>
    [WebMethod]
    public string GetStockPriceSigned(string codes)
    {
        //var prices = new Dictionary<string, int>();
        //var codeArray = codes.Split(',');

        //var random = new Random();

        //foreach (var code in codeArray)
        //{
        //    if (prices.Keys.Contains(code))
        //        continue;
        //    prices.Add(code, random.Next(1, 1000));
        //}

        //var result = JsonConvert.SerializeObject(prices);

        //return result;

        // Only accept SOAP requests
        SoapContext requestContext = RequestSoapContext.Current;
        if (requestContext == null)
        {
            throw new ApplicationException("Non-SOAP request.");
        }
        // Look for Signatures in the Elements collection
        foreach (Object elem in requestContext.Security.Elements)
        {
            if (elem is Signature)
            {
                Signature sign = (Signature)elem;
                // Verify that signature signs the body of the request
                //if (sign != null
                //    && (sign.SignatureOptions &
                //        SignatureOptions.IncludeSoapBody) != 0)
                //{
                //    // Determine what kind of token is used 
                //    // with the signature.
                //    if (sign.SecurityToken is UsernameToken)
                //    {
                //        return "Hello " +
                //            ((UsernameToken)sign.SecurityToken).Username;
                //    }
                //    else if (sign.SecurityToken is X509SecurityToken)
                //    {
                //        return "Hello " +
                //           ((X509SecurityToken)sign.SecurityToken)
                //           .Certificate.GetName();
                //    }
                //}
            }
        }
        // No approriate signature found
        throw new SoapException("No valid signature found",
            SoapException.ClientFaultCode);
    }

   
}