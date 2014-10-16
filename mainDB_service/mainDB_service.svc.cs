using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using mainDB_service.objectClasses;

namespace mainDB_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "mainDB_service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select mainDB_service.svc or mainDB_service.svc.cs at the Solution Explorer and start debugging.


    //Estructuras de objetos


    public class mainDB_service : ImainDB_service
    {
        public void DoWork()
        {
        }// no hace nada

        //Obtiene el nombre de <username> correspondiente al <ID> en la tabla users. Retorna "NOTFOUND" si no lo encuentra.
        public String getUsername(Int32 ID)
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {
                var nombrequery = from user in entidad.users
                                 where user.usr_id == ID
                                 select new
                                 {
                                     user.username,
                                     user.role
                                 };

                //nombrequery.Take(10).Skip(20);,
                String respuesta = String.Empty;
                try
                {
                    if (!nombrequery.FirstOrDefault().username.Equals(null))
                    {
                        respuesta = nombrequery.FirstOrDefault().username;
                    }
                }
                catch
                {
                    respuesta = "NOTFOUND";
                }
                return respuesta;
            }
        }


        //Crea un registro en la tabla users
        public void createUser(String Eusername, String Epasswd, String Erole, String Einstitution)
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {
                users k_user = new users();
                k_user.username = Eusername;
                k_user.passwd_md5 = Epasswd;
                k_user.role = Erole;
                k_user.last_login = DateTime.Now;
                k_user.institution = Einstitution; // string.Empty;
                entidad.users.Add(k_user);  //add user
                entidad.SaveChanges();  //save changes
            }
        }

        //verifica si existe el ID de paciente
        public bool patienExists(Int32 ID)
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {
                var myquery = from paciente in entidad.patient
                              where paciente.pac_id == ID
                              select new
                              {
                                  paciente.pac_id
                              };
                bool respuesta = false; //declara la variable respuesta
                try
                {
                    if (!myquery.FirstOrDefault().pac_id.Equals(null))  //verifica si el resultado de la petición es vacío
                    {
                        respuesta = true;   // true si encuentra el registro 
                    }
                }
                catch
                {
                    respuesta = false;    // false si no encuentra el registro
                }
                return respuesta;

            }
        }

        //verifica si el DNI se encuentra registrado
        public bool dniExists(String DNI)
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {
                var myquery = from paciente in entidad.patient
                              where paciente.pac_ced == DNI
                              select new
                              {
                                  paciente.pac_id
                              };
                bool respuesta = false; //declara la variable respuesta
                try
                {
                    if (!myquery.FirstOrDefault().pac_id.Equals(null))  //verifica si el resultado de la petición es vacío
                    {
                        respuesta = true;   // true si encuentra el registro 
                    }
                }
                catch
                {
                    respuesta = false;    // false si no encuentra el registro
                }
                return respuesta;

            }
        }

        //obtiene registros de un paciente por su ID
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
