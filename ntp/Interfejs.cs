using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ntp
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Komp Sabiranje(Komp k1, Komp k2);
        [OperationContract]
        Komp Oduzimanje(Komp k1, Komp k2);
        [OperationContract]
        Komp Mnozenje(Komp k1, Komp k2);
        [OperationContract]
        Komp Deljenje(Komp k1, Komp k2);



    }
}
