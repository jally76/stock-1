using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Stock.Wcf
{
    public class StockService : IStockService
    {
        public string GetAll(int value)
        {
            Console.WriteLine(value);
            return string.Format("You entered: {0}", value);
        }

        public string Get(int value)
        {
            Console.WriteLine(value);
            return string.Format("You entered: {0}", value);
        }
    }
}
