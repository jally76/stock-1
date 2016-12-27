using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
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
}