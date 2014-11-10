using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_dent.main.workstation.patients
{
    public partial class testControl1 : System.Web.UI.UserControl
    {
        public String UID = "";
        public String Descripcion = null;
        public Boolean Seleccionado = false;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_nombrePaso.Text = UID;
        }

        protected void PasoSeleccionado_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txt_descripcion_TextChanged(object sender, EventArgs e)
        {
            Descripcion = txt_descripcion.Text;
        }



        
    }
}