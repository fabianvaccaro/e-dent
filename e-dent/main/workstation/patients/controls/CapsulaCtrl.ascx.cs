using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_dent.main.workstation.patients.controls
{
    public partial class CapsulaCtrl : System.Web.UI.UserControl
    {
        public Int32 tipoControl = 1;
        
        
        //Eventos de botones
        public event EventHandler<tipoPasoArgs> nuevoPasoEvent;

        /// <summary>
        /// Consructor del Control CapsulaCtrl
        /// </summary>
        public CapsulaCtrl()
        {
            Panel panelCtrlPrincipal = new Panel();
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //poner codigo aqui
            }
           
            //Carga el control principal

            switch (tipoControl)
            {
                case 1:
                    PasoOperativoCtrl ctrl1 = (PasoOperativoCtrl)this.LoadControl("~/main/workstation/patients/controls/PasoOperativoCtrl.ascx");
                    ctrl1.ID = "pOperativo";
                    ctrl1.CuandoCambiaEspera += new EventHandler<CheckArg>(ctrl_pasoOperativoChecked);
                    ctrl1.mostrarPanelDetalles += new EventHandler(mostrar_panelDetalles);
                    panelCtrlPrincipal.Controls.Add(ctrl1);

                    break;
                case 2:
                    //~/main/workstation/patients/controls/PasoMedicionCtrl.ascx
                    PasoMedicionCtrl ctrl2 = (PasoMedicionCtrl)this.LoadControl("~/main/workstation/patients/controls/PasoMedicionCtrl.ascx");
                    ctrl2.ID = "pMedicion";
                    ctrl2.mostrarPanelDetalles += new EventHandler(mostrar_panelDetalles);
                    panelCtrlPrincipal.Controls.Add(ctrl2);
                    break;
            }

            //posicion del indexador
            
            
            
        }


        protected void mostrar_panelDetalles(object sender, EventArgs arg)
        {
            
            MultiView1.Visible = true;
            MultiView1.ActiveViewIndex = 0;
        }
        protected void ctrl_pasoOperativoChecked(object sender, CheckArg arg)
        { 
            //Cuando se checkea 
            MultiView1.Visible = arg.IsChecked;
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btn_anadir_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.Visible = true;
            MultiView1.ActiveViewIndex = 1;
        }

        protected void dummybtn_Click(object sender, EventArgs e)
        {
            MultiView1.Visible = false;
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btn_addPasoOperativo_Click(object sender, EventArgs e)
        {
            if (nuevoPasoEvent != null)
            {
                nuevoPasoEvent(this, new tipoPasoArgs(1, this.ID));
            }
            
        }

        protected void btn_addPasoMedicion_Click(object sender, EventArgs e)
        {
            
            if (nuevoPasoEvent != null)
            {
                nuevoPasoEvent(this, new tipoPasoArgs(2, this.ID));
            }
        }

    }
    /// <summary>
    /// Argumento que contiene el tipo de paso a ser insertado
    /// </summary>
    public class tipoPasoArgs: EventArgs
    {
        public Int32 pasoType { get; set; }
        public String GeneradorID { get; set; }
        
        //constructor 
        public tipoPasoArgs(Int32 tp, String thid)
        {
            pasoType = tp;
            GeneradorID = thid;
        }
    }

}