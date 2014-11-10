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
    public class D_Step_Con
    {
        [DataMember]
        public String UID { get; set; }

        [DataMember]
        public String ProtocoloID { get; set; }

        [DataMember]
        public String SubProtocoloID { get; set; }

        [DataMember]
        public String Step1ID { get; set; }
        [DataMember]
        public String Step2ID { get; set; }


        //constructor general
        public D_Step_Con()
        {
            UID = Guid.NewGuid().ToString("N");
            ProtocoloID = "single";
            SubProtocoloID = "single";
            Step1ID = String.Empty;
            Step2ID = String.Empty;
        }

        public void conectar<T>(T step1, T step2) where T : D_Paso
        {
            Step1ID = step1.UID;
            Step2ID = step2.UID;
            ProtocoloID = step1.ProtocoloID;
            SubProtocoloID = step1.SubProtocoloID;
        }



    }
}
