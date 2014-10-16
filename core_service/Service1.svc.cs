using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using generalDB;



namespace core_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public String obtenerNombre(Int32 eID)
        {
            generalDB.objectClasses.K_Patient _paciente = new generalDB.objectClasses.K_Patient();
            _paciente.ID = eID;
            _paciente.getPatientByID();
            if (_paciente.Exists)
            {
                return _paciente.Name;
            }
            else
            {
                return "no existe paciente";
            }

        }

        public Boolean actualizarNombre(Int32 eID, String nuevonombre)
        {
            generalDB.objectClasses.K_Patient _paciente = new generalDB.objectClasses.K_Patient();
            _paciente.ID = eID;
            _paciente.getPatientByID();
            if (_paciente.Exists)
            {
                _paciente.Name = nuevonombre;
                if(_paciente.updatePatient())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
