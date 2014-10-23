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
    class K_Treatment
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public String QNAME { get; set; }
        [DataMember]
        public Int32 ESPID { get; set; }
        [DataMember]
        public Int32 PATID { get; set; }
        [DataMember]
        public float? BASEPRICE { get; set; }
        [DataMember]
        public String ESTATS { get; set; }

        //Constructor general
        public K_Treatment()
        {
            ID = 0;
            QNAME = String.Empty;
            ESPID = 0;
            PATID = 0;
            BASEPRICE = 0;
            ESTATS = String.Empty;
        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.treatments
                           where arecord.tr_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        QNAME = xdf.arecord.tr_name;
                        ESPID = xdf.arecord.tr_espid;
                        PATID = xdf.arecord.tr_patid;
                        BASEPRICE = xdf.arecord.tr_baseprice;

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

                var xdf = (from arecord in entidad.treatments
                           where arecord.tr_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.tr_name = QNAME;
                        xdf.arecord.tr_espid = ESPID;
                        xdf.arecord.tr_patid = PATID;
                        xdf.arecord.tr_baseprice = BASEPRICE;

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
                treatments xdf = new treatments(); //create new object from model

                xdf.tr_name = QNAME;
                xdf.tr_espid = ESPID;
                xdf.tr_patid = PATID;
                xdf.tr_baseprice = BASEPRICE;

                try
                {

                    context.treatments.Add(xdf);   //add object xdf to context
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
