using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock.Client.Console.StockServiceReference;
using Stock.Client.Console.StockWebServiceReference;

namespace Stock.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //WcfConnect();

            WebServiceConnect();
        }

        private static void WcfConnect()
        {
            //Step 1: Create an instance of the WCF proxy.
            StockServiceClient client = new StockServiceClient();

            // Step 2: Call the service operations.
            // Call the Add service operation.
            var value1 = 100;
            var result = client.Get(value1);
            System.Console.WriteLine(result);

            System.Console.ReadLine();

            // Call the Subtract service operation.
            value1 = 145;
            result = client.GetAll(value1);
            System.Console.WriteLine(result);

            System.Console.ReadLine();

            //Step 3: Closing the client gracefully closes the connection and cleans up resources.
            client.Close();

            System.Console.ReadLine();
        }

        private static void WebServiceConnect()
        {
            var client = new StockWebServiceSoapClient();
            System.Console.WriteLine(client.HelloWorld());

            client.Close();

            System.Console.ReadLine();
        }
    }
}
