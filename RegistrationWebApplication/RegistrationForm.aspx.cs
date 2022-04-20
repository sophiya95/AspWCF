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
    public partial class RegistrationForm : System.Web.UI.Page
    {
        ServiceReference1.Service1Client obj = new Service1Client();
        StudDetails stud = new StudDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPassword.TextMode = TextBoxMode.Password;
            if (!Page.IsPostBack)
            {
                BindStudDetails(null);
                ClearControls();

            }

        }
        private void BindStudDetails(int? Studid)
        {

            DataSet ds = new DataSet();

            ds = obj.GetStudDetails(stud);
            GridView1.DataSource = ds;

            GridView1.DataBind();

        }
        private void SaveStudDetails()
        {
            string str = "";
            for (int i = 0; i <= CheckBoxList1.Items.Count - 1; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {

                    if (str == "")
                    {

                        str = CheckBoxList1.Items[i].Text;

                    }

                    else
                    {

                        str += "," + CheckBoxList1.Items[i].Text;

                    }
                }
            }
            stud.Firstname = txtFname.Text.Trim();
            stud.Lastname = txtLname.Text.Trim();
            stud.Studaddress = txtaddress.Value.Trim();
            stud.Gender = RadioButtonList1.Text.Trim();
            stud.Course = DropDownList1.SelectedValue.ToString();
            //stud.Sports = CheckBoxList1.Text.Trim();
            stud.Sports = str.ToString();
            stud.Phone = txtPhone.Text.Trim();
            stud.Emailaddress = txtEmail.Text.Trim();
            stud.Username = txtUsername.Text.Trim();
            stud.Password = txtPassword.Text.Trim();
            lblStatus.Text = obj.InsertStudDetails(stud);

            ClearControls();
            BindStudDetails(null);
        }
        private void UpdateStudDetails()
        {
            string str = "";
            for (int i = 0; i <= CheckBoxList1.Items.Count - 1; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {

                    if (str == "")
                    {

                        str = CheckBoxList1.Items[i].Text;

                    }

                    else
                    {

                        str += "," + CheckBoxList1.Items[i].Text;

                    }
                }
            }
            //stud.Studid = Convert.ToInt32(ViewState["studid"].ToString());
            stud.Studid = Convert.ToInt32(Hdn1.Value);
            stud.Firstname = txtFname.Text.Trim();
            stud.Lastname = txtLname.Text.Trim();
            stud.Studaddress = txtaddress.Value.Trim();
            stud.Gender = RadioButtonList1.Text.Trim();
            stud.Course = DropDownList1.SelectedValue.ToString();
            stud.Sports = str.ToString();
            stud.Phone = txtPhone.Text.Trim();
            stud.Emailaddress = txtEmail.Text.Trim();
            stud.Username = txtUsername.Text.Trim();
            stud.Password = txtPassword.Text;
            lblStatus.Text = obj.UpdateStudDetails(stud);
            ClearControls();
            BindStudDetails(null);
        }

        protected void ClearControls()
        {
            stud.Firstname = txtFname.Text;
            stud.Lastname = txtLname.Text;
            stud.Studaddress = txtaddress.Value;
            stud.Gender = RadioButtonList1.Text;
            stud.Course = DropDownList1.SelectedValue;
            stud.Sports = CheckBoxList1.Text;
            stud.Phone = txtPhone.Text;
            stud.Emailaddress = txtEmail.Text;
            stud.Username = txtUsername.Text;
            stud.Password = txtPassword.Text;

            btnSubmit.Text = "Submit";
            txtFname.Focus();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (btnSubmit.Text == "Update")
            {
                UpdateStudDetails();
            }
            else
            {
                SaveStudDetails();
            }
        }
        protected void lnkEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            txtPassword.TextMode = TextBoxMode.SingleLine;
            stud.Studid = int.Parse(e.CommandArgument.ToString());
            //ViewState["studid"] = stud.Studid;
            Hdn1.Value = stud.Studid.ToString();
            DataSet ds = new DataSet();
            ds = obj.FetchUpdatedRecords(stud);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtFname.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
                txtLname.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
                txtaddress.Value = ds.Tables[0].Rows[0]["studaddress"].ToString();
                RadioButtonList1.Text = ds.Tables[0].Rows[0]["gender"].ToString();
                DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["course"].ToString();
                CheckBoxList1.Text = ds.Tables[0].Rows[0]["sports"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["emailaddress"].ToString();
                txtUsername.Text = ds.Tables[0].Rows[0]["username"].ToString();
                txtPassword.Text = ds.Tables[0].Rows[0]["password"].ToString();
                btnSubmit.Text = "Update";
            }
        }

        protected void lnkDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            stud.Studid = int.Parse(e.CommandArgument.ToString());
            if (obj.DeleteStudDetails(stud) == true)
            {
                lblStatus.Text = "Record deleted Successfully";
            }
            else
            {
                lblStatus.Text = "Record couldn't be deleted";
            }
            BindStudDetails(null);
        }

        protected void Reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}