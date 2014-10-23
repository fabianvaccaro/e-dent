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
    class K_Medicines
    {
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public String COMPOSITION { get; set; }
        [DataMember]
        public String COMMERCIAL { get; set; }
        [DataMember]
        public Single? DOSE { get; set; }
        [DataMember]
        public Single? WEIGHTDOSE { get; set; }
        [DataMember]
        public String PRESENTATION { get; set; }
        [DataMember]
        public Single? AGE { get; set; }
        [DataMember]
        public String QTYPE { get; set; }
        [DataMember]
        public String ESTATS { get; set; }

        //constructor general
        public K_Medicines()
        {
            ID = 0;
            COMPOSITION = String.Empty;
            COMMERCIAL = String.Empty;
            DOSE = 0;
            WEIGHTDOSE = 0;
            PRESENTATION = String.Empty;
            AGE = 0;
            QTYPE = String.Empty;
            ESTATS = String.Empty;


        }

        public Boolean getByID()
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {

                var xdf = (from arecord in entidad.medicines
                           where arecord.med_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)
                    {
                        COMPOSITION = xdf.arecord.med_composition;
                        COMMERCIAL = xdf.arecord.med_commercial;
                        DOSE = xdf.arecord.med_dose;
                        WEIGHTDOSE = xdf.arecord.med_weightdoserelation;
                        PRESENTATION = xdf.arecord.med_presentation;
                        AGE = xdf.arecord.med_age;
                        QTYPE = xdf.arecord.med_type;

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

                var xdf = (from arecord in entidad.medicines
                           where arecord.med_id == ID
                           select new
                           {
                               arecord
                           }).FirstOrDefault();
                try
                {
                    if (xdf.arecord != null)  //verifica si el resultado de la petición no es vacío
                    {
                        xdf.arecord.med_composition = COMPOSITION;
                        xdf.arecord.med_commercial = COMMERCIAL;
                        xdf.arecord.med_dose = DOSE;
                        xdf.arecord.med_weightdoserelation = WEIGHTDOSE;
                        xdf.arecord.med_presentation = PRESENTATION;
                        xdf.arecord.med_age = AGE;
                        xdf.arecord.med_type = QTYPE;

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
                medicines xdf = new medicines(); //create new object from model

                xdf.med_composition = COMPOSITION;
                xdf.med_commercial = COMMERCIAL;
                xdf.med_dose = DOSE;
                xdf.med_weightdoserelation = WEIGHTDOSE;
                xdf.med_presentation = PRESENTATION;
                xdf.med_age = AGE;
                xdf.med_type = QTYPE;

                try
                {

                    context.medicines.Add(xdf);   //add object xdf to context
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
