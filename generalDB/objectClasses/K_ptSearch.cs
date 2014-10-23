using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using generalDB.objectClasses;

namespace generalDB.objectClasses
{
    [DataContract]
    [Serializable]
    class K_ptSearch
    {
        //Parámetros del objeto
        [DataMember]
        public Int32 DIVID { get; set; }    //es necesario fijar el DIVID para poder realizar la búsqueda
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public String DNI { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String Phone { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String School { get; set; }

        //Constructor general
        public K_ptSearch()
        {
            ID = 0;
            DIVID = 0;
            DNI = String.Empty;
            Name = String.Empty;
            LastName = String.Empty;
            Phone = String.Empty;
            Address = String.Empty;
            School = String.Empty;
        }

        //Método para encontar pacientes con caracterísiticas similares a los parametros incluidos en el objeto
        public K_Patient[] listAll()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var pacienteEncontrado = (from paciente in entidad.patient
                                          where ((paciente.pac_divId == DIVID) && (paciente.pac_name.Contains(Name) || paciente.pac_lastn.Contains(LastName) || paciente.pac_school.Contains(School) || paciente.pac_ced.Contains(DNI) || paciente.pac_phone1.Contains(Phone) || paciente.pac_phone2.Contains(Phone)))
                                          select new
                                          {
                                              paciente
                                          }).ToList();
               
                try
                {
                    if (pacienteEncontrado != null)  //verifica si el resultado de la petición no es vacío
                    {

                        K_Patient[] listado = new K_Patient[pacienteEncontrado.Count()];
                        int cnt = 0;
                        foreach (var a in pacienteEncontrado)
                        {
                            listado[cnt].ID = a.paciente.pac_id;
                            listado[cnt].getPatientByID();
                            cnt++;
                        }
                        return listado;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;

                }
            }
        }

        //Lista todos los pacientes correspondientes a una división
        public K_Patient[] byDivision()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var pacienteEncontrado = (from paciente in entidad.patient
                                          where (paciente.divisions.div_id == DIVID)
                                          select new
                                          {
                                              paciente
                                          }).ToList();

                try
                {
                    if (pacienteEncontrado != null)  //verifica si el resultado de la petición no es vacío
                    {

                        K_Patient[] listado = new K_Patient[pacienteEncontrado.Count()];
                        int cnt = 0;
                        foreach (var a in pacienteEncontrado)
                        {
                            listado[cnt].ID = a.paciente.pac_id;
                            listado[cnt].getPatientByID();
                            cnt++;
                        }
                        return listado;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;

                }
            }
        }



        public void entrania()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var pacienteEncontrado = (from paciente in entidad.patient
                                          where paciente.divisions.institutions.ins_id == 1
                                          select new
                                          {
                                              paciente
                                          }).ToList();
                try
                {
                    if (pacienteEncontrado != null)  //verifica si el resultado de la petición no es vacío
                    {
                        foreach(var a in pacienteEncontrado)
                        {
                            a.paciente.pac_name = "cooooño";
                        }
                    }
                }
                catch
                {
                    

                }


            }
        }


    }
}
