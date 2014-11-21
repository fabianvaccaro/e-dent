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

        [DataMember]
        public String Nombre { get; set; }

        //constructor general
        public D_Protocol()
        {
            UID = Guid.NewGuid().ToString("N");
            Fase = 0;
            Caminable = true;
            Privado = true;
            Detalle = String.Empty;
            Documentacion = String.Empty;
            Nombre = String.Empty;
        }
        //funcion genérica de inicialización de pasos
        T inicializar<T>(T value) where T : D_Paso{
            value.SubProtocoloID = Guid.NewGuid().ToString("N");
            value.ProtocoloID = UID;
            value.nivel = 0;
            return value;
        }
        

         public D_PasoMedicion AddMedicion()
         {
             D_PasoMedicion step = new D_PasoMedicion();
             return inicializar<D_PasoMedicion>(step);
         }

         public D_PasoOperativo AddPasoOperativo()
         {
             D_PasoOperativo step = new D_PasoOperativo();
             return inicializar<D_PasoOperativo>(step);
         }

         public D_PasoMedicacion AddPasoMedicacion()
         {
             D_PasoMedicacion step = new D_PasoMedicacion();
             return inicializar<D_PasoMedicacion>(step);
         }

         public D_PasoVigilancia AddPasoVigilancia()
         {
             D_PasoVigilancia step = new D_PasoVigilancia();
             return inicializar<D_PasoVigilancia>(step);
         }

         public Decision addDecision()
         {
             Decision step = new Decision();
             return inicializar<Decision>(step);
         }

    }
}
