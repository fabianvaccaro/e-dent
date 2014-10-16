using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace mainDB_service.objectClasses
{
    [DataContract]
    [Serializable]
    public class K_Patient
    {
        [DataMember]    //esto esta bien?
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
        [DataMember]
        public Boolean Exists { get; set; }


        public K_Patient (String EDNI, String Ename, String Elastn, DateTime Eborn, String Erace, String Ephone1, String Ephone2, String Eaddress, String Ejob, String Eschool, String Eensur, Boolean EExists)
        {
            DNI = EDNI;
            Name = Ename;
            LastName=Elastn;
            Born = Eborn;
            Race = Erace;
            Phone1 = Ephone1;
            Phone2 = Ephone2;
            Address = Eaddress;
            Job = Ejob;
            School = Eschool;
            Ensurance = Eensur;
            Exists = EExists;
        }

        public K_Patient()
        {
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
            Exists = false;
        }
    }
}