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
    class K_Pathology
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public String TYPE { get; set; }
        [DataMember]
        public String NAME { get; set; }
        [DataMember]
        public String RISK { get; set; }
        [DataMember]
        public String ESTATS { get; set; }


        //Constructor general
        public K_Pathology()
        {
            ID = 0;
            TYPE = String.Empty;
            NAME = String.Empty;
            RISK = String.Empty;
        }


        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.pathologies
                           where arecord.thos_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        TYPE = xdf.arecord.thos_type;
                        NAME = xdf.arecord.thos_name;
                        RISK = xdf.arecord.thos_risk;
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

                var xdf = (from arecord in entidad.pathologies
                           where arecord.thos_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.thos_type = TYPE;
                        xdf.arecord.thos_name = NAME;
                        xdf.arecord.thos_risk = RISK;
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
                pathologies xdf = new pathologies();

                xdf.thos_type = TYPE;
                xdf.thos_name = NAME;
                xdf.thos_risk = RISK;

                try
                {

                    context.pathologies.Add(xdf);   //add object xdf to context
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
