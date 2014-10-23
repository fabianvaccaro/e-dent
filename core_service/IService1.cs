﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace core_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string obtenerNombre(Int32 ID);

        [OperationContract]
        Boolean actualizarNombre(Int32 eID, String nuevonombre);

        [OperationContract]
        Boolean registrarNombre(String nombrecillo);
    }
}
