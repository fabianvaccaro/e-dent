using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace mainDB_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ImainDB_service" in both code and config file together.
    [ServiceContract]
    public interface ImainDB_service
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        String getUsername(Int32 ID);

    }
}
