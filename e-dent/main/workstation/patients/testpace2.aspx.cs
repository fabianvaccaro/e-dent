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
            generalDB.objectClasses.Simple pasoSimple = new generalDB.objectClasses.Simple();

            
            


            System.Diagnostics.Debug.WriteLine("SomeText");
        }
    }
}