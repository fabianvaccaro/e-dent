﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using mainDB_service.objectClasses;

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

        [OperationContract]
        void createUser(String username, String passwd, String role, String institution);

        [OperationContract]
        bool patienExists(Int32 ID);

        [OperationContract]
        bool dniExists(String DNI);

        [OperationContract]
        K_Patient getPatient(Int32 ID);
    }
}
