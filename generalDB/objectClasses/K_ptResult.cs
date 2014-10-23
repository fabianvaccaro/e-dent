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
    class K_ptResult
    {
        [DataMember]
        public Int32 DIVID { get; set; }
        [DataMember]
        public Int32 ID { get; set; }
        [DataMember]
        public String DNI { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public DateTime Born { get; set; }
        [DataMember]
        public String Race { get; set; }
        [DataMember]
        public String Phone1 { get; set; }
        [DataMember]
        public String Phone2 { get; set; }
        [DataMember]
        public String Address { get; set; }
        [DataMember]
        public String Job { get; set; }
        [DataMember]
        public String School { get; set; }
        [DataMember]
        public String Ensurance { get; set; }

        //constructor general
        public K_ptResult()
        {
            ID = 0;
            DIVID = 0;
            DNI = String.Empty;
            Name = String.Empty;
            LastName = String.Empty;
            Born = DateTime.Now;
            Race = String.Empty;
            Phone1 = String.Empty;
            Phone2 = String.Empty;
            Address = String.Empty;
            Job = String.Empty;
            School = String.Empty;
            Ensurance = String.Empty;
        }

    }
}
