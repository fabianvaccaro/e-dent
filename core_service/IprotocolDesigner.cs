﻿using System;
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

        [OperationContract]
        String insertarPaso(Int32 TipoPaso, String ProtocoloID, String PadreID, Boolean LadoPaso = true);

        [OperationContract]
        void iniciarProtocolManager(String UserID = "usuarioBeta");

        [OperationContract]
        String nuevoProtocolo(String UserID = "usuarioBeta");

        [OperationContract]
        String pruebaSesion(Int32 coge);

    }
}
