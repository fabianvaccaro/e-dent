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
    public class D_PasoVigilancia:Simple
    {
        [DataMember]
        public Int32 Duracion { get; set; } //en horas

        //constructor general
        public D_PasoVigilancia()
        {
            Duracion = 0;
        }
    }
}
