using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using generalDB.objectClasses;
using System.Runtime.Serialization;

namespace generalDB
{

    public class op
    {
        
        public K_Patient getPatient(Int32 ID)
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {
                K_Patient _paciente = new K_Patient();
                var myquery = from paciente in entidad.patient
                              where paciente.pac_id == ID
                              select new
                              {
                                  paciente.pac_id,
                                  paciente.pac_ced,
                                  paciente.pac_name,
                                  paciente.pac_lastn,
                                  paciente.pac_born,
                                  paciente.pac_race,
                                  paciente.pac_phone1,
                                  paciente.pac_phone2,
                                  paciente.pac_address,
                                  paciente.pac_job,
                                  paciente.pac_school,
                                  paciente.pac_ensur,
                              };
                try
                {
                    if (!myquery.FirstOrDefault().pac_id.Equals(null))  //verifica si el resultado de la petición no es vacío
                    {
                        _paciente.DNI = myquery.FirstOrDefault().pac_ced;
                        _paciente.Name = myquery.FirstOrDefault().pac_name;
                        _paciente.LastName = myquery.FirstOrDefault().pac_lastn;

                        //para verificar si la fecha de nacimiento está registrada en la base de datos o si se encuentra como NULL
                        DateTime newSelectedDate = DateTime.Now;    //variable DateTime temporal
                        DateTime? dateOrNull = myquery.FirstOrDefault().pac_born;
                        if (dateOrNull != null) //si se encuentra registrada
                        {
                            newSelectedDate = dateOrNull.Value;    //guarda la fecha de nacimiento en la variable newSelectedDate
                        }
                        _paciente.Born = newSelectedDate;

                        _paciente.Race = myquery.FirstOrDefault().pac_race;
                        _paciente.Phone1 = myquery.FirstOrDefault().pac_phone1;
                        _paciente.Phone2 = myquery.FirstOrDefault().pac_phone2;
                        _paciente.Address = myquery.FirstOrDefault().pac_address;
                        _paciente.Job = myquery.FirstOrDefault().pac_job;
                        _paciente.School = myquery.FirstOrDefault().pac_school;
                        _paciente.Ensurance = myquery.FirstOrDefault().pac_ensur;
                        _paciente.Exists = true;
                    }
                }
                catch
                {
                    _paciente.Exists = false;

                }

                return _paciente;

            }

        }
    }
}
