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
    class K_Recipy
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public Int32 PRID { get; set; }
        [DataMember]
        public Int32 PACID { get; set; }
        [DataMember]
        public Int32 MEDID { get; set; }
        [DataMember]
        public String OBSERVATIONS { get; set; }
        [DataMember]
        public String ESTATS { get; set; }
        

        //constructor general
        public K_Recipy()
        {
            ID = 0;
            PRID = 0;
            PACID = 0;
            MEDID = 0;
            OBSERVATIONS = String.Empty; ;
            ESTATS = String.Empty;

        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.recipies
                           where arecord.rp_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        PRID = xdf.arecord.rp_prid;
                        PACID = xdf.arecord.rp_pacid;
                        MEDID = xdf.arecord.rp_medid;
                        OBSERVATIONS = xdf.arecord.rp_observations;
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

                var xdf = (from arecord in entidad.recipies
                           where arecord.rp_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.rp_prid = PRID;
                        xdf.arecord.rp_pacid = PACID;
                        xdf.arecord.rp_medid = MEDID;
                        xdf.arecord.rp_observations = OBSERVATIONS;

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
                recipies xdf = new recipies(); //create new object from model

                xdf.rp_prid = PRID;
                xdf.rp_pacid = PACID;
                xdf.rp_medid = MEDID;
                xdf.rp_observations = OBSERVATIONS;

                try
                {

                    context.recipies.Add(xdf);   //add object xdf to context
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
