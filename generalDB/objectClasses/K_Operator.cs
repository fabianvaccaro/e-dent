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
    class K_Operator
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public String QNAME { get; set; }
        [DataMember]
        public String QLASTNAME { get; set; }
        [DataMember]
        public String PHONE1 { get; set; }
        [DataMember]
        public String PHONE2 { get; set; }
        [DataMember]
        public String EMAIL { get; set; }
        [DataMember]
        public String ADDRESS { get; set; }
        [DataMember]
        public DateTime? GRADDATE { get; set; }
        [DataMember]
        public String STDLVL { get; set; }
        [DataMember]
        public DateTime? INGDATE { get; set; }
        [DataMember]
        public String ESTATS { get; set; }


        //constructor general
        public K_Operator()
        {
            ID = 0;
            QNAME = String.Empty;
            QLASTNAME = String.Empty;
            PHONE1 = String.Empty;
            PHONE2 = String.Empty;
            EMAIL = String.Empty;
            ADDRESS = String.Empty;
            GRADDATE = DateTime.Now;
            STDLVL = String.Empty;
            INGDATE = DateTime.Now;
            ESTATS = String.Empty;

        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.operators
                           where arecord.op_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        QNAME = xdf.arecord.op_names;
                        QLASTNAME = xdf.arecord.op_lastn;
                        PHONE1 = xdf.arecord.op_phone1;
                        PHONE2 = xdf.arecord.op_phone2;
                        EMAIL = xdf.arecord.op_email;
                        ADDRESS = xdf.arecord.op_address;
                        GRADDATE = xdf.arecord.op_graddate;
                        STDLVL = xdf.arecord.op_stdlvl;
                        INGDATE = xdf.arecord.op_ingdate;

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

                var xdf = (from arecord in entidad.operators
                           where arecord.op_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.op_names = QNAME;
                        xdf.arecord.op_lastn = QLASTNAME;
                        xdf.arecord.op_phone1 = PHONE1;
                        xdf.arecord.op_phone2 = PHONE2;
                        xdf.arecord.op_email = EMAIL;
                        xdf.arecord.op_address = ADDRESS;
                        xdf.arecord.op_graddate = GRADDATE;
                        xdf.arecord.op_stdlvl = STDLVL;
                        xdf.arecord.op_ingdate = INGDATE;


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
                operators xdf = new operators(); //create new object from model

                xdf.op_names = QNAME;
                xdf.op_lastn = QLASTNAME;
                xdf.op_phone1 = PHONE1;
                xdf.op_phone2 = PHONE2;
                xdf.op_email = EMAIL;
                xdf.op_address = ADDRESS;
                xdf.op_graddate = GRADDATE;
                xdf.op_stdlvl = STDLVL;
                xdf.op_ingdate = INGDATE;

                try
                {

                    context.operators.Add(xdf);   //add object xdf to context
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
