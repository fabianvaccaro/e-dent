﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace generalDB.objectClasses
{
    [DataContract]
    [Serializable]
    public class Decision:D_Paso
    {
        [DataMember]
        Int32 Campo1 { get; set; }
        [DataMember]
        Int32 Campo2 { get; set; }
        [DataMember]
        Int32 Campo3 { get; set; }
        [DataMember]
        String VERDADERO_ID { get; set; }
        [DataMember]
        String FALSO_ID { get; set; }

        //constructor general
        public Decision()
        {
            Campo1 = 0;
            Campo2 = 0;
            Campo3 = 0;
            VERDADERO_ID =String.Empty;
            FALSO_ID = String.Empty;
        }

    }
}
