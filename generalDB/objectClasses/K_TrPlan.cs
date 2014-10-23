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
    class K_TrPlan
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Int32 PACID { get; set; }
        [DataMember]
        public Int32 TRID { get; set; }
        [DataMember]
        public DateTime REGDATE { get; set; }
        [DataMember]
        public DateTime STARTDATE { get; set; }
        [DataMember]
        public DateTime ENDDATE { get; set; }
        [DataMember]
        public float? PRICE { get; set; }
        [DataMember]
        public String STATUS { get; set; }
        [DataMember]
        public String ESTATS { get; set; }

        //Constructor general
        public K_TrPlan()
        {
            ID = 0;
            PACID = 0;
            TRID = 0;
            REGDATE = DateTime.Now;
            STARTDATE = DateTime.Now;
            ENDDATE = DateTime.Now;
            PRICE = 0;
            STATUS = "SUGGESTED";
            ESTATS = String.Empty;
        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var Encontrado = (from plan in entidad.treatment_plan
                                  where plan.tm_id == ID
                                  select new
                                  {
                                      plan
                                  }).FirstOrDefault();
                try
                {
                    if (Encontrado.plan != null)
                    {
                        PACID = Encontrado.plan.tm_id;
                        TRID = Encontrado.plan.tm_trid;
                        REGDATE = Encontrado.plan.tm_regdate;
                        STARTDATE = Encontrado.plan.tm_startdate;
                        ENDDATE = Encontrado.plan.tm_enddate;
                        PRICE = Encontrado.plan.tm_price;
                        STATUS = Encontrado.plan.tm_status;
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

                var Encontrado = (from plan in entidad.treatment_plan
                                  where plan.tm_id == ID
                                  select new
                                  {
                                      plan
                                  }).FirstOrDefault();

                try
                {
                    if (Encontrado.plan != null)  //verifica si el resultado de la petición no es vacío
                    {
                        Encontrado.plan.tm_id = PACID;
                        Encontrado.plan.tm_trid = TRID;
                        Encontrado.plan.tm_regdate = REGDATE;
                        Encontrado.plan.tm_startdate = STARTDATE;
                        Encontrado.plan.tm_enddate = ENDDATE;
                        Encontrado.plan.tm_price = PRICE;
                        Encontrado.plan.tm_status =STATUS;
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
                treatment_plan trObj = new treatment_plan();

                trObj.tm_id = PACID;
                trObj.tm_trid = TRID;
                trObj.tm_regdate = REGDATE;
                trObj.tm_startdate = STARTDATE;
                trObj.tm_enddate = ENDDATE;
                trObj.tm_price = PRICE;
                trObj.tm_status = STATUS;

                try
                {

                    context.treatment_plan.Add(trObj);
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
