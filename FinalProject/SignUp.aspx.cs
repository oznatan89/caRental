using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class SignUp : System.Web.UI.Page
    {
        DB db = new DB();
        string ageClass = null;
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
        protected void SingOut_Click(object sender, EventArgs e)
        {
            Session["login"] = null;
            Response.Write("<script>window.location.href='CaRental.aspx';</script>");
        }
        protected void creat_Click(object sender, EventArgs e)
        {

            if (isEighteenWrong(Age__Id.Text)) //send age of user to test
            {
                if (ageClass.CompareTo("under") == 0)
                    Response.Write("<script language=javascript> alert('You are under 18 years old')</script>");
                if (ageClass.CompareTo("top") == 0)
                    Response.Write("<script language=javascript> alert('Age is not possible')</script>");
                return;
            }

            //if the user try to creat username as 'Admin'
            if (UserName__ID.Text.CompareTo("Admin") == 0)
            {
                Response.Write("<script language=javascript> alert('you can not creat Username as Admin')</script>");
                return;
            }
             
            string id = id__ID.Text;
            string firstName = First__NameID.Text;
            string lastName = Last__NameID.Text;
            string age = setDate(Age__Id.Text);
            string address = Address__ID.Text;
            string mail = Mail__ID.Text;
            string phone = Phone__ID.Text;
            string userName = UserName__ID.Text;
            string password = PassWord__ID.Text;

            string indicationErrorString = db.isCreateClient(id, firstName, lastName, age, address, mail, phone, userName, password);

            if (indicationErrorString.CompareTo("good") == 0)
            {
                Response.Write("<script language=javascript> alert('User successfully added')</script>");
                Response.Write("<script>window.location.href='CaRental.aspx';</script>");
            }
            else if (indicationErrorString.CompareTo("ID") == 0)
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('The ID already exists in the system')</SCRIPT>");
            else if (indicationErrorString.CompareTo("bad") == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Some details are incorrect.\r\nTry Again')</SCRIPT>");
                return;
            }

        }
        private bool isEighteenWrong(string Age)
        {
            //this method returng true if age of user is under 18 and above 120 years old 
            
            DateTime today_DateTime = DateTime.Today;
            DateTime dateOfBirth_DateTime = DateTime.Parse(Age);

            int today_INT = (today_DateTime.Year * 100 + today_DateTime.Month) * 100 + today_DateTime.Day;
            int dateOfBirth_INT = (dateOfBirth_DateTime.Year * 100 + dateOfBirth_DateTime.Month) * 100 + dateOfBirth_DateTime.Day;

            float ageINT = (today_INT - dateOfBirth_INT) / 10000;
            double ageINTD = (today_INT - dateOfBirth_INT) / 10000;
            //startTmp = DateTime.Parse(reader.GetDateTime(5).ToString("dd-MM-yyyy"));
            //endTemp = DateTime.Parse(reader.GetDateTime(6).ToString("dd-MM-yyyy"));


            if (ageINT < 18) // if age of user is under 18 years old
            {
                ageClass = "under";
                return true;
            }
            else if (today_INT - dateOfBirth_INT >= 1200001) // if age of user is above 120 years old 
            {
                ageClass = "top";
                return true;
            }
            else
                return false;
        }
        private string setDate(string age)
        {
            return age.Substring(8, 2) + "-" + age.Substring(5, 2) + "-" + age.Substring(0, 4);
        }
        protected void reset_Click(object sender, EventArgs e)
        {
            resetLoadPage();
        }
        private void resetLoadPage()
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        protected void singin_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn.aspx");
        }
    }
}