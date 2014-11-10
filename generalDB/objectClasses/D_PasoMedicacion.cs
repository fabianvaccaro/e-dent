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
    public class D_PasoMedicacion:Simple
    {
        [DataMember]
        public Int32 MedicamentoID { get; set; }

        [DataMember]
        public float Dosis { get; set; } // En miligarmos

        [DataMember]
        public Int32 Intervalo { get; set; } //en minutos

        [DataMember]
        public Int32 Duracion { get; set; } //en horas

        //constructor general
        public D_PasoMedicacion()
        {
            MedicamentoID = 0;
            Dosis = 0;
            Intervalo = 0;
            Duracion = 0;
            TipoElemento = 4;
        }
    }
}
