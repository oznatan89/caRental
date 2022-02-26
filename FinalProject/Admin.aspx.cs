using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;


namespace FinalProject {

    public partial class Admin:System.Web.UI.Page {

        string connectionString = @"Data Source=(LocalDB)\v11.00;AttachDbFilename=D:\Dropbox\לימודים\הקריה ללימודי הנדסה וטכנולוגיה\שנה ב\דריו בוג'יו\פרוייקט גמר\FinalProject\DB\DB.mdf;Integrated Security=True;Connect Timeout=30";
        //string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Dropbox\לימודים\הקריה ללימודי הנדסה וטכנולוגיה\שנה ב\דריו בוג'יו\פרוייקט גמר\FinalProject\DB\DB.mdf;Integrated Security=True;Connect Timeout=30";

        private DB db = new DB();
        private StringBuilder table_Message = new StringBuilder();
        private StringBuilder table_Careers = new StringBuilder();
        private StringBuilder table_Deal = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e) {
            if(!Page.IsPostBack) {
                PlaceHolder_Message.Visible = false;

                PlaceHolder_Careers.Visible = false;
                addJobId.Visible = false;

                PlaceHolder_Deal.Visible = false;
                addDealId.Visible = false;

                PlaceHolder_Report.Visible = false;

                PlaceHolder_AddressDetails.Visible = false;
            }

            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = "";

            {
                if(Session["login"] != null) {
                    string login_temp = Session["login"].ToString();

                    if(login_temp.CompareTo("admin") != 0)
                        Response.Write("<script>window.location.href='PersonalPage.aspx';</script>");
                }
                else
                    Response.Write("<script>window.location.href='CaRental.aspx';</script>");
            }
        }


        protected void SingOut_Click(object sender, EventArgs e) {
            Session["login"] = null;
            Response.Write("<script>window.location.href='CaRental.aspx';</script>");
        }

