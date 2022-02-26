using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Branches : System.Web.UI.Page {

        private DB db = new DB();
        protected void Page_Load(object sender, EventArgs e) {
            if(Session["login"] != null) {
                string login_temp = Session["login"].ToString();
                if(login_temp.CompareTo("admin") == 0) {
                    idHelloAdmin.Visible = true;
                    idHelloUser.Visible = false;
                }
                else {
                    idHelloAdmin.Visible = false;
                    idHelloUser.Visible = true;
                    idHelloUser.Text = "Hello " + login_temp;
                }
                idSignIn.Visible = false;
                idSignUp.Visible = false;
                idSignOut.Visible = true;
            }
            else {
                idSignIn.Visible = true;
                idHelloAdmin.Visible = false;
                idHelloUser.Visible = false;
                idSignUp.Visible = true;
                idSignOut.Visible = false;
            }

            {//load details
                string[] addressDetails = db.loadAddress();

                address_ID.InnerText = addressDetails[0].Trim();
                mail_ID.InnerText = addressDetails[1].Trim();                
                phone_ID.InnerHtml = addressDetails[2].Trim();
                whatsapp_ID.InnerText = addressDetails[3].Trim();
                fax_ID.InnerHtml = addressDetails[4].Trim();                
                map_ID.Src = addressDetails[5];

                mail_ID.HRef = "mailto:" + mail_ID.InnerText.Trim();
                whatsapp_ID.HRef="https://api.whatsapp.com/send?phone=972"+whatsapp_ID.InnerHtml+"&text=Hay Oz";
            }
        }
        protected void SingOut_Click(object sender, EventArgs e)
        {
            Session["login"] = null;
            Response.Write("<script>window.location.href='CaRental.aspx';</script>");
        }
    }
}