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
    class K_Receivable
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Int32 PACID { get; set; }
        [DataMember]
        public Int32 TMID { get; set; }
        [DataMember]
        public Int32 PRID { get; set; }
        [DataMember]
        public float? AMOUNT { get; set; }
        [DataMember]
        public String ESTATS { get; set; }

        public K_Receivable()
        {
            ID = 0;
            PACID = 0;
            TMID = 0;
            PRID = 0;
            AMOUNT = 0;
            ESTATS = String.Empty;

        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.receivables
                           where arecord.rv_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        PACID = xdf.arecord.rv_pacid;
                        TMID = xdf.arecord.rv_tmid;
                        PRID = xdf.arecord.rv_prid;
                        AMOUNT = xdf.arecord.rv_amount;

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

                var xdf = (from arecord in entidad.receivables
                           where arecord.rv_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.rv_pacid = PACID;
                        xdf.arecord.rv_tmid = TMID;
                        xdf.arecord.rv_prid = PRID;
                        xdf.arecord.rv_amount = AMOUNT;

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
                receivables xdf = new receivables(); //create new object from model

                xdf.rv_pacid = PACID;
                xdf.rv_tmid = TMID;
                xdf.rv_prid = PRID;
                xdf.rv_amount = AMOUNT;

                try
                {

                    context.receivables.Add(xdf);   //add object xdf to context
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
