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
            String IdProtocolo = String.Empty;
            IdProtocolo = Prott.nuevoProtocolo("usuarioBeta");
            hid_protocoloID.Value = IdProtocolo;
            Button1.Text = "Añadir elemento";
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProtocolProcessing.ProtocolManager Prott = new ProtocolProcessing.ProtocolManager();
            String PasoID = String.Empty;
            PasoID = Prott.insertarPaso(1,hid_protocoloID.Value,"initial",true);

            testControl1 nctrl = (testControl1)LoadControl("~/main/workstation/patients/controls/testControl1.ascx");
            nctrl.UID = PasoID;

            Panel1.Controls.Add(nctrl);
        }

        
    }
}