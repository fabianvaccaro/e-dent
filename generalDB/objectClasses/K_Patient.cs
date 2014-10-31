using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace generalDB.objectClasses
{
    [DataContract]
    [Serializable]
    public class K_Patient
    {
        [DataMember]    
        public Int32 ID { get; set; }
        [DataMember]
        public Int32 DIVID { get; set; }
        [DataMember]    
        public String DNI { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public DateTime Born { get; set; }
        [DataMember]
        public String Race { get; set; }
        [DataMember]
        public String Phone1 { get; set; }
        [DataMember]
        public String Phone2 { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String Job { get; set; }
        [DataMember]
        public String School { get; set; }
        [DataMember]
        public String Ensurance { get; set; }
        [DataMember]
        public Boolean Exists { get; set; }
        [DataMember]
        public String ESTATS { get; set; }


        //Constructor completo
        public K_Patient(String EDNI, String Ename, String Elastn, DateTime Eborn, String Erace, String Ephone1, String Ephone2, String Eaddress, String Ejob, String Eschool, String Eensur, Boolean EExists, String EerrorType)
        {
            DNI = EDNI;
            Name = Ename;
            LastName=Elastn;
            Born = Eborn;
            Race = Erace;
            Phone1 = Ephone1;
            Phone2 = Ephone2;
            Address = Eaddress;
            Job = Ejob;
            School = Eschool;
            Ensurance = Eensur;
            Exists = EExists;
            ESTATS = EerrorType;
        }

        //Constructor general
        public K_Patient()
        {
            DNI = String.Empty;
            Name = String.Empty;
            LastName = String.Empty;
            Born = DateTime.Now;
            Race = String.Empty;
            Phone1 = String.Empty;
            Phone2 = String.Empty;
            Address = String.Empty;
            Job = String.Empty;
            School = String.Empty;
            Ensurance = String.Empty;
            Exists = false;
            ESTATS = String.Empty;
        }

        //Popula el objeto con información de la base de datos a partir del ID registrado dentro de este
        public void getPatientByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var pacienteEncontrado = (from paciente in entidad.patient
                                          where paciente.pac_id == ID
                                          select new
                                          {
                                              paciente
                                          }).FirstOrDefault();
                try
                {
                    if (pacienteEncontrado.paciente!= null)  //verifica si el resultado de la petición no es vacío
                    {
                        DIVID = pacienteEncontrado.paciente.pac_divId;
                        DNI = pacienteEncontrado.paciente.pac_ced;
                        Name = pacienteEncontrado.paciente.pac_name;
                        LastName = pacienteEncontrado.paciente.pac_lastn;

                        //para verificar si la fecha de nacimiento está registrada en la base de datos o si se encuentra como NULL
                        DateTime newSelectedDate = DateTime.Now;    //variable DateTime temporal
                        DateTime? dateOrNull = pacienteEncontrado.paciente.pac_born;
                        if (dateOrNull != null) //si se encuentra registrada
                        {
                            newSelectedDate = dateOrNull.Value;    //guarda la fecha de nacimiento en la variable newSelectedDate
                        }
                        Born = newSelectedDate;

                        Race = pacienteEncontrado.paciente.pac_race;
                        Phone1 = pacienteEncontrado.paciente.pac_phone1;
                        Phone2 = pacienteEncontrado.paciente.pac_phone2;
                        Address = pacienteEncontrado.paciente.pac_address;
                        Job = pacienteEncontrado.paciente.pac_job;
                        School = pacienteEncontrado.paciente.pac_school;
                        Ensurance = pacienteEncontrado.paciente.pac_ensur;
                        Exists = true;
                    }
                }
                catch
                {
                    Exists = false;

                }


            }
        }

        //Actualiza el registro en la base de datos
        public Boolean updatePatient()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                try
                {
                    var pacienteEncontrado = (from paciente in entidad.patient
                                  where paciente.pac_id == ID
                                  select new
                                  {
                                     paciente
                                  }).FirstOrDefault();

                    if (pacienteEncontrado != null)
                    {
                        pacienteEncontrado.paciente.pac_divId = DIVID;
                        pacienteEncontrado.paciente.pac_ced = DNI;
                        pacienteEncontrado.paciente.pac_name = Name;
                        pacienteEncontrado.paciente.pac_lastn = LastName;
                        pacienteEncontrado.paciente.pac_born = Born;
                        pacienteEncontrado.paciente.pac_race = Race;
                        pacienteEncontrado.paciente.pac_phone1 = Phone1;
                        pacienteEncontrado.paciente.pac_phone2 = Phone2;
                        pacienteEncontrado.paciente.pac_address = Address;
                        pacienteEncontrado.paciente.pac_job = Job;
                        pacienteEncontrado.paciente.pac_school = School;
                        pacienteEncontrado.paciente.pac_ensur = Ensurance;

                        entidad.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }


            }
        }


        //verifies if a DNI has been recorded previuously
        Boolean checkDNI()
        {
            using (cdentalEntities context = new cdentalEntities())
            {
                var pacienteEncontrado = (from paciente in context.patient
                                          where paciente.pac_ced == DNI
                                          select new
                                          {
                                              paciente
                                          }).FirstOrDefault();
                try
                {
                    if (pacienteEncontrado.paciente != null)  //verifica si el resultado de la petición no es vacío
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }
        //add record to database
        public Int32 addRecord()
        {
            using (cdentalEntities context = new cdentalEntities())
            {

                patient patientObj = new patient();
                patientObj.pac_divId = DIVID;
                patientObj.pac_ced = DNI;
                patientObj.pac_name = Name;
                patientObj.pac_lastn = LastName;
                patientObj.pac_born = Born;
                patientObj.pac_race = Race;
                patientObj.pac_phone1 = Phone1;
                patientObj.pac_phone2 = Phone2;
                patientObj.pac_address = Address;
                patientObj.pac_job = Job;
                patientObj.pac_school = School;
                patientObj.pac_ensur = Ensurance;

                try
                {
                    if(!checkDNI())
                    {
                        context.patient.Add(patientObj);
                        context.SaveChanges();
                        ESTATS = "Correcto";
                        return patientObj.pac_id;
                        
                    }
                    else
                    {
                        ESTATS = "El DNI seleccionado ya existe";
                        return 0;
                    }
                    
                }
                catch(Exception e)
                {
                    ESTATS = e.ToString();
                    return 0;
                }
                return patientObj.pac_id;
            }
        }

       
    }
}