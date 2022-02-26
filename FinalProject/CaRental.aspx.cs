﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class CaRental : System.Web.UI.Page
    {
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
    }
}