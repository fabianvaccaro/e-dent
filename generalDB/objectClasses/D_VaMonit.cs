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
    public class D_VaMonit
    {
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String UnidadMedida { get; set; }
        [DataMember]
        public String Documentacion { get; set; }

        /// <summary>
        /// Representa un tipo de Variable biológica siendo monitoreada 
        /// </summary>
        public D_VaMonit()
        {
            Descripcion = String.Empty;
            UnidadMedida = String.Empty;
            Documentacion = String.Empty;
        }

    }
}
