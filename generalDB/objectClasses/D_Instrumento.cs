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
    public class D_Instrumento
    {
        [DataMember]
        String UID { get; set; }
        [DataMember]
        String Nombre { get; set; }
        [DataMember]
        String Documentacion { get; set; }


        //constructor general
        public D_Instrumento()
        {
            UID = Guid.NewGuid().ToString("N");
            Nombre = String.Empty;
            Documentacion = String.Empty;
        }
    }
}
