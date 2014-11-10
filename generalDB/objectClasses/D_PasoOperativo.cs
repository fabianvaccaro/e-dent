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
    public class D_PasoOperativo:Simple
    {
        
        [DataMember]
        public Int32 Pausa { get; set; } //en segundos

        [DataMember]
        public Int32 UbicacionID { get; set; }


        public D_PasoOperativo()
        {
            Pausa = 0;
            UbicacionID = 0;
            TipoElemento = 1;
        }
    }
}
