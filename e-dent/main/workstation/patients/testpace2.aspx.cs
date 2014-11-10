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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            generalDB.objectClasses.D_Protocol prinks = new generalDB.objectClasses.D_Protocol();

            generalDB.objectClasses.D_PasoOperativo opera = new generalDB.objectClasses.D_PasoOperativo();


            List<generalDB.objectClasses.D_Paso> listaPasos = new List<generalDB.objectClasses.D_Paso>();
            listaPasos.Add(prinks.AddPasoOperativo());

            var a = (
                from s in listaPasos
                where s.ProtocoloID == prinks.UID
                select new
                {
                    s
                }).FirstOrDefault();

            listaPasos.Add(a.s.AddPasoOperativo());

            System.Diagnostics.Debug.WriteLine(prinks.UID + "  ---   " + a.s.ProtocoloID);
        }
    }
}