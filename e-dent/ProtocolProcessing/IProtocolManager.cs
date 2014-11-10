using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace e_dent.ProtocolProcessing
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProtocolManager" in both code and config file together.
    [ServiceContract]
    public interface IProtocolManager
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
