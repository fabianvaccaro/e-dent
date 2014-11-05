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
    public class D_Protocol
    {
        [DataMember]
        public String UID { get; set; }

        [DataMember]
        public Int32 Fase { get; set; }

        [DataMember]
        public Boolean Caminable { get; set; }

        [DataMember]
        public Boolean Privado { get; set; }

        [DataMember]
        public String Detalle { get; set; }

        [DataMember]
        public String Documentacion { get; set; }



        //constructor general
        public D_Protocol()
        {
            UID = Guid.NewGuid().ToString("N");
            Fase = 0;
            Caminable = true;
            Privado = true;
            Detalle = String.Empty;
            Documentacion = String.Empty;
        }

        D_Paso inicializar(D_Paso objeto)
        {
             objeto.ProtocoloID = UID;
             objeto.SubProtocoloID = Guid.NewGuid().ToString("N");
             objeto.PREV_ID = "starter";
             return objeto;
        }

         public D_PasoMedicion AddMedicion()
         {
             D_PasoMedicion step = new D_PasoMedicion();
             step.ProtocoloID = UID;
             step.SubProtocoloID = Guid.NewGuid().ToString("N");
             step.PREV_ID = "starter";
             return step;
         }

         public D_PasoOperativo AddPasoOperativo()
         {
             D_PasoOperativo step = new D_PasoOperativo();
             step.ProtocoloID = UID;
             step.SubProtocoloID = Guid.NewGuid().ToString("N");
             step.PREV_ID = "starter";
             return step;
         }

         public D_PasoMedicacion AddPasoMedicion()
         {
             D_PasoMedicacion step = new D_PasoMedicacion();
             step.ProtocoloID = UID;
             step.SubProtocoloID = Guid.NewGuid().ToString("N");
             step.PREV_ID = "starter";
             return step;
         }

         public D_PasoVigilancia AddPasoVigilancia()
         {
             D_PasoVigilancia step = new D_PasoVigilancia();
             step.ProtocoloID = UID;
             step.SubProtocoloID = Guid.NewGuid().ToString("N");
             step.PREV_ID = "starter";
             return step;
         }

         public Decision addDecision()
         {
             Decision step = new Decision();
             step.ProtocoloID = UID;
             step.SubProtocoloID = Guid.NewGuid().ToString("N");
             step.PREV_ID = "starter";
             return step;
         }

    }
}
