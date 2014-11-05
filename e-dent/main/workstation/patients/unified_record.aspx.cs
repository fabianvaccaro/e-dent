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
        //Int32 DIVID = 0;

        void findPatientInformation(Int32 ID)
        {
            ServiceReference1.IpatientManagementClient cliente = new ServiceReference1.IpatientManagementClient();
            generalDB.objectClasses.K_Patient paciente = new generalDB.objectClasses.K_Patient();
            paciente = cliente.getPatientByID(ID);  //busca si existe un paciente con ese ID
            if (paciente.Exists)
            {
                //Si el paciente existe muestra información del paciente
                MultiView1.ActiveViewIndex = 1;
                lbl_nmpac.Text = paciente.Name + " " + paciente.LastName;
                lbl_dni.Text = paciente.DNI;
                lbl_born.Text = paciente.Born.ToString();
                lbl_race.Text = paciente.Race;
                lbl_phone1.Text = paciente.Phone1;
                lbl_phone2.Text = paciente.Phone2;
                lbl_address.Text = paciente.Address;
                lbl_job.Text = paciente.Job;
                lbl_school.Text = paciente.School;
                lbl_ensur.Text = paciente.Ensurance;
            }
            else
            {
                //Si el paciente no existe, muestra un mensaje
                MultiView1.ActiveViewIndex = 2;
            }
        }
    

        String patienID = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            PACID = Request.QueryString["PACID"];
            if(!String.IsNullOrEmpty(PACID))    //Verifica si se le ha pasado un PACID al QueryString
            {
                findPatientInformation(int.Parse(PACID));
            }
            
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            txt_pacid.Text = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Int32 id = 0;
            if (int.TryParse(txt_pacid.Text, out id))
            {
                findPatientInformation(id);
            }
            
            
        }
    }
}