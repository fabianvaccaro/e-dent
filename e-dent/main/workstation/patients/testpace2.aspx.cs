using generalDB.objectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_dent.main.workstation.patients
{
    public partial class testpace2 : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProtocolProcessing.ProtocolDesignerTools Prott = new ProtocolProcessing.ProtocolDesignerTools();
                List<D_Protocol> lstp = new List<D_Protocol>();
                Session["listaProtocolos"] = lstp;

                List<D_Paso> lspaso = new List<D_Paso>();
                Session["listaPasos"] = lspaso;

                List<D_Step_Con> lcone = new List<D_Step_Con>();
                Session["listaConexiones"] = lcone;

                List<D_Strategy> lstrat = new List<D_Strategy>();
                Session["listaEstrategias"] = lstrat;

                String IdProtocolo = String.Empty;
                IdProtocolo = Prott.nuevoProtocolo("usuarioBeta");
                hid_protocoloID.Value = IdProtocolo;

                Button1.Text = "Añadir elemento";
                Session["ProtocolDesignerIniciado"] = true;

                
            }
            showgrid();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(GridView1.DataSource != null)
                listaPasos = ((List<D_Paso>)GridView1.DataSource);
            ProtocolProcessing.ProtocolDesignerTools Prott = new ProtocolProcessing.ProtocolDesignerTools();
            String otroPaso;
            otroPaso = Prott.insertarPaso(1, hid_protocoloID.Value, "initial", true);
            showgrid();
          
            //prott es un protocolo 

            
            //dibujarControles();
            
        }
        void dibujarControles()
        {
            Panel1.Controls.Clear();
            var a = (from stepid in listaPasos
                     where stepid.ProtocoloID == hid_protocoloID.Value.ToString()
                     select new
                     {
                         stepid
                     }).ToList();
           

            foreach (var dstep in a)
            {
                testControl1 nctrl = (testControl1)LoadControl("~/main/workstation/patients/controls/testControl1.ascx");
                nctrl.UID = dstep.stepid.UID;
                nctrl.ID = dstep.stepid.UID;
                Panel1.Controls.Add(nctrl);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = listaPasos;
            GridView1.DataBind();
        }
        
        protected void gridUpdate(object sender, GridViewUpdateEventArgs e)
        {
           
            TextBox ttx = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextoUID");

          //  ttx.Text = "Puta mierda";
            

            listaPasos[e.RowIndex].UID = ttx.Text;
            
            showgrid();

            //mi amor esta funcion solo va a obtener valores sin actualizar
            GridView1.EditIndex = e.RowIndex;
            showgrid();
        }

        protected void showgrid()
        {
            GridView1.DataSource = listaPasos;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
          //  GridView1.sour
            TextBox ttx = (TextBox)GridView1.Rows[0].FindControl("TextoUID");
            //ttx.Text = "Estoy hasta las bolas";

            listaPasos[e.AffectedRows].UID = ttx.Text;

            showgrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //no hace nada
        }
    }
}