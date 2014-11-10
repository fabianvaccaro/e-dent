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
        public String Detalle { get; set; }

        [DataMember]
        public String Observaciones { get; set; }

        [DataMember]
        public Int32 nivel { get; set; }
        [DataMember]
        public Boolean tieneHijos { get; set; }
        [DataMember]
        public Int32 TipoElemento { get; set; }

        //constructor general
        public D_Paso()
        {
            UID = Guid.NewGuid().ToString("N");
            ProtocoloID = "single";
            SubProtocoloID = "single";
            Detalle = String.Empty;
            Observaciones = String.Empty;
            nivel = 0;
            tieneHijos = false;
        }

        //Generación de objetos concatenados

        T inicializar<T>(T value) where T : D_Paso
        {
            value.ProtocoloID = ProtocoloID;
            value.SubProtocoloID = SubProtocoloID;
            value.nivel = nivel + 1;
            tieneHijos = true;
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
