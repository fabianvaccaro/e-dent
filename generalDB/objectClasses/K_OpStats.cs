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
    class K_OpStats
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Int32 OPID { get; set; }
        [DataMember]
        public Int32 SPID { get; set; }
        [DataMember]
        public Int32 SPEED { get; set; }
        [DataMember]
        public Int32 PRESICION { get; set; }
        [DataMember]
        public String ESTATS { get; set; }

        //constructor general
        public K_OpStats()
        {
            ID = 0;
            OPID = 0;
            SPID = 0;
            SPEED = 0;
            PRESICION = 0;

        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.operators_stats
                           where arecord.os_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        OPID = xdf.arecord.os_opid;
                        SPID = xdf.arecord.os_spid;
                        SPEED = xdf.arecord.os_speed;
                        PRESICION = xdf.arecord.os_presition;

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

                var xdf = (from arecord in entidad.operators_stats
                           where arecord.os_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.os_opid = OPID;
                        xdf.arecord.os_spid = SPID;
                        xdf.arecord.os_speed = SPEED;
                        xdf.arecord.os_presition = PRESICION;

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
                operators_stats xdf = new operators_stats(); //create new object from model

                xdf.os_opid = OPID;
                xdf.os_spid = SPID;
                xdf.os_speed = SPEED;
                xdf.os_presition = PRESICION;

                try
                {

                    context.operators_stats.Add(xdf);   //add object xdf to context
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
