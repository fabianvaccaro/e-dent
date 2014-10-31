using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace core_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "patientManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select patientManagement.svc or patientManagement.svc.cs at the Solution Explorer and start debugging.
    public class patientManagement : IpatientManagement
    {
        public void DoWork()
        {
        }

        public Int32 registerPatient(String CED, String NAME, String LASTN, DateTime BORN, String PHONE1, String PHONE2, String ADDRESS, String JOB, String SCHOOL, String ENSUR, Int32 DIVID)
        {
            //Crea una instancia de  paciente
            generalDB.objectClasses.K_Patient paciente = new generalDB.objectClasses.K_Patient(); //asi
            paciente.DIVID = DIVID;
            paciente.DNI = CED;
            paciente.Name = NAME;
            paciente.LastName = LASTN;
            paciente.Born = BORN;
            paciente.Phone1 = PHONE1;
            paciente.Phone2 = PHONE2;
            paciente.Address = ADDRESS;
            paciente.Job = JOB;
            paciente.School = SCHOOL;
            paciente.Ensurance = ENSUR;

            return paciente.addRecord();
        }
        //Retorna un objeto K_Patient populado
        public generalDB.objectClasses.K_Patient getPatientByID(Int32 ID)
        {
            generalDB.objectClasses.K_Patient paciente = new generalDB.objectClasses.K_Patient();
            paciente.ID=ID;
            paciente.getPatientByID();
            return paciente;
        }
    }
}
