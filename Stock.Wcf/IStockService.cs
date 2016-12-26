using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Stock.Wcf
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        string GetAll(int value);

        [OperationContract]
        string Get(int value);
    }
}
