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
    class K_PaymentHistory
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Int32 PACID { get; set; }
        [DataMember]
        public Int32 RVID { get; set; }
        [DataMember]
        public float? AMOUNT { get; set; }
        [DataMember]
        public DateTime QDATE { get; set; }
        [DataMember]
        public String QMODE { get; set; }
        [DataMember]
        public String ESTATS { get; set; }

        //constructor general
        public K_PaymentHistory()
        {
            ID = 0;
            PACID = 0;
            RVID = 0;
            AMOUNT = 0;
            QDATE = DateTime.Now;
            QMODE = String.Empty;
            ESTATS = String.Empty;

        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.payment_history
                           where arecord.pay_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        PACID = xdf.arecord.pay_pacid;
                        RVID = xdf.arecord.pay_rvid;
                        AMOUNT = xdf.arecord.pay_amount;
                        QDATE = xdf.arecord.pay_date;
                        QMODE = xdf.arecord.pay_mode;

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

                var xdf = (from arecord in entidad.payment_history
                           where arecord.pay_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.pay_pacid = PACID;
                        xdf.arecord.pay_rvid =RVID;
                        xdf.arecord.pay_amount = AMOUNT;
                        xdf.arecord.pay_date = QDATE;
                        xdf.arecord.pay_mode = QMODE;

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
                payment_history xdf = new payment_history(); //create new object from model

                xdf.pay_pacid = PACID;
                xdf.pay_rvid = RVID;
                xdf.pay_amount = AMOUNT;
                xdf.pay_date = QDATE;
                xdf.pay_mode = QMODE;

                try
                {

                    context.payment_history.Add(xdf);   //add object xdf to context
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
