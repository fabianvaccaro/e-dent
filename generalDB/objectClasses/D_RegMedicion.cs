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
    public class D_RegMedicion
    {
        [DataMember]
        String UID { get; set; }
        [DataMember]
        String Nombre { get; set; }
        [DataMember]
        String Detalle { get; set; }
        [DataMember]
        String Unidades { get; set; }
        [DataMember]
        float Valor { get; set; }


        //constructor general
        public D_RegMedicion()
        {
            UID = Guid.NewGuid().ToString("N");
            Nombre = String.Empty;
            Detalle = String.Empty;
            Unidades = String.Empty;
            Valor = 0;
        }

    }
}
