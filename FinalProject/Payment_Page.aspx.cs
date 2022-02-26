using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


namespace FinalProject {
    public partial class Payment_Page:System.Web.UI.Page {
        DB db = new DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack) {

            }
            if(Session["login"] != null) {
                string login_temp = Session["login"].ToString();

                if(login_temp.CompareTo("admin") != 0)
                    Response.Write("<script>window.location.href='Payment_Page.aspx';</script>");
            }
            else
                Response.Write("<script>window.location.href='CaRental.aspx';</script>");
        }

        [WebMethod]
        public static bool Submit_Click(string credit_No_ID, string validity_Month_ID, string validity_Year_ID, string cvv_ID) 
        {
            return ((new Payment_Page()).Submit_Click_Temp(credit_No_ID, validity_Month_ID, validity_Year_ID, cvv_ID));                
        }
        private bool Submit_Click_Temp(string credit_No_ID_Temp, string validity_Month_ID_Temp, string validity_Year_ID_Temp, string cvv_ID_Temp)
        {
            {//check if "Credit card No." is only digit
                string credit_String_Temp = credit_No_ID_Temp;
                if(credit_String_Temp == null || credit_String_Temp =="")
                    return false;
                foreach(char temp in credit_String_Temp) {
                    if(((temp-'0') <0) || ((temp-'0') >9))
                        return false;
                }
            }
            {//check if "CVV" is only digit
                string cvv_String_Temp = cvv_ID_Temp;
                if(cvv_String_Temp == null || cvv_String_Temp =="")
                    return false;
                foreach(char temp in cvv_String_Temp) {
                    if(((temp-'0') <0) || ((temp-'0') >9))
                        return false;
                }
            }
            return (db.is_create_credit_card(Session["login"].ToString(), credit_No_ID_Temp, validity_Month_ID_Temp, validity_Year_ID_Temp, cvv_ID_Temp));
        }
    }
}