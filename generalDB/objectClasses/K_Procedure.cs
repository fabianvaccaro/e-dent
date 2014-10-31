using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace generalDB.objectClasses
{
    [DataContract]
    [Serializable]
    public class K_Procedure
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Int32 PACID { get; set; }
        [DataMember]
        public Int32 OPID { get; set; }
        [DataMember]
        public Int32 TMID { get; set; }
        [DataMember]
        public Int32 TRID { get; set; }
        [DataMember]
        public String OBSERVATIONS { get; set; }
        [DataMember]
        public DateTime? PLANDATE { get; set; }
        [DataMember]
        public DateTime? PROCDATE { get; set; }
        [DataMember]
        public String STATUS { get; set; }
        [DataMember]
        public float? GENPRICE { get; set; }
        [DataMember]
        public float? DISCOUNT { get; set; }
        [DataMember]
        public String EVALUATION { get; set; }
        [DataMember]
        public String ESTATS { get; set; }
        

        public K_Procedure()
        {
            ID = 0;
            PACID = 0;
            OPID = 0;
            TMID = 0;
            TRID = 0;
            OBSERVATIONS = String.Empty;
            PLANDATE = DateTime.Now;
            PROCDATE = DateTime.Now;
            STATUS = String.Empty;
            GENPRICE = 0;
            DISCOUNT = 0;
            EVALUATION = String.Empty;
            ESTATS = String.Empty;

        }


        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.procedures
                                  where arecord.pr_id == ID
                                  select new
                                  {
                                      arecord
                                  }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        PACID = xdf.arecord.pr_pacid;
                        OPID = xdf.arecord.pr_opid;
                        TMID = xdf.arecord.pr_tmid;
                        TRID = xdf.arecord.pr_trid;
                        OBSERVATIONS = xdf.arecord.pr_observations;
                        PLANDATE = xdf.arecord.pr_plandate;
                        PROCDATE = xdf.arecord.pr_procdate;
                        STATUS = xdf.arecord.pr_status;
                        GENPRICE = xdf.arecord.pr_genprice;
                        DISCOUNT = xdf.arecord.pr_discount;
                        EVALUATION = xdf.arecord.pr_evaluation;
                        ESTATS = "Record found";
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
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

                var xdf = (from arecord in entidad.procedures
                           where arecord.pr_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.pr_pacid = PACID;
                        xdf.arecord.pr_opid = OPID;
                        xdf.arecord.pr_tmid = TMID;
                        xdf.arecord.pr_trid = TRID;
                        xdf.arecord.pr_observations = OBSERVATIONS;
                        xdf.arecord.pr_plandate = PLANDATE;
                        xdf.arecord.pr_procdate = PROCDATE;
                        xdf.arecord.pr_status = STATUS;
                        xdf.arecord.pr_genprice = GENPRICE;
                        xdf.arecord.pr_discount = DISCOUNT;
                        xdf.arecord.pr_evaluation = EVALUATION;
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
                procedures xdf = new procedures();

                xdf.pr_pacid = PACID;
                xdf.pr_opid = OPID;
                xdf.pr_tmid = TMID;
                xdf.pr_trid = TRID;
                xdf.pr_observations = OBSERVATIONS;
                xdf.pr_plandate = PLANDATE;
                xdf.pr_procdate = PROCDATE;
                xdf.pr_status = STATUS;
                xdf.pr_genprice = GENPRICE;
                xdf.pr_discount = DISCOUNT;
                xdf.pr_evaluation = EVALUATION;

                try
                {

                    context.procedures.Add(xdf);
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
