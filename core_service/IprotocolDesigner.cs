using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace core_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IprotocolDesigner" in both code and config file together.
    [ServiceContract]
    public interface IprotocolDesigner
    {
        [OperationContract]
        void DoWork();


    }
}
