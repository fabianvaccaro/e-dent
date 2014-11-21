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
    public class D_PasoMedicion:Simple
    {
        [DataMember]
        public String VariableMedida { get; set; }
        public String ValorMedido { get; set; }

        //constructor
        public D_PasoMedicion()
        {
            VariableMedida = String.Empty;
            InstrumentoID = String.Empty;
            TipoElemento = 2;
            ValorMedido = String.Empty;
        }

    }
}
