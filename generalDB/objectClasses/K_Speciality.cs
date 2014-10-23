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
    class K_Speciality
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public String QNAME { get; set; }
        [DataMember]
        public String QTYPE { get; set; }
        [DataMember]
        public String ESTATS { get; set; }


        //Constructor general
        public K_Speciality()
        {
            ID = 0;
            QNAME = String.Empty;
            QTYPE = String.Empty;
            ESTATS = String.Empty;

        }


        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.specialities
                           where arecord.sp_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        QNAME = xdf.arecord.sp_name;
                        QTYPE = xdf.arecord.sp_type;
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

                var xdf = (from arecord in entidad.specialities
                           where arecord.sp_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.sp_name = QNAME;
                        xdf.arecord.sp_type = QTYPE;

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
                specialities xdf = new specialities(); //create new object from model

                xdf.sp_name = QNAME;
                xdf.sp_type = QTYPE;

                try
                {

                    context.specialities.Add(xdf);   //add object xdf to context
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
