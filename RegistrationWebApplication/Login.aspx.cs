using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RegistrationWebApplication.ServiceReference1;

namespace RegistrationWebApplication
{
   
    public partial class Login : System.Web.UI.Page
    {
        ServiceReference1.Service1Client obj = new Service1Client();
        StudDetails stud = new StudDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox2.TextMode = TextBoxMode.Password;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            stud.Username = TextBox1.Text;
            stud.Password = TextBox2.Text;
            obj.CheckLogin(stud);
            bool res = obj.CheckLogin(stud);
            if (res == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Login');", true);
                Response.Redirect("Home.aspx");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert(' Login Failed');", true);
            }
        }
    }
}