using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace core_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IpatientManagement" in both code and config file together.
    [ServiceContract]
    public interface IpatientManagement
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        generalDB.objectClasses.K_Patient getPatientByID(Int32 ID);

        [OperationContract]
        Int32 registerPatient(String CED, String NAME, String LASTN, DateTime BORN, String PHONE1, String PHONE2, String ADDRESS, String JOB, String SCHOOL, String ENSUR, Int32 DIVID);
    }
}
