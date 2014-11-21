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
    public class D_Designer
    {
        [DataMember]
        public String DesignerID { get; set; }

        [DataMember]
        public List<String> ProtocolosAsociados { get; set; }


        public D_Designer()
        {
            DesignerID = Guid.NewGuid().ToString("N");
            List<String> ptas = new List<string>();
            ProtocolosAsociados = ptas;
        }
    }
}
