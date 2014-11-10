using generalDB.objectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace e_dent.ProtocolProcessing
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProtocolManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProtocolManager.svc or ProtocolManager.svc.cs at the Solution Explorer and start debugging.
    public class ProtocolManager : IProtocolManager
    {
        public void DoWork()
        {
        }

        public void iniciarProtocolManager(String UserID = "usuarioBeta")
        {
            List<generalDB.objectClasses.D_Protocol> lstp = new List<generalDB.objectClasses.D_Protocol>();
            HttpContext.Current.Session["listaProtocolos"] = lstp;
            listaProtocolos = lstp;

            String oooo = String.Empty;

            List<D_Paso> lspaso = new List<D_Paso>();
            HttpContext.Current.Session["listaPasos"] = lspaso;

            List<D_Step_Con> lcone = new List<D_Step_Con>();
            HttpContext.Current.Session["listaConexiones"] = lcone;

            List<D_Strategy> lstrat = new List<D_Strategy>();
            HttpContext.Current.Session["listaEstrategias"] = lstrat;
        }

        //Encapsulado de la lista de protocolos activos para el usuario
        public List<generalDB.objectClasses.D_Protocol> listaProtocolos
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
        //Encapslado de la lista de estrategias activas para el usuario
        public List<D_Strategy> listaEstrategias
        {
            get
            {
                return (List<D_Strategy>)HttpContext.Current.Session["listaEstrategias"];
            }
            set
            {
                HttpContext.Current.Session["listaEstrategias"] = value;
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
        public String insertarPaso(Int32 TipoPaso, String ProtocoloID, String PadreID, Boolean LadoPaso = true)
        {
            String Estrategia = String.Empty;
            D_Paso pasoPadre = null;
            D_Paso pasoCreado = null;

            //busca el protocolo
            var a = (from s in listaProtocolos
                     where s.UID == ProtocoloID
                     select new
                     {
                         s
                     }).FirstOrDefault();



            //Determina la estrategia a la que pertenece el paso
            if (PadreID.Equals("initial"))
            {
                //Si es un paso inicial
                //crear una nueva estrategia
                D_Strategy nuevaEstrategia = new D_Strategy();
                nuevaEstrategia.ProtocoloID = ProtocoloID;
                Estrategia = nuevaEstrategia.UID;
                listaEstrategias.Add(nuevaEstrategia);

            }
            else
            {
                //de otro modo busca el paso padre
                var paso = (from s in listaPasos
                            where s.UID == PadreID
                            select new
                            {
                                s
                            }).FirstOrDefault();
                pasoPadre = paso.s;

                //establece el ID de estrategia como el registrado en el paso padre
                Estrategia = pasoPadre.EstrategiaID;
            }


            //inserta un nuevo paso en la lista          
            //ADVERTENCIA : switch importante, no tocar, si lo tocas la máquina estalla, muchos muertos, no tocar
            switch (TipoPaso)
            {
                case 1:
                    pasoCreado = a.s.AddPasoOperativo();
                    pasoCreado.EstrategiaID = Estrategia;
                    listaPasos.Add(pasoCreado);
                    break;
                case 2:
                    pasoCreado = a.s.AddMedicion();
                    pasoCreado.EstrategiaID = Estrategia;
                    listaPasos.Add(pasoCreado);
                    break;
                case 3:
                    pasoCreado = a.s.AddPasoVigilancia();
                    pasoCreado.EstrategiaID = Estrategia;
                    listaPasos.Add(pasoCreado);
                    break;
                case 4:
                    pasoCreado = a.s.AddPasoMedicacion();
                    pasoCreado.EstrategiaID = Estrategia;
                    listaPasos.Add(pasoCreado);
                    break;
                case 5:
                    pasoCreado = a.s.addDecision();
                    pasoCreado.EstrategiaID = Estrategia;
                    listaPasos.Add(pasoCreado);
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("algo raro ha pasado aqui");
                    break;
            }


            //Actualiza el paso padre con la UID del hijo
            if (!PadreID.Equals("initial"))
            {
                if (LadoPaso)
                {
                    //si es un hijo en el hilo TRUE
                    pasoPadre.VERDADERO_ID = pasoCreado.UID;
                }
                else
                {
                    //si es un hijo en el hijo FALSE
                    pasoPadre.FALSO_ID = pasoCreado.UID;
                }
                pasoPadre.tieneHijos = true;
            }


            //retorna el UID del paso insertado
            return pasoCreado.UID;


        }

        public String pruebaSesion(Int32 coge)
        {
            String rrr = "troleada";
            String aaa = String.Empty;
            HttpContext contexto = HttpContext.Current;
            if (coge == 1)
            {
                contexto.Session["pruv"] = rrr;
                aaa = "sesion seteada";
            }
            else
            {
                if (contexto.Session["pruv"] != null)
                {
                    aaa = (String)contexto.Session["pruv"];
                }
                else
                {
                    aaa = "no funciono";
                }
            }


            return aaa;
        }
    }
}
