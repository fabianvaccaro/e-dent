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
    public class D_Paso
    {
        [DataMember]
        public String UID { get; set; }

        [DataMember]
        public String ProtocoloID { get; set; }

        [DataMember]
        public String SubProtocoloID { get; set; }

        [DataMember]
        public String PREV_ID { get; set; }

        [DataMember]
        public String Detalle { get; set; }

        [DataMember]
        public String Observaciones { get; set; }

        //constructor general
        public D_Paso()
        {
            UID = Guid.NewGuid().ToString("N");
            ProtocoloID = "single";
            SubProtocoloID = "single";
            PREV_ID = String.Empty;
            Detalle = String.Empty;
            Observaciones = String.Empty;
        }

        //Generación de objetos concatenados
        public D_PasoMedicion AddMedicion()
        {
            D_PasoMedicion step = new D_PasoMedicion();
            step.PREV_ID = UID;      //establece el PREV_ID del nuevo objeto concatenado como el UID del objeto actual
            step.ProtocoloID = ProtocoloID;
            step.SubProtocoloID = SubProtocoloID;
            return step;
        }

        public D_PasoOperativo AddPasoOperativo()
        {
            D_PasoOperativo step = new D_PasoOperativo();
            step.PREV_ID = UID;
            step.ProtocoloID = ProtocoloID;
            step.SubProtocoloID = SubProtocoloID;
            return step;
        }

        public D_PasoMedicacion AddPasoMedicion()
        {
            D_PasoMedicacion step = new D_PasoMedicacion();
            step.PREV_ID = UID;
            step.ProtocoloID = ProtocoloID;
            step.SubProtocoloID = SubProtocoloID;
            return step;
        }

        public D_PasoVigilancia AddPasoVigilancia()
        {
            D_PasoVigilancia step = new D_PasoVigilancia();
            step.PREV_ID = UID;
            step.ProtocoloID = ProtocoloID;
            step.SubProtocoloID = SubProtocoloID;
            return step;
        }

        public Decision addDecision()
        {
            Decision step = new Decision();
            step.PREV_ID = UID;
            step.ProtocoloID = ProtocoloID;
            step.SubProtocoloID = SubProtocoloID;
            return step;
        }

        public void cambiarSubProtocolo(String nuevoID)
        {
            SubProtocoloID = nuevoID;
        }
        public void nuevoSubProtocolo()
        {
            SubProtocoloID = Guid.NewGuid().ToString("N");
        }
    }
}