        private void loadPageForFullData() {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        protected void Full_Messages_For_DB(object sender, EventArgs e) {
            db.WriteMessageForSupport("oz", "oz@gmail.com", "000-0000000", "asdf adsf asdf asdf ");
            db.WriteMessageForSupport("zipi", "zipi@gmail.com", "111-1111111", "bbbbb bbbbb bbbbb bb b");
            db.WriteMessageForSupport("dudu", "dudu@gmail.com", "222-2222222", "aaaaaaa aaaaaaaa aaaa ");
            db.WriteMessageForSupport("ofri", "ofri@gmail.com", "333-3333333", "messagem essagemessage");

            loadPageForFullData();
        }
        protected void Full_Careers_For_DB(object sender, EventArgs e) {
            db.WriteCareersForSupport("Security  ", "Require a security man                         ");
            db.WriteCareersForSupport("Counselor ", "Require a Counselor to the office.             ");
            db.WriteCareersForSupport("Driver    ", "A driver is required for our driver team.      ");
            db.WriteCareersForSupport("General   ", "Require a general employee to gas station.     ");
            db.WriteCareersForSupport("Secratary ", "Require secratary fo the office.               ");
            db.WriteCareersForSupport("CPA       ", "Require an accountant to our accounting firm.  ");
            db.WriteCareersForSupport("Cleaner   ", "Require a car cleaner.                         ");
            db.WriteCareersForSupport("Manager   ", "A team manager is required to transport the vehicles among the customers. ");
            db.WriteCareersForSupport("Director  ", "Require a Director                             ");
            db.WriteCareersForSupport("CEO       ", "Require a CEO.                                 ");

            loadPageForFullData();
        }
        protected void Full_Deal_For_DB(object sender, EventArgs e) {
            db.createDeal("Mile", "unlimited mile", "21", "04", "2021");
            db.createDeal("Gas", "Unlimited full tank", "03", "08", "2023");
            db.createDeal("1+1", "one more car for week", "29", "02", "2020");
            db.createDeal("Weekend", "free 50%", "15", "09", "2021");

            loadPageForFullData();
        }

        

        private void changeVisibleForPlaceHolder(PlaceHolder a, PlaceHolder b, PlaceHolder c, PlaceHolder d, PlaceHolder e) {
            a.Visible = true;
            b.Visible = false;
            c.Visible = false;
            d.Visible = false;
            e.Visible = false;
        }
        private void changeColorForButton(Button a, Button b, Button c, Button d, Button e) {
            a.Style.Add("opacity", "1");
            a.Style.Add("color", "#f00");
            a.Style.Add("border", "1px solid #f00");

            b.Style.Add("opacity", "0.75");
            b.Style.Add("color", "#111");
            b.Style.Add("border", "0px solid #f00");

            c.Style.Add("opacity", "0.75");
            c.Style.Add("color", "#111");
            c.Style.Add("border", "0px solid #f00");

            d.Style.Add("opacity", "0.75");
            d.Style.Add("color", "#111");
            d.Style.Add("border", "0px solid #f00");

            e.Style.Add("opacity", "0.75");
            e.Style.Add("color", "#111");
            e.Style.Add("border", "0px solid #f00");
        }

        protected void Show_Report_Click(object sender, EventArgs e) {

            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = "";

            changeVisibleForPlaceHolder(PlaceHolder_Report, PlaceHolder_Deal, PlaceHolder_Careers, PlaceHolder_Message, PlaceHolder_AddressDetails);
            changeColorForButton(reportButtonId, dealsButtonId, CareersButtonId, myMessagesButtonId, addressDetailsButtonId);

            addJobId.Visible =false;
            addDealId.Visible =false;

            Rental_Click(sender, e);
        }
        protected void Show_Careers_Click(object sender, EventArgs e) {
            table_Deal = db.load_Careers_For_Admin();
            PlaceHolder_Careers.Controls.Add(new Literal { Text = table_Deal.ToString() });

            changeVisibleForPlaceHolder(PlaceHolder_Careers, PlaceHolder_Message, PlaceHolder_Deal, PlaceHolder_Report, PlaceHolder_AddressDetails);
            changeColorForButton(CareersButtonId, myMessagesButtonId, dealsButtonId, reportButtonId, addressDetailsButtonId);

            addJobId.Visible =true;
            addDealId.Visible =false;
        }
        protected void Show_Deals_Click(object sender, EventArgs e) {
            table_Deal = db.load_deals_For_Admin();
            PlaceHolder_Deal.Controls.Add(new Literal { Text = table_Deal.ToString() });

            changeVisibleForPlaceHolder(PlaceHolder_Deal, PlaceHolder_Careers, PlaceHolder_Message, PlaceHolder_Report, PlaceHolder_AddressDetails);
            changeColorForButton(dealsButtonId, CareersButtonId, myMessagesButtonId, reportButtonId, addressDetailsButtonId);

            addJobId.Visible =false;
            addDealId.Visible =true;
        }
        protected void Show_Message_Click(object sender, EventArgs e) {
            table_Careers = db.load_Message_For_Admin();
            PlaceHolder_Message.Controls.Add(new Literal { Text = table_Careers.ToString() });

            changeVisibleForPlaceHolder(PlaceHolder_Message, PlaceHolder_Careers, PlaceHolder_Deal, PlaceHolder_Report, PlaceHolder_AddressDetails);
            changeColorForButton(myMessagesButtonId, CareersButtonId, dealsButtonId, reportButtonId, addressDetailsButtonId);

            addJobId.Visible =false;
            addDealId.Visible =false;
        }
        protected void Show_addressDetails_Click(object sender, EventArgs e) {
            {//load details
                string[] addressDetails = db.loadAddress();

                addressID.Text = addressDetails[0].Trim();
                mailID.Text = addressDetails[1].Trim();
                phoneID.Text = addressDetails[2].Trim();
                faxID.Text = addressDetails[3].Trim();
                whatsappID.Text = addressDetails[4].Trim();
                mapID.Text = addressDetails[5].Trim();
            }

            changeVisibleForPlaceHolder(PlaceHolder_AddressDetails, PlaceHolder_Message, PlaceHolder_Careers, PlaceHolder_Deal, PlaceHolder_Report);
            changeColorForButton(addressDetailsButtonId, myMessagesButtonId, CareersButtonId, dealsButtonId, reportButtonId);

            addJobId.Visible =false;
            addDealId.Visible =false;
        }




        [WebMethod]
        public static void deleteMsgFromDB(string id_message) {
            Admin admin = new Admin();
            admin.deleteMsgFromDB_temp(id_message); // send to Utilities method
        }

        //this method help to deleteMsgFromDB method call to isDelete method
        //"deleteMsgFromDB" method is 'static Method', so, she cant call to isDelete Method
        private void deleteMsgFromDB_temp(string id) {
            db.deleteMsg(id);
        }



        [WebMethod]
        public static void add_Job(string title, string details) {
            Admin admin = new Admin();
            admin.addJob_Temp(title, details);
        }
        public void addJob_Temp(string title, string details) {
            if(db.WriteCareersForSupport(title, details))
                Response.Write("<script>alert('The Career has created')</script>");
            else
                Response.Write("<script>alert('System failed to create a career')</script>");
        }
        [WebMethod]
        public static void del_career_Click(string id_Careers) {
            Admin admin = new Admin();
            admin.delCareer_Temp(id_Careers);
        }
        private void delCareer_Temp(string id) {
            db.delCareers(id);
        }


        [WebMethod]
        public static void addDeal(string title, string details, string dayValidity, string mountValidity, string yearValidity) {
            Admin admin = new Admin();
            admin.addDeal_Temp(title, details, dayValidity, mountValidity, yearValidity);
        }
        public void addDeal_Temp(string title, string details, string dayValidity, string mountValidity, string yearValidity) {
            db.createDeal(title, details, dayValidity, mountValidity, yearValidity);
        }
        [WebMethod]
        public static void del_deal(string id_deal) {
            Admin admin = new Admin();
            admin.delDeal_Temp(id_deal);
        }
        private void delDeal_Temp(string id) {
            db.del_deal(id);
        }




        private void changeVisiableForGridView(GridView a, GridView b, GridView c, GridView d, GridView e) {
            a.Visible = true;
            b.Visible = false;
            c.Visible = false;
            d.Visible = false;
            e.Visible = false;
        }
        private void changeColorForli(LinkButton a, LinkButton b, LinkButton c, LinkButton d, LinkButton e) {
            a.Style.Add("color", "red");
            a.Style.Add("text-decoration", "underline");

            b.Style.Add("color", "default");
            b.Style.Add("text-decoration", "none");

            c.Style.Add("color", "default");
            c.Style.Add("text-decoration", "none");

            d.Style.Add("color", "default");
            d.Style.Add("text-decoration", "none");

            e.Style.Add("color", "default");
            e.Style.Add("text-decoration", "none");
        }
        

        protected void Rental_Click(object sender, EventArgs e) {
            {
                changeVisiableForGridView(GridView_Report_Rental, GridView_Report_Cars, GridView_Report_Event, GridView_Report_Clients, GridView_Credit_Card);
                changeColorForli(Rentals_link_ID, Cars_link_ID, Event_link_ID, Clients_link_ID, Credit_Card_link_ID);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = "";
            }
            DataTable dtbl = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Rentals]", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if(dtbl.Rows.Count > 0) {
                GridView_Report_Rental.DataSource = dtbl;
                GridView_Report_Rental.DataBind();
            }
            else {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView_Report_Rental.DataSource = dtbl;
                GridView_Report_Rental.DataBind();
                GridView_Report_Rental.Rows[0].Cells.Clear();
                GridView_Report_Rental.Rows[0].Cells.Add(new TableCell());
                GridView_Report_Rental.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count + 1;
                GridView_Report_Rental.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView_Report_Rental.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void GridView_Report_Rental_RowCommand(object sender, GridViewCommandEventArgs e) {
            try {
                if(e.CommandName.Equals("AddNew")) {
                    {
                        {//Check if id exist in system
                            string id_Check = (GridView_Report_Rental.FooterRow.FindControl("txt_Id_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim();
                            if((id_Check!="") && (!(db.is_Id_Exists(id_Check)))) {
                                Rental_Click(sender, e);
                                lblSuccessMessage.Text = "";
                                lblErrorMessage.Text = "ID does not exist";
                                return;
                            }
                        }
                        {
                            if(((GridView_Report_Rental.FooterRow.FindControl("txt_ID_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim()).Equals("000000000")) {
                                Rental_Click(sender, e);
                                lblSuccessMessage.Text = "";
                                lblErrorMessage.Text = "can not add rental line to 'Admin' user";
                                return;
                            }
                        }
                        {//check if license_plate exist
                            string license_plate_Check = (GridView_Report_Rental.FooterRow.FindControl("txt_license_plate_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim();
                            if(!(db.is_license_plate_Exists(license_plate_Check))) {
                                Rental_Click(sender, e);
                                lblSuccessMessage.Text = "";
                                lblErrorMessage.Text = "License plate does not exist";
                                return;
                            }
                        }

                        { //check if ('start_rentel' before 'end_rentel') and ('start_rental' before 'order_rental') and (The car rental period does not exceed 30 days)
                            DateTime Start_Rental_Check = DateTime.Parse((GridView_Report_Rental.FooterRow.FindControl("txt_Start_Rental_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                            DateTime End_Rental_Check = DateTime.Parse((GridView_Report_Rental.FooterRow.FindControl("txt_End_Rental_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                            DateTime Order_Date_Check = DateTime.Parse((GridView_Report_Rental.FooterRow.FindControl("txt_OrderDate_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());

                            if((DateTime.Compare(End_Rental_Check, Start_Rental_Check) <= 0) ||(DateTime.Compare(Start_Rental_Check, Order_Date_Check) < 0) ||  ((End_Rental_Check - Start_Rental_Check).Days > 30))
                            {
                                Rental_Click(sender, e);
                                lblSuccessMessage.Text = "";
                                lblErrorMessage.Text = "Please choose valid dates, Up to 30 days.";
                                return;
                            }
                        }
                    }

                    using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                        sqlCon.Open();
                        string query = "INSERT INTO [Rentals] (id,license_plate,Start_Rental,End_Rental,Price,OrderDate) VALUES (@id,@license_plate,@Start_Rental,@End_Rental,@Price,@OrderDate)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@id", (GridView_Report_Rental.FooterRow.FindControl("txt_Id_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@license_plate", (GridView_Report_Rental.FooterRow.FindControl("txt_license_plate_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Start_Rental", (GridView_Report_Rental.FooterRow.FindControl("txt_Start_Rental_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@End_Rental", (GridView_Report_Rental.FooterRow.FindControl("txt_End_Rental_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Price", (GridView_Report_Rental.FooterRow.FindControl("txt_Price_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@OrderDate", (GridView_Report_Rental.FooterRow.FindControl("txt_OrderDate_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        Rental_Click(sender, e);
                        lblSuccessMessage.Text = "Rent added successfully.";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch(Exception ex) {
                Rental_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView_Report_Rental_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            try {
                using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    sqlCon.Open();
                    string query = "DELETE FROM [Rentals] WHERE Num_Invitations = @NumInvitations";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@NumInvitations", Convert.ToInt32(GridView_Report_Rental.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    Rental_Click(sender, e);
                    lblSuccessMessage.Text = "Selected Record Deleted successfully";
                    lblErrorMessage.Text = "";
                }
            }
            catch(Exception ex) {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        

        protected void Cars_Click(object sender, EventArgs e) {
            {
                changeVisiableForGridView(GridView_Report_Cars, GridView_Report_Rental, GridView_Report_Event, GridView_Report_Clients, GridView_Credit_Card);
                changeColorForli(Cars_link_ID, Rentals_link_ID, Event_link_ID, Clients_link_ID, Credit_Card_link_ID);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = "";
            }
            DataTable dtbl = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Cars]", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if(dtbl.Rows.Count > 0) {
                GridView_Report_Cars.DataSource = dtbl;
                GridView_Report_Cars.DataBind();
            }
            else {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView_Report_Cars.DataSource = dtbl;
                GridView_Report_Cars.DataBind();
                GridView_Report_Cars.Rows[0].Cells.Clear();
                GridView_Report_Cars.Rows[0].Cells.Add(new TableCell());
                GridView_Report_Cars.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count + 1;
                GridView_Report_Cars.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView_Report_Cars.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void GridView_Report_Cars_RowCommand(object sender, GridViewCommandEventArgs e) {
            try {
                if(e.CommandName.Equals("AddNew")) {
                    using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                        sqlCon.Open();
                        string query = "INSERT INTO [Cars] (license_plate,Type,Year,Color,Miles,Status,ManualBox,Value_coefficient,ImagePath) VALUES (@license_plate,@Type,@Year,@Color,@Miles,@Status,@ManualBox,@Value_coefficient,@ImagePath)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@license_plate", (GridView_Report_Cars.FooterRow.FindControl("txt_license_plate_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Type", (GridView_Report_Cars.FooterRow.FindControl("txt_Type_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Year", (GridView_Report_Cars.FooterRow.FindControl("txt_Year_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Color", (GridView_Report_Cars.FooterRow.FindControl("txt_Color_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Miles", (GridView_Report_Cars.FooterRow.FindControl("txt_Miles_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Status", (GridView_Report_Cars.FooterRow.FindControl("txt_Status_Footer") as DropDownList).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@ManualBox", (GridView_Report_Cars.FooterRow.FindControl("txt_ManualBox_Footer") as DropDownList).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Value_coefficient", (GridView_Report_Cars.FooterRow.FindControl("txt_Value_coefficient_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@ImagePath", ((GridView_Report_Cars.FooterRow.FindControl("txt_ImagePath_Footer") as FileUpload).FileName).Trim());


                        sqlCmd.ExecuteNonQuery();
                        Cars_Click(sender, e);
                        lblSuccessMessage.Text = "Car added successfully.";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch(Exception ex) {
                Cars_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView_Report_Cars_RowEditing(object sender, GridViewEditEventArgs e) {
            GridView_Report_Cars.EditIndex = e.NewEditIndex;
            Cars_Click(sender, e);
        }
        protected void GridView_Report_Cars_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            GridView_Report_Cars.EditIndex = -1;
            Cars_Click(sender, e);
        }
        protected void GridView_Report_Cars_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            try {
                using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    sqlCon.Open();
                    string query = "UPDATE Cars SET Color=@Color,Miles=@Miles,Status=@Status,Value_coefficient=@Value_coefficient,ImagePath=@ImagePath WHERE license_plate = @license_plate";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Color", (GridView_Report_Cars.Rows[e.RowIndex].FindControl("txt_Color") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Miles", (GridView_Report_Cars.Rows[e.RowIndex].FindControl("txt_Miles") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Status", (GridView_Report_Cars.Rows[e.RowIndex].FindControl("txt_Status") as DropDownList).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Value_coefficient", (GridView_Report_Cars.Rows[e.RowIndex].FindControl("txt_Value_coefficient") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ImagePath", ((GridView_Report_Cars.Rows[e.RowIndex].FindControl("txt_ImagePath") as FileUpload).FileName).Trim());
                    sqlCmd.Parameters.AddWithValue("@license_plate", GridView_Report_Cars.DataKeys[e.RowIndex].Value.ToString());
                    sqlCmd.ExecuteNonQuery();
                    GridView_Report_Cars.EditIndex = -1;
                    Cars_Click(sender, e);
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch(Exception ex) {
                Cars_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView_Report_Cars_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            try {
                using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    sqlCon.Open();
                    string query = "DELETE FROM [Cars] WHERE license_plate = @license_plate";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@license_plate", GridView_Report_Cars.DataKeys[e.RowIndex].Value.ToString());
                    sqlCmd.ExecuteNonQuery();
                    Cars_Click(sender, e);
                    lblSuccessMessage.Text = "Selected Record Deleted successfully";
                    lblErrorMessage.Text = "";
                }
            }
            catch(Exception ex) {
                Cars_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        

        protected void Event_Click(object sender, EventArgs e) {
            {
                changeVisiableForGridView(GridView_Report_Event, GridView_Report_Clients, GridView_Report_Cars, GridView_Report_Rental, GridView_Credit_Card);
                changeColorForli(Event_link_ID, Cars_link_ID, Rentals_link_ID, Clients_link_ID, Credit_Card_link_ID);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = "";
            }

            DataTable dtbl = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Events]", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if(dtbl.Rows.Count > 0) {
                GridView_Report_Event.DataSource = dtbl;
                GridView_Report_Event.DataBind();
            }
            else {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView_Report_Event.DataSource = dtbl;
                GridView_Report_Event.DataBind();
                GridView_Report_Event.Rows[0].Cells.Clear();
                GridView_Report_Event.Rows[0].Cells.Add(new TableCell());
                GridView_Report_Event.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count + 1;
                GridView_Report_Event.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView_Report_Event.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void GridView_Report_Event_RowCommand(object sender, GridViewCommandEventArgs e) {
            try {
                if(e.CommandName.Equals("AddNew")) {
                    {//Check if id && license_plate are o.k
                        string id_Check = (GridView_Report_Event.FooterRow.FindControl("txt_Id_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim();
                        if((id_Check!="") && (!(db.is_Id_Exists(id_Check)))) {
                            Event_Click(sender, e);
                            lblSuccessMessage.Text = "";
                            lblErrorMessage.Text = "ID does not exist";
                            return;
                        }

                        string license_plate_Check = (GridView_Report_Event.FooterRow.FindControl("txt_license_plate_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim();
                        if(!(db.is_license_plate_Exists(license_plate_Check))) {
                            Event_Click(sender, e);
                            lblSuccessMessage.Text = "";
                            lblErrorMessage.Text = "License plate does not exist";
                            return;
                        }
                    }
                    using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                        sqlCon.Open();

                        string query = "INSERT INTO [Events] (Id,Date,license_plate,Type_Event,Price) VALUES (@id,@date,@license_plate,@type,@price)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@id", (GridView_Report_Event.FooterRow.FindControl("txt_Id_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@date", (GridView_Report_Event.FooterRow.FindControl("txt_Date_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@license_plate", (GridView_Report_Event.FooterRow.FindControl("txt_license_plate_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@type", (GridView_Report_Event.FooterRow.FindControl("txt_Type_Event_Footer") as System.Web.UI.WebControls.DropDownList).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@price", (GridView_Report_Event.FooterRow.FindControl("txt_Price_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        Event_Click(sender, e);
                        lblSuccessMessage.Text = "Event added successfully.";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch(Exception ex) {
                Event_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView_Report_Event_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            try {
                using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    sqlCon.Open();
                    string query = "DELETE FROM [Events] WHERE Num_Event = @Num_Event";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Num_Event", Convert.ToInt32(GridView_Report_Event.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    Event_Click(sender, e);
                    lblSuccessMessage.Text = "Selected Record Deleted successfully";
                    lblErrorMessage.Text = "";
                }
            }
            catch(Exception ex) {
                Event_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        
        protected void Clients_Click(object sender, EventArgs e) {
            {
                changeVisiableForGridView(GridView_Report_Clients, GridView_Report_Event, GridView_Report_Cars, GridView_Report_Rental, GridView_Credit_Card);
                changeColorForli(Clients_link_ID, Cars_link_ID, Rentals_link_ID, Event_link_ID, Credit_Card_link_ID);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = "";
            }
            DataTable dtbl = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Clients]", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if(dtbl.Rows.Count > 0) {
                GridView_Report_Clients.DataSource = dtbl;
                GridView_Report_Clients.DataBind();
            }
            else {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView_Report_Clients.DataSource = dtbl;
                GridView_Report_Clients.DataBind();
                GridView_Report_Clients.Rows[0].Cells.Clear();
                GridView_Report_Clients.Rows[0].Cells.Add(new TableCell());
                GridView_Report_Clients.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count + 1;
                GridView_Report_Clients.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView_Report_Clients.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        /*protected void GridView_Report_Clients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if(e.CommandName.Equals("AddNew"))
                {
                    using(SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO [Clients] (Id,First_Name,Last_Name,Age,Address,Mail,Phone,UserName,Password,Join_Date) VALUES (@id,@first_Name,@last_Name,@age,@address,@mail,@phone,@userName,@password,@join_Date)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@id", (GridView_Report_Clients.FooterRow.FindControl("txt_Id_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@first_Name", (GridView_Report_Clients.FooterRow.FindControl("txt_First_Name_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@last_Name", (GridView_Report_Clients.FooterRow.FindControl("txt_Last_Name_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@age", (GridView_Report_Clients.FooterRow.FindControl("txt_Age_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@address", (GridView_Report_Clients.FooterRow.FindControl("txt_Address_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@mail", (GridView_Report_Clients.FooterRow.FindControl("txt_Mail_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@phone", (GridView_Report_Clients.FooterRow.FindControl("txt_Phone_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@userName", (GridView_Report_Clients.FooterRow.FindControl("txt_UserName_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@password", (GridView_Report_Clients.FooterRow.FindControl("txt_Password_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@join_Date", (GridView_Report_Clients.FooterRow.FindControl("txt_Join_Date_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());


                        sqlCmd.ExecuteNonQuery();
                        Clients_Click(sender, e);
                        lblSuccessMessage.Text = "Clients added successfully.";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch(Exception ex)
            {
                Clients_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }*/
        protected void GridView_Report_Clients_RowEditing(object sender, GridViewEditEventArgs e) {
            {   //if Admin gona change "Admin" line.
                if(((GridView_Report_Clients.Rows[e.NewEditIndex].FindControl("id_ID") as System.Web.UI.WebControls.Label).Text.Trim()).Equals("000000000")) {
                    GridView_Report_Clients.EditIndex = -1;
                    Clients_Click(sender, e);
                    lblSuccessMessage.Text = "";
                    lblErrorMessage.Text = "Unable to edit 'Admin' user";
                    return;
                }
            }
            GridView_Report_Clients.EditIndex = e.NewEditIndex;
            Clients_Click(sender, e);
        }
        protected void GridView_Report_Clients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            GridView_Report_Clients.EditIndex = -1;
            Clients_Click(sender, e);
        }
        protected void GridView_Report_Clients_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            {   //if Admin gona change "Admin" line.
                if(((GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_Id") as System.Web.UI.WebControls.Label).Text.Trim()).Equals("000000000")) {
                    {
                        GridView_Report_Clients.EditIndex = -1;
                        Clients_Click(sender, e);

                        lblSuccessMessage.Text = "";
                        lblErrorMessage.Text = "Unable to update 'Admin' user";
                    }
                    return;
                }
            }
            {// check if Admin change username of user to 'Admin'
                string userNameTemp = (GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_UserName") as System.Web.UI.WebControls.TextBox).Text.Trim();
                if(userNameTemp.Equals("Admin") || userNameTemp.Equals("admin")) {
                    {
                        GridView_Report_Clients.EditIndex = -1;
                        Clients_Click(sender, e);

                        lblSuccessMessage.Text = "";
                        lblErrorMessage.Text = "U Can not change username to 'Admin' or 'admin'.";
                        return;
                    }
                }
            }
            try {
                using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    sqlCon.Open();
                    string query = "UPDATE Clients SET First_Name=@first_Name,Last_Name=@last_Name,Address=@address,Mail=@mail,Phone=@phone,UserName=@userName,Password=@password WHERE Id = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@first_Name", (GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_First_Name") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@last_Name", (GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_Last_Name") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@address", (GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_Address") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@mail", (GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_Mail") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@phone", (GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_Phone") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@userName", (GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_UserName") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@password", (GridView_Report_Clients.Rows[e.RowIndex].FindControl("txt_Password") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", GridView_Report_Clients.DataKeys[e.RowIndex].Value.ToString());
                    sqlCmd.ExecuteNonQuery();
                    GridView_Report_Clients.EditIndex = -1;
                    Clients_Click(sender, e);
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch(Exception ex) {
                Clients_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView_Report_Clients_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            {   //if Admin gona change "Admin" line.
                if(((GridView_Report_Clients.Rows[e.RowIndex].FindControl("id_ID") as System.Web.UI.WebControls.Label).Text.Trim()).Equals("000000000")) {
                    {
                        GridView_Report_Clients.EditIndex = -1;
                        Clients_Click(sender, e);
                    }
                    {
                        lblSuccessMessage.Text = "";
                        lblErrorMessage.Text = "Unable to Delete 'Admin' user";
                    }
                    return;
                }
            }
            try {
                using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    sqlCon.Open();
                    string query = "DELETE FROM [Clients] WHERE Id = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", GridView_Report_Clients.DataKeys[e.RowIndex].Value.ToString());
                    sqlCmd.ExecuteNonQuery();
                    Clients_Click(sender, e);
                    lblSuccessMessage.Text = "Selected Record Deleted successfully";
                    lblErrorMessage.Text = "";
                }
            }
            catch(Exception ex) {
                Clients_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }


        protected void Credit_Card_Click(object sender, EventArgs e) {
            {
                changeVisiableForGridView(GridView_Credit_Card, GridView_Report_Clients, GridView_Report_Event, GridView_Report_Cars, GridView_Report_Rental);
                changeColorForli(Credit_Card_link_ID, Clients_link_ID, Cars_link_ID, Rentals_link_ID, Event_link_ID);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = "";
            }
            DataTable dtbl = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Credit_card]", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if(dtbl.Rows.Count > 0) {
                GridView_Credit_Card.DataSource = dtbl;
                GridView_Credit_Card.DataBind();
            }
            else {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView_Credit_Card.DataSource = dtbl;
                GridView_Credit_Card.DataBind();
                GridView_Credit_Card.Rows[0].Cells.Clear();
                GridView_Credit_Card.Rows[0].Cells.Add(new TableCell());
                GridView_Credit_Card.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count + 1;
                GridView_Credit_Card.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView_Credit_Card.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void GridView_Credit_Card_RowCommand(object sender, GridViewCommandEventArgs e) {
            try {
                if(e.CommandName.Equals("AddNew")) {
                    {//check if "Credit card No." is only digit
                        string s = (GridView_Credit_Card.FooterRow.FindControl("txt_Credit_card_number_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim();
                        foreach(char temp in s) {
                            if(((temp-'0') <0) || ((temp-'0') >9)) {
                                Credit_Card_Click(sender, e);
                                lblSuccessMessage.Text = "";
                                lblErrorMessage.Text = "for Credit Card - insert only digits";
                                return;
                            }
                        }
                    }
                    {//Check if 'id' is an exist
                        string id_Check = (GridView_Credit_Card.FooterRow.FindControl("txt_ID_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim();
                        if(id_Check == "" || id_Check == null) {
                            Credit_Card_Click(sender, e);
                            lblSuccessMessage.Text = "";
                            lblErrorMessage.Text = "Wrong ID";
                            return;
                        }

                        if(((GridView_Credit_Card.FooterRow.FindControl("txt_ID_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim()).Equals("000000000")) {
                            Credit_Card_Click(sender, e);
                            lblSuccessMessage.Text = "";
                            lblErrorMessage.Text = "can not add credit card to 'Admin' user";
                            return;
                        }
                        
                        if(!(db.is_Id_Exists(id_Check))) {
                            Credit_Card_Click(sender, e);
                            lblSuccessMessage.Text = "";
                            lblErrorMessage.Text = "ID does not exist in a system";
                            return;
                        }
                    }
                    using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                        sqlCon.Open();
                        string query = "INSERT INTO [Credit_card] (ID,Credit_card_number,Validity_Month,Validity_Year,CVV) VALUES (@ID,@Credit_card_number,@Validity_Month,@Validity_Year,@CVV)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@ID", (GridView_Credit_Card.FooterRow.FindControl("txt_ID_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Credit_card_number", (GridView_Credit_Card.FooterRow.FindControl("txt_Credit_card_number_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Validity_Month", (GridView_Credit_Card.FooterRow.FindControl("txt_Validity_Month_Footer") as DropDownList).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Validity_Year", (GridView_Credit_Card.FooterRow.FindControl("txt_Validity_Year_Footer") as DropDownList).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@CVV", (GridView_Credit_Card.FooterRow.FindControl("txt_CVV_Footer") as System.Web.UI.WebControls.TextBox).Text.Trim());

                        sqlCmd.ExecuteNonQuery();
                        Credit_Card_Click(sender, e);
                        lblSuccessMessage.Text = "Credit card added successfully.";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch(Exception ex) {
                Credit_Card_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView_Credit_Card_RowEditing(object sender, GridViewEditEventArgs e) {
            GridView_Credit_Card.EditIndex = e.NewEditIndex;
            Credit_Card_Click(sender, e);
        }
        protected void GridView_Credit_Card_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            GridView_Credit_Card.EditIndex = -1;
            Credit_Card_Click(sender, e);
        }
        protected void GridView_Credit_Cards_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            try {
                using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    sqlCon.Open();

                    string query = "UPDATE [Credit_card] SET Credit_card_number=@Credit_card_number,Validity_Month=@Validity_Month,Validity_Year=@Validity_Year,CVV=@CVV WHERE Credit_card_number=@Credit_card_number";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@Validity_Month", (GridView_Credit_Card.Rows[e.RowIndex].FindControl("txt_Validity_Month") as DropDownList).SelectedItem.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Validity_Year", (GridView_Credit_Card.Rows[e.RowIndex].FindControl("txt_Validity_Year") as DropDownList).SelectedItem.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@CVV", (GridView_Credit_Card.Rows[e.RowIndex].FindControl("txt_CVV") as System.Web.UI.WebControls.TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Credit_card_number", GridView_Credit_Card.DataKeys[e.RowIndex].Value.ToString());

                    sqlCmd.ExecuteNonQuery();
                    GridView_Credit_Card.EditIndex = -1;
                    Credit_Card_Click(sender, e);
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch(Exception ex) {
                Credit_Card_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void GridView_Credit_Card_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            try {
                using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                    sqlCon.Open();
                    string query = "DELETE FROM [Credit_card] WHERE Credit_card_number = @Credit_card_number";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Credit_card_number", GridView_Credit_Card.DataKeys[e.RowIndex].Value.ToString());
                    sqlCmd.ExecuteNonQuery();
                    Credit_Card_Click(sender, e);
                    lblSuccessMessage.Text = "Selected Record Deleted successfully";
                    lblErrorMessage.Text = "";
                }
            }
            catch(Exception ex) {
                Credit_Card_Click(sender, e);
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void save_Click(object sender, EventArgs e) {
            bool flag = false;
            if(addressID.Text == "" || addressID.Text == null)
                flag=true;
            if(phoneID.Text == "" || phoneID.Text == null)
                flag=true;
            if(mailID.Text == "" || mailID.Text == null)
                flag=true;
            if(faxID.Text == "" || faxID.Text == null)
                flag=true;
            if(whatsappID.Text == "" || whatsappID.Text == null)
                flag=true;
            if(mapID.Text == "" || mapID.Text == null)
                flag=true;

            if(flag)
                return;

            if(db.isUpdateAddress(addressID.Text, mailID.Text, phoneID.Text, whatsappID.Text, faxID.Text, mapID.Text)) {
                Response.Write("<script>alert('Changes was successfully!')</script>");
                Response.Write("<script>window.location.href='Branches.aspx';</script>");
            }
            else
                Response.Write("<script>alert('wrong!')</script>");
        }
        
    }
}