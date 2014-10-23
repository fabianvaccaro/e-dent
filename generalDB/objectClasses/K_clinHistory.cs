using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace generalDB.objectClasses
{
    [DataContract]
    [Serializable]
    class K_clinHistory
    {
        [DataMember]
        public Int32 CHCODE { get; set; }
        [DataMember]
        public Int32 PACID { get; set; }
        [DataMember]
        public Int32 OPID { get; set; }
        [DataMember]
        public String INTERROG { get; set; }
        [DataMember]
        public DateTime REGDATE { get; set; }
        [DataMember]
        public String ESTATS { get; set; }



        //constructor general
        public K_clinHistory()
        {
            CHCODE = 0;
            PACID = 0;
            OPID = 0;
            INTERROG = String.Empty;
            REGDATE = DateTime.Now;
            ESTATS = String.Empty;
        }

        //obtiene historia clínica por el el código de historia
        public Boolean getByCode()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var finding = (from ch in entidad.clinical_history
                               where ch.ch_code == CHCODE
                               select new
                               {
                                   ch
                               }).FirstOrDefault();

                try
                {
                    if (finding.ch != null)  //verifica si el resultado de la petición no es vacío
                    {
                        PACID = finding.ch.ch_pacid;
                        OPID = finding.ch.ch_operator;
                        INTERROG = finding.ch.ch_interrog;
                        //para verificar si la fecha  está registrada en la base de datos o si se encuentra como NULL
                        DateTime newSelectedDate = DateTime.Now;    //variable DateTime temporal
                        DateTime? dateOrNull = finding.ch.ch_regdate;
                        if (dateOrNull != null) //si se encuentra registrada
                        {
                            newSelectedDate = dateOrNull.Value;    //guarda la fecha de nacimiento en la variable newSelectedDate
                        }
                        REGDATE = newSelectedDate;

                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        //obtiene historia clínica por el el ID del paciente
        public Boolean getByPACID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var finding = (from ch in entidad.clinical_history
                               where ch.ch_pacid == PACID
                               select new
                               {
                                   ch
                               }).FirstOrDefault();

                try
                {
                    if (finding.ch != null)  //verifica si el resultado de la petición no es vacío
                    {
                        CHCODE = finding.ch.ch_code;
                        OPID = finding.ch.ch_operator;
                        INTERROG = finding.ch.ch_interrog;
                        //para verificar si la fecha  está registrada en la base de datos o si se encuentra como NULL
                        DateTime newSelectedDate = DateTime.Now;    //variable DateTime temporal
                        DateTime? dateOrNull = finding.ch.ch_regdate;
                        if (dateOrNull != null) //si se encuentra registrada
                        {
                            newSelectedDate = dateOrNull.Value;    //guarda la fecha de nacimiento en la variable newSelectedDate
                        }
                        REGDATE = newSelectedDate;

                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        //actualiza el registro de historia clínica
        public Boolean updateCH()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var finding = (from ch in entidad.clinical_history
                               where ch.ch_code == CHCODE
                               select new
                               {
                                   ch
                               }).FirstOrDefault();

                try
                {
                    if (finding.ch != null)  //verifica si el resultado de la petición no es vacío
                    {
                        finding.ch.ch_pacid = PACID;
                        finding.ch.ch_operator = OPID;
                        finding.ch.ch_interrog = INTERROG;
                        finding.ch.ch_regdate = REGDATE;
                        entidad.SaveChanges();  //guarda los cambios en la DB
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }

        }

        //Verifica si ya existe un registro asignado a un paciente
        public Boolean checkPac()
        {
            using (cdentalEntities context = new cdentalEntities())
            {
                var registro = (from ch in context.clinical_history
                                          where ch.ch_pacid == PACID
                                          select new
                                          {
                                              ch
                                          }).FirstOrDefault();
                try
                {
                    if (registro.ch != null)  //verifica si el resultado de la petición no es vacío
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
        public Boolean addRecord()
        {
            using (cdentalEntities context = new cdentalEntities())
            {
                clinical_history chObj = new clinical_history();
                chObj.ch_pacid = PACID;
                chObj.ch_operator = OPID;
                chObj.ch_interrog = INTERROG;
                chObj.ch_regdate = REGDATE;

                try
                {
                    if (!checkPac())
                    {
                        context.clinical_history.Add(chObj);
                        context.SaveChanges();
                        ESTATS = "Correcto";

                    }
                    else
                    {
                        ESTATS = "El DNI seleccionado ya existe";
                        return false;
                    }

                }
                catch (Exception e)
                {
                    ESTATS = e.ToString();
                    return false;
                }
                return true;
            }
        }
    }
}