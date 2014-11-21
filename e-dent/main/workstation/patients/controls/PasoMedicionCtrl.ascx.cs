using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_dent.main.workstation.patients.controls
{
    public partial class PasoMedicionCtrl : System.Web.UI.UserControl
    {
        public event EventHandler<DetallesArg> escribirDetalles;
        public event EventHandler mostrarPanelDetalles;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_editarDetalle_Click(object sender, EventArgs e)
        {
            if (mostrarPanelDetalles != null)
                mostrarPanelDetalles(this, EventArgs.Empty);
        }
    }
}