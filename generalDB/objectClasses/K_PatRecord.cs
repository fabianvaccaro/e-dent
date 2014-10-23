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
    class K_PatRecord
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Int32 PACID { get; set; }
        [DataMember]
        public Int32 CHID { get; set; }
        [DataMember]
        public Int32 PATID { get; set; }
        [DataMember]
        public String DENTALLOC { get; set; }
        [DataMember]
        public String FACIALLOC { get; set; }
        [DataMember]
        public int? GRAVITY { get; set; }
        [DataMember]
        public String PREVTREAT { get; set; }
        [DataMember]
        public String MEDIC { get; set; }
        [DataMember]
        public DateTime? REGDATE { get; set; }
        [DataMember]
        public String ESTATS { get; set; }
        //constructor general
        public K_PatRecord()
        {
            ID = 0;
            PACID = 0;
            CHID = 0;
            PATID = 0;
            DENTALLOC = String.Empty;
            FACIALLOC = String.Empty;
            GRAVITY = 0;
            PREVTREAT = String.Empty;
            MEDIC = String.Empty;
            REGDATE = DateTime.Now;
            ESTATS = String.Empty;
        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var Encontrado = (from ptrecord in entidad.patient_record
                                          where ptrecord.pr_id == ID
                                          select new
                                          {
                                              ptrecord
                                          }).FirstOrDefault();
                try
                {
                    if(Encontrado.ptrecord != null)
                    {
                        PACID = Encontrado.ptrecord.pr_pacid;
                        CHID = Encontrado.ptrecord.pr_chid;
                        PATID = Encontrado.ptrecord.pr_patid;
                        DENTALLOC = Encontrado.ptrecord.pr_dentalloc;
                        FACIALLOC = Encontrado.ptrecord.pr_facialloc;
                        GRAVITY = Encontrado.ptrecord.pr_gravity;
                        MEDIC = Encontrado.ptrecord.pr_medic;
                        REGDATE = Encontrado.ptrecord.pr_regdate;
                        ESTATS = "Record found";
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch(Exception e)
                {
                    ESTATS = e.ToString();
                    return false;
                }

            }
        }


        public Boolean updateRecord()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var finding = (from record in entidad.patient_record
                               where record.pr_id == ID
                               select new
                               {
                                   record
                               }).FirstOrDefault();

                try
                {
                    if (finding.record != null)  //verifica si el resultado de la petición no es vacío
                    {
                        finding.record.pr_pacid = PACID;
                        finding.record.pr_chid = CHID;
                        finding.record.pr_patid = PATID;
                        finding.record.pr_dentalloc = DENTALLOC;
                        finding.record.pr_facialloc = FACIALLOC;
                        finding.record.pr_gravity = GRAVITY;
                        finding.record.pr_prevtreat = PREVTREAT;
                        finding.record.pr_medic = MEDIC;
                        finding.record.pr_regdate = REGDATE;
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


        //add record to database
        public Boolean addRecord()
        {
            using (cdentalEntities context = new cdentalEntities())
            {
                patient_record prObj = new patient_record();


                prObj.pr_pacid = PACID;
                prObj.pr_chid = CHID;
                prObj.pr_patid = PATID;
                prObj.pr_dentalloc = DENTALLOC;
                prObj.pr_facialloc = FACIALLOC;
                prObj.pr_gravity = GRAVITY;
                prObj.pr_prevtreat = PREVTREAT;
                prObj.pr_medic = MEDIC;
                prObj.pr_regdate = REGDATE;
                try
                {

                    context.patient_record.Add(prObj);
                    context.SaveChanges();
                    ESTATS = "Correcto";
                    return true;
                    

                }
                catch (Exception e)
                {
                    ESTATS = e.ToString();
                    return false;
                }
                
            }
        } 


    }
}
