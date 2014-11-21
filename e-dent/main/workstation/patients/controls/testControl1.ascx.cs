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
        public String UID;
        public String Descripcion;
        public Boolean Seleccionado;
        
        

        public testControl1()
        {
            Label lbl_nombrePaso = new Label();
            TextBox txt_descripcion = new TextBox();
            CheckBox PasoSeleccionado = new CheckBox();
            ImageButton btn_nuevoPaso = new ImageButton();
            Descripcion = null;
            Seleccionado = false;
            UID = String.Empty;

            txt_descripcion.Text = "hola";

            
            
        }
         
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_nombrePaso.Text = UID;
        }

        protected void PasoSeleccionado_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void tclick(object sender, EventArgs e)
        {
            footBtn.Visible = false;
        }




        
    }
}