using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Contact : System.Web.UI.Page
    {
        DB db = new DB();

        protected void Page_Load(object sender, EventArgs e)
        {
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
        protected void SendButton_Click(object sender, EventArgs e)
        {
            string from = NameId.Value;
            string email = EmailId.Value;
            string phone = PhoneID.Value;
            string message = textareaID.Value;

            if (db.WriteMessageForSupport(from, email, phone, message))
                Response.Write("<script>alert('The message has been sent successfully')</script>");
            else
                Response.Write("<script>alert('The Message is not sent')</script>");

            Response.Write("<script>window.location.href='CaRental.aspx';</script>");
            //    Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
        protected void ResetButten_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}