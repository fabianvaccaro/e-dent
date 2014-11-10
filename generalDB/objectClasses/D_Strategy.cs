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
    public class D_Strategy
    {
        [DataMember]
        public String ProtocoloID { get; set; }

        [DataMember]
        public String SubProtocoloID { get; set; }
        [DataMember]
        public String UID { get; set; }
        [DataMember]
        public String Autor { get; set; }
        [DataMember]
        public String Objetivo { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String SiguienteEstrategia { get; set; }
        [DataMember]
        public String PrimerElementoID { get; set; }


        public D_Strategy()
        {
            UID = Guid.NewGuid().ToString("N");
            ProtocoloID = "single";
            SubProtocoloID = "single";
            Autor = String.Empty;
            Objetivo = String.Empty;
            Descripcion = String.Empty;
            SiguienteEstrategia = "null";
            PrimerElementoID = String.Empty;
        }

    }
}
