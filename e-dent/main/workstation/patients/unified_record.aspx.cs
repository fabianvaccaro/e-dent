using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_dent.main.workstation.patients
{
    public partial class unified_record : System.Web.UI.Page
    {
       

        //Patient information
        String PACID = String.Empty;
        String DNI = String.Empty;
        String NAME = String.Empty;
        String LASTN = String.Empty;
        DateTime BORN = DateTime.Now;
        String RACE = String.Empty;
        String PHONE1 = String.Empty;
        String PHONE2 = String.Empty;
        String ADDRESS = String.Empty;
        String JOB = String.Empty;
        String SCHOOL = String.Empty;
        String ENSUR = String.Empty;
        Int32 DIVID = 0;
    

        String patienID = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            PACID = Request.QueryString["PACID"];
            
            
        }
    }
}