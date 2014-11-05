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
    public class Simple:D_Paso
    {
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Documentacion { get; set; }
        [DataMember]
        public float CostoRef { get; set; }

        [DataMember]
        public String InstrumentoID { get; set; }


        //constructor general
        public Simple()
        {
            Nombre = String.Empty;
            Documentacion = String.Empty;
            CostoRef = 0;
            InstrumentoID = String.Empty;
        }
    }
}
