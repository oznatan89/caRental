using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FinalProject
{
    public partial class Career : System.Web.UI.Page
    {
        private DB db = new DB();
        private StringBuilder table = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            table = db.loadJobCareersForUser();
            PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });

            if (Session["login"] != null)
            {
                string login_temp = Session["login"].ToString();
                if (login_temp.CompareTo("admin") == 0)
                {
                    idHelloAdmin.Visible = true;
                    idHelloUser.Visible = false;
                }
                else
                {
                    idHelloAdmin.Visible = false;
                    idHelloUser.Visible = true;
                    idHelloUser.Text = "Hello " + login_temp;
                }
                idSignIn.Visible = false;
                idSignUp.Visible = false;
                idSignOut.Visible = true;
            }
            else
            {
                idSignIn.Visible = true;
                idHelloAdmin.Visible = false;
                idHelloUser.Visible = false;
                idSignUp.Visible = true;
                idSignOut.Visible = false;
            }
        }
        protected void SingOut_Click(object sender, EventArgs e)
        {
            Session["login"] = null;
            Response.Write("<script>window.location.href='CaRental.aspx';</script>");
        }
    }
}