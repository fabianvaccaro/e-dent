﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using e_dent.core_serviceRef;


namespace e_dent
{
    public partial class testpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Service1Client cliente = new Service1Client();
       //     cliente.createUser(txt_username.Text, txt_passwd.Text, txt_role.Text, txt_institution.Text);
            lbl_info.Text = "Usuario añadido";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Service1Client cliente = new Service1Client();
         //   lbl_retUserName.Text = cliente.prueba_DB(Convert.ToInt32(txt_getUsername.Text));

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Service1Client cliente = new Service1Client();
            Int32 eID = Convert.ToInt32(txt_ptID.Text);
            String eNombre = txt_ptNombre.Text;
            if(cliente.actualizarNombre(eID,eNombre))
            {
                lbl_perra.Text = "Nombre cambiado con exito";
                txt_ptNombre.Text = "";
                txt_ptID.Text = "";
            }
            else
            {
                lbl_perra.Text = "Nombre no cambiado";
                txt_ptNombre.Text = "";
                txt_ptID.Text = "";
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Service1Client cliente = new Service1Client();
            int eID = int.Parse(txt_ptID.Text);
            txt_ptNombre.Text = cliente.obtenerNombre(eID);
        }
    }
}