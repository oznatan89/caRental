using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text; 
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
 
namespace FinalProject {
    public partial class PersonalPage:System.Web.UI.Page 
    {

        DB db = new DB();
        private StringBuilder rental_Builder_Table = new StringBuilder();
        DateTime date1, date2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack) 
            {
                changeVisiable(Panel_CarBookingID, Panel_orderHistoryID, Panel_settingID);
                changeColor(carBookingButtonID, orderHhistoryButtonID, SettingsButtonID);
            }

            if(Session["login"] != null) {
                string login_temp = Session["login"].ToString();

                if(login_temp.CompareTo("admin") == 0)
                    Response.Write("<script>window.location.href='Admin.aspx';</script>");
                else
                    idHelloUser.Text = "Hello " + login_temp;
            }
            else
                Response.Write("<script>window.location.href='CaRental.aspx';</script>");
        }

        protected void SingOut_Click(object sender, EventArgs e)
        {
            Session["login"] = null;
            Response.Write("<script>window.location.href='CaRental.aspx';</script>");
        }
        

        private void changeVisiable(Panel a, Panel b, Panel c) {
            a.Visible = true;
            b.Visible = false;
            c.Visible = false;
        }
        private void changeColor(Button a, Button b, Button c) {
            a.Style.Add("opacity", "1");
            a.Style.Add("color", "#f00");
            a.Style.Add("border", "1px solid #f00");

            b.Style.Add("opacity", "0.75");
            b.Style.Add("color", "#111");
            b.Style.Add("border", "0px solid #f00");

            c.Style.Add("opacity", "0.75");
            c.Style.Add("color", "#111");
            c.Style.Add("border", "0px solid #f00");
        }

        protected void CarBooking_click(object sender, EventArgs e) {
            changeVisiable(Panel_CarBookingID, Panel_orderHistoryID, Panel_settingID);
            changeColor(carBookingButtonID, orderHhistoryButtonID, SettingsButtonID);

            Calendar_Start_ID.Visible = false;
            TextBox_Start_ID.Text = "";
            Calendar_End_ID.Visible = false;
            TextBox_End_ID.Text = "";

            PlaceHolder_Car.Visible = true;

        }
        protected void OrderHistory_click(object sender, EventArgs e) {
            changeVisiable(Panel_orderHistoryID, Panel_CarBookingID, Panel_settingID);
            changeColor(orderHhistoryButtonID, carBookingButtonID, SettingsButtonID);

            PlaceHolder_Car.Visible = false;

            {// load order_History table to GridView
                GridView_orderHistoryID.DataSource = db.load_orderHistory_for_user(Session["login"].ToString());
                GridView_orderHistoryID.DataBind();
            }
        }
        protected void Settings_click(object sender, EventArgs e) {
            changeVisiable(Panel_settingID, Panel_CarBookingID, Panel_orderHistoryID);
            changeColor(SettingsButtonID, carBookingButtonID, orderHhistoryButtonID);

            PlaceHolder_Car.Visible = false;
        }





        private void changeVisiable(Calendar temp) {
            if(temp.Visible)
                temp.Visible = false;
            else
                temp.Visible = true;
        }
        protected void ImageButton_Start_Click(object sender, ImageClickEventArgs e) {
            changeVisiable(Calendar_Start_ID);
            Calendar_End_ID.Visible = false;
        }
        protected void Calendar_Start_SelectionChanged(object sender, EventArgs e) {
            TextBox_Start_ID.Text = Calendar_Start_ID.SelectedDate.ToString("dd-MM-yyyy");
            Calendar_Start_ID.Visible = false;
        }

        protected void Calendar_End_SelectionChanged(object sender, EventArgs e) {
            TextBox_End_ID.Text = Calendar_End_ID.SelectedDate.ToString("dd-MM-yyyy");
            Calendar_End_ID.Visible = false;
        }
        protected void ImageButton_End_Click(object sender, ImageClickEventArgs e) {
            changeVisiable(Calendar_End_ID);
            Calendar_Start_ID.Visible = false;
        }





        protected void Search_ID_Click(object sender, EventArgs e) {
            if((TextBox_Start_ID.Text != "") && (TextBox_End_ID.Text != "")) {
                date1 = DateTime.Parse(TextBox_Start_ID.Text);
                date2 = DateTime.Parse(TextBox_End_ID.Text);
            }
            else {
                Response.Write("<script>alert('Fill date. please')</script>");
                return;
            }

            if(TextBox_Start_ID.Text == "") {
                Response.Write("<script>alert('The first date is missing')</script>");
                return;
            }
            else if(TextBox_End_ID.Text == "") {
                Response.Write("<script>alert('The end data is missing')</script>");
                return;
            }
            else if((DateTime.Compare(date1, DateTime.Today)) <= 0) {
                Response.Write("<script>alert('U cant Rent a car from today or sometime before')</script>");
                return;
            }
            else if(((date2 - date1).Days) > 30) {
                Response.Write("<script>alert('U cant Rent a car for more than 30 days')</script>");
                return;
            }
            else if(!(DateTime.Compare(date1, date2) < 0)) {
                Response.Write("<script>alert('Please choose valid dates')</script>");
                return;
            }
            else {
                rental_Builder_Table = db.load_Cars_For_Admin(TextBox_Start_ID.Text, TextBox_End_ID.Text, ((ManualBox_ID.Checked) ? true : false), ((priceID_up.Checked) ? true : false)); //convert date to string, and sent 
                PlaceHolder_Car.Controls.Add(new Literal { Text = rental_Builder_Table.ToString() });
            }
            //PlaceHolder_Car add?? or =="" ?
        }





        [WebMethod]
        public static void change_First_Name(string new_First_Name) {
            if(new_First_Name.ToString().Trim() == "" || new_First_Name.ToString().Trim() == null)
                return;
            PersonalPage person = new PersonalPage();
            person.chenge_First_Name_Temp(new_First_Name);
        }
        private void chenge_First_Name_Temp(string new_First_Name_Temp) {
            if(db.create_Message_to_Admin_From_User_exist(Session["login"].ToString(), "Hi, Please change my First Name to: " +new_First_Name_Temp))
                System.Windows.Forms.MessageBox.Show("Your request has been sent to Administrator");
            else
                System.Windows.Forms.MessageBox.Show("Your request failed");
        }


        [WebMethod]
        public static void change_Last_Name(string new_Last_Name) {
            if(new_Last_Name.ToString().Trim() == "" || new_Last_Name.ToString().Trim() == null)
                return;
            PersonalPage person = new PersonalPage();
            person.change_Last_Name_Temp(new_Last_Name);
        }
        private void change_Last_Name_Temp(string new_Last_Name_Temp) {
            if(db.create_Message_to_Admin_From_User_exist(Session["login"].ToString(), "Hi, Please change my Last Name to: " +new_Last_Name_Temp))
                System.Windows.Forms.MessageBox.Show("Your request has been sent to Administrator");
            else
                System.Windows.Forms.MessageBox.Show("Your request failed");
        }


        [WebMethod]
        public static void change_Address(string new_Address) {
            if(new_Address.ToString().Trim() == "" || new_Address.ToString().Trim() == null)
                return;
            PersonalPage person = new PersonalPage();
            person.change_Address_Temp(new_Address);
        }
        private void change_Address_Temp(string new_Address_Temp) {
            if(db.create_Message_to_Admin_From_User_exist(Session["login"].ToString(), "Hi, Please change my Address to: " +new_Address_Temp))
                System.Windows.Forms.MessageBox.Show("Your request has been sent to Administrator");
            else
                System.Windows.Forms.MessageBox.Show("Your request failed");
        }


        [WebMethod]
        public static void change_Email(string new_Email) {
            if(new_Email.ToString().Trim() == "" || new_Email.ToString().Trim() == null)
                return;
            PersonalPage person = new PersonalPage();
            person.change_Email_Temp(new_Email);
        }
        private void change_Email_Temp(string new_Email_Temp) {
            if(db.create_Message_to_Admin_From_User_exist(Session["login"].ToString(), "Hi, Please change my Email to: " +new_Email_Temp))
                System.Windows.Forms.MessageBox.Show("Your request has been sent to Administrator");
            else
                System.Windows.Forms.MessageBox.Show("Your request failed");
        }


        [WebMethod]
        public static void change_Phone_Number(string new_Phone_Number) {
            if(new_Phone_Number.ToString().Trim() == "" || new_Phone_Number.ToString().Trim() == null)
                return;
            PersonalPage person = new PersonalPage();
            person.change_Phone_Number_Temp(new_Phone_Number);
        }
        protected void change_Phone_Number_Temp(string new_Phone_Number_Temp) {
            if((db.create_Message_to_Admin_From_User_exist(Session["login"].ToString(), "Hi, Please change my Phone Number to: " +new_Phone_Number_Temp)))
                //Response.Write("<script>alert('Your request failed')</script>"); //not working
                System.Windows.Forms.MessageBox.Show("Your request has been sent to Administrator");
            else
                System.Windows.Forms.MessageBox.Show("Your request failed");
        } 

        [WebMethod]
        public static void change_User_Name(string new_User_Name) {
            if(new_User_Name.ToString().Trim() == "" || new_User_Name.ToString().Trim() == null)
                return;
            PersonalPage person = new PersonalPage();
            person.change_User_Name_Temp(new_User_Name);
        }
        private void change_User_Name_Temp(string new_User_Name_Temp) {
            if(db.create_Message_to_Admin_From_User_exist(Session["login"].ToString(), "Hi, Please change my User Name to: " +new_User_Name_Temp))
                System.Windows.Forms.MessageBox.Show("Your request has been sent to Administrator");
            else
                System.Windows.Forms.MessageBox.Show("Your request failed");
        }


        [WebMethod]
        public static void change_Password(string new_Password) {
            if(new_Password.ToString().Trim() == "" || new_Password.ToString().Trim() == null)
                return;
            PersonalPage person = new PersonalPage();
            person.change_Password_Temp(new_Password);
        }
        private void change_Password_Temp(string new_Password_Temp) {
            if(db.create_Message_to_Admin_From_User_exist(Session["login"].ToString(), "Hi, Please change my Password to: " +new_Password_Temp))
                System.Windows.Forms.MessageBox.Show("Your request has been sent to Administrator");
            else
                System.Windows.Forms.MessageBox.Show("Your request failed");
        }

        [WebMethod]
        public static void delete_Account(string answer)
        {
            PersonalPage person = new PersonalPage();
            person.delete_Account_Temp();
        }
        private void delete_Account_Temp()
        {
            if(db.create_Message_to_Admin_From_User_exist(Session["login"].ToString(), "Hi, Delete My Account Please."))
                System.Windows.Forms.MessageBox.Show("Your request has been sent to Administrator");
            else
                System.Windows.Forms.MessageBox.Show("Your request failed");
        }


        [WebMethod]
        public static bool create_Rental(string license_Plate, string startDate, string endDate, string price)
        {
            PersonalPage person = new PersonalPage();
            if(person.create_Rental_Temp(license_Plate, startDate, endDate, price))
                return true;
            else
                return false;
        }
        private bool create_Rental_Temp(string license_Plate, string startDate, string endDate, string price)
        {
            if(db.is_Create_Rental_Line(Session["login"].ToString(), license_Plate, startDate, endDate, price)) {
                db.WriteMessageForSupport("Support", " ", " ", Session["login"] + " was Rent a Car. call him to arrange patment");
                return true;
            }
            return false;
        }
    }
}