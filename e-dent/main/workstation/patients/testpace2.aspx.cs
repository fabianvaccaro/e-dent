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
        protected void Page_Load(object sender, EventArgs e)
        {
            ProtocolProcessing.ProtocolManager Prott = new ProtocolProcessing.ProtocolManager();
            Prott.iniciarProtocolManager("usuarioBeta");
            //String IdProtocolo = String.Empty;
            //IdProtocolo = Prott.nuevoProtocolo("usuarioBeta");
            //hid_protocoloID.Value = IdProtocolo;
            Button1.Text = Prott.pruebaSesion(1);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProtocolProcessing.ProtocolManager Prott = new ProtocolProcessing.ProtocolManager();
            String PasoID = String.Empty;
            PasoID = Prott.insertarPaso(1,hid_protocoloID.Value,"initial",true);


            testControl1 nuevoTestControl = new testControl1();
            nuevoTestControl.UID = PasoID;

            Panel1.Controls.Add(nuevoTestControl);
            
            
            

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ProtocolProcessing.ProtocolManager Prott = new ProtocolProcessing.ProtocolManager();
            Button2.Text = Prott.pruebaSesion(0);

            
        }
    }
}