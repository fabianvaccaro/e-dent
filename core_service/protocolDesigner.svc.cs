using generalDB.objectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace core_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "protocolDesigner" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select protocolDesigner.svc or protocolDesigner.svc.cs at the Solution Explorer and start debugging.
    public class protocolDesigner : IprotocolDesigner
    {
        public void DoWork()
        {
        }
        /// <summary>
        /// Inicia el Protocol Manager
        /// </summary>
        /// <param name="UserID">Id del usuario activo</param>
        public void iniciarProtocolManager(String UserID = "usuarioBeta")
        {
            List<generalDB.objectClasses.D_Protocol> lstp = new List<generalDB.objectClasses.D_Protocol>();
            HttpContext.Current.Session["listaProtocolos"] = lstp;
        }

        //Encapsulado de la lista de protocolos activos para el usuario
        public List<generalDB.objectClasses.D_Protocol>listaProtocolos
        {
            get
            {
                return (List<generalDB.objectClasses.D_Protocol>)HttpContext.Current.Session["listaProtocolos"];
            }
            set
            {
                HttpContext.Current.Session["listaProtocolos"] = value;
            }
        }
        //Encapsulado de la lista de pasos activos para el usuario
        public List<generalDB.objectClasses.D_Paso> listaPasos
        {
            get
            {
                return (List<generalDB.objectClasses.D_Paso>)HttpContext.Current.Session["listaPasos"];
            }
            set
            {
                HttpContext.Current.Session["listaPasos"] = value;
            }
        }
        //Encapsulado de la lista de conexiones activas para el usuario
        public List<generalDB.objectClasses.D_Step_Con> listaConexiones
        {
             get
            {
                return (List<generalDB.objectClasses.D_Step_Con>)HttpContext.Current.Session["listaConexiones"];
            }
            set
            {
                HttpContext.Current.Session["listaConexiones"] = value;
            }
        }

        /// <summary>
        /// Genera un objeto de conexión entre pasos
        /// </summary>
        /// <param name="Paso1"></param>
        /// <param name="Paso2"></param>
        /// <returns></returns>
        public generalDB.objectClasses.D_Step_Con nuevaConexion(D_Paso Paso1, D_Paso Paso2)
        {
            generalDB.objectClasses.D_Step_Con conn = new generalDB.objectClasses.D_Step_Con();
            conn.conectar(Paso1, Paso2);
            
            return conn;
        }

        /// <summary>
        /// Inserta un protocolo nuevo al listado de protocolos activos en la sesión
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns>Retorna el ID del protocolo nuevo</returns>
        public String nuevoProtocolo(String UserID = "usuarioBeta")
        {
            generalDB.objectClasses.D_Protocol proto = new generalDB.objectClasses.D_Protocol();
            listaProtocolos.Add(proto);
            return proto.UID;
        }

        T nuevoP<T>(T value) where T : generalDB.objectClasses.D_Paso
        {

            return value;
        }

        //Insertar pasos
        public String insertarPaso(Int32 TipoPaso, String UserID, String ProtocoloID, String SubProtocoloID = "single" )
        {
            //busca el protocolo
            var a = (from s in listaProtocolos
                     where s.UID == ProtocoloID
                     select new
                     {
                         s
                     }).FirstOrDefault();
            //inserta un nuevo paso en la lista
            //según el TipoPaso
            D_Paso pasoCreado = null;
            switch (TipoPaso)
            {
                case 1:
                    pasoCreado = a.s.AddPasoOperativo();
                    listaPasos.Add(pasoCreado);
                    break;
                case 2:
                    pasoCreado = a.s.AddMedicion();
                    listaPasos.Add(pasoCreado);
                    break;
                case 3:
                    pasoCreado = a.s.AddPasoVigilancia();
                    listaPasos.Add(pasoCreado);
                    break;
                case 4:
                    pasoCreado = a.s.AddPasoMedicacion();
                    listaPasos.Add(pasoCreado);
                    break;
                case 5:
                    pasoCreado = a.s.addDecision();
                    listaPasos.Add(pasoCreado);
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("algo raro ha pasado aqui");
                    break;
            }
            //retorna el UID del paso insertado
            return pasoCreado.UID;

            
        }
    }
}
