using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class SignIn : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { }
            if (Session["login"] == null)
            {
                idSignIn.Visible = true;      
                idSignUp.Visible = true;            
            }
            else
            {
                Response.Write("<script>window.location.href='CaRental.aspx';</script>");
            }
        }
        protected void SignIn_Click(object sender, EventArgs e)
        {
            //this method check about login of user

            string user = usernameID.Text;
            string pwd = passwordID.Text;
            if (db.isSignIn(user, pwd))
            {
                //Response.Write("<script language=javascript>alert('Login successful')</script>");
                //Server.Transfer("CaRental.aspx");                

                if (usernameID.Text.CompareTo("Admin") == 0)
                {
                    Session["login"] = "admin";
                    Response.Write("<script>window.location.href='Admin.aspx';</script>");
                    return;
                }
                else //if login isnt Admin
                {
                    Session["login"] = user;
                    Response.Write("<script>alert('Login successful, Hello " + user + "')</script>");
                    Response.Write("<script>window.location.href='PersonalPage.aspx';</script>");
                    return;
                }
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Login failed');", true);
        }
    }
}