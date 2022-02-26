using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FinalProject
{
    public class DB
    {
        private SqlConnection connect;
        private SqlCommand command;
        private string query;
        private SqlDataReader reader;
        public DB()
        {
            connect = new SqlConnection(@"Data Source=(LocalDB)\v11.00; AttachDbFilename=D:\DROPBOX\לימודים\הקריה ללימודי הנדסה וטכנולוגיה\שנה ב\דריו בוג'יו\פרוייקט גמר\FINALPROJECT\DB\DB.MDF; Integrated Security=True; Connect Timeout=30");
            //connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Dropbox\לימודים\הקריה ללימודי הנדסה וטכנולוגיה\שנה ב\דריו בוג'יו\פרוייקט גמר\FinalProject\DB\DB.mdf;Integrated Security=True;Connect Timeout=30");
        }

        //this metod return id value of last massege
        private int getNumOfMessage()
        {
            int i = 0;
            connect.Open();
            query = "SELECT * FROM [Message]";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
                if(i < (int)reader.GetSqlInt32(5))
                    i = (int)reader.GetSqlInt32(5);

            closeConnectAndReader();
            return ++i;
        }

        //this metod - get message from user to mail box DB
        public bool WriteMessageForSupport(string from, string email, string phone, string message)
        {
            int msgId = getNumOfMessage(); //find 'new ID' of this massege
            connect.Open();

            query = "insert into Message values ('" + from + "','" + email + "','" + phone + "','" + message + "','" + DateTime.Now + "')";
            command = new SqlCommand(query, connect);

            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch(SqlException exp)
            {
                /*
                 * Console.WriteLine(exp.ErrorCode);
                 * Console.WriteLine(exp.Errors);
                 */
                exp.ToString();

                connect.Close();
                return false;
            }
        }

        //load message from DB to web
        public StringBuilder load_Message_For_Admin()
        {
            connect.Open();
            query = "SELECT * FROM [Message]";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            StringBuilder table = new StringBuilder();

            while(reader.Read())
            {

                string from = reader.GetString(0);
                string mail = reader.GetString(1);
                string phone = reader.GetString(2);
                string massege = reader.GetString(3);
                string date = reader.GetString(4);
                string idMsg = reader.GetInt32(5).ToString();

                {   //create a new Message div 
                    table.Append("<div class='classMessage'><div class='namePhoneMsg'>");
                    table.Append("<div class='namePhone'><h1 class='className'>" + from + "</h1></div>");
                    table.Append("<div class='pDate'>");
                    table.Append("<p><font size='3'>" + massege + "</font></p>");
                    table.Append("<h4>" + date + "</h4></div></div>");
                    table.Append("<div class='closeMail'>");
                    //table.Append("<asp:ScriptManager ID='smMain' runat='server' EnablePageMethods='true' />");    
                    table.Append("<input id='Button1' type='button' value='x' onclick='delMsg(" + idMsg + ")'/>");
                    table.Append("<div class='classMail' title='Send an eMail'><a href='mailto:" + mail + "'>" + mail + "</a></div>");
                    table.Append("<h3 class='classPhone'>" + phone + "</h3></div></div>");
                }

            }
            closeConnectAndReader();
            return table;
        }

        //load Job Required from DB to web
        public StringBuilder loadJobCareersForUser()
        {
            int i = 0;
            int flag = 0; // in no career
            connect.Open();
            query = "SELECT * FROM [Careers]";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            StringBuilder table = new StringBuilder();

            while(reader.Read())
            {
                flag = 1;
                string title_Of_Job = reader.GetString(0);
                string details_Of_Jos = reader.GetString(1);
                string numJob = reader.GetString(2);

                //create a new job's div 
                table.Append("<div id='db" + i++ + "' title='Click on me' OnClick='render(" + Int32.Parse(numJob) + ")' class='divStyle'>");
                table.Append("<h2 class='titleStyle'>" + title_Of_Job + "</h2>");
                table.Append("<div class='detailsStyle'>");
                table.Append(details_Of_Jos);
                table.Append("</div>");
                table.Append("<div class='numStyle'>");
                table.Append("<b>Job num</b>: <u>" + numJob + "</u>");
                table.Append("</div>");
                table.Append("</div>");
            }
            if(flag == 0) //if no careers = show message 'no careers'.                
                table.Append("<h1 style='color: #ffffff; font-size: 100px; text-align: center;'>No careers for now. Try again another time </h1>");
            closeConnectAndReader();
            return table;
        }

        //return true if user+pwd exist
        public bool isSignIn(string user, string pwd)
        {
            connect.Open();
            query = "SELECT * FROM Clients WHERE UserName='" + user + "' AND Password='" + pwd + "'";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                connect.Close();
                reader.Close();
                return true;
            }
            closeConnectAndReader();
            return false;
        }
        private void closeConnectAndReader()
        {
            connect.Close();
            reader.Close();
        }

        //this method help to 'isCreateClient method' to find if ID alredy exist
        public bool isIdExists(string id) {
            //this method check if ID already Exists is a system
            connect.Open();
            query = "SELECT Id FROM Clients";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while(reader.Read()) {
                if(reader.GetString(0).CompareTo(id) == 0)
                    return true;
            }
            closeConnectAndReader();
            return false;
        }
        //returns 'yes' if the method could insert details of user
        public string isCreateClient(string id, string firstName, string lastName, string age, string address, string mail, string phone, string username, string password)
        {
            if(isIdExists(id))
                return "ID";

            /*// this 2 line - for create log-in time of user
            string temp = DateTime.Today.ToString().Substring(0, 10);
            string todayTmp = temp.Substring(3, 2) + "-" + temp.Substring(0, 2) + "-" + temp.Substring(6, 4);
            */

            connect.Open();
           
            query = "insert into Clients values ('" + id + "','" + firstName + "','" + lastName + "','" + age + "','" + address + "','" + mail + "','" + phone + "','" + username + "','" + password + "','" + ((DateTime.Now).ToString("dd-MM-yyyy")) + "')";
            command = new SqlCommand(query, connect);
            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return "good";
            }
            catch(SqlException exp)
            {
                /*
                 * Console.WriteLine(exp.ErrorCode);
                 * Console.WriteLine(exp.Errors);
                 */
                exp.ToString();

                connect.Close();
                return "bad";
            }
        }

        //this method help to find if license_plate alredy exist
        public bool is_license_plate_Exists(string license_plate) {
            //this method check if ID already Exists is a system
            connect.Open();
            query = "SELECT license_plate FROM Cars";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while(reader.Read()) 
            {
                if(reader.GetString(0).CompareTo(license_plate) == 0) 
                {
                    closeConnectAndReader();
                    return true;
                }
            }
            closeConnectAndReader();
            return false;
        }
        public bool is_Id_Exists(string id) {
            //this method check if ID already Exists is a system, with 'closeConnectAndReader' function if id find.
            connect.Open();
            query = "SELECT Id FROM Clients";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while(reader.Read()) 
            {
                if(reader.GetString(0).CompareTo(id) == 0) 
                {
                    closeConnectAndReader();
                    return true;
                }
            }
            closeConnectAndReader();
            return false;
        }

         //This is a method that deletes user messages in the admin area by the parameter it receives. 
        public void deleteMsg(string x)
        {
            //return true;
            connect.Open();
            query = "DELETE FROM Message WHERE Id=" + x;
            command = new SqlCommand(query, connect);
            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return;
            }
            catch(SqlException exp)
            {
                exp.ToString();
                connect.Close();
                return;
            }
        }
        public void delCareers(string id)
        {
            //return true;
            connect.Open();
            query = "DELETE FROM Careers WHERE Num=" + id;
            command = new SqlCommand(query, connect);
            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return;
            }
            catch(SqlException exp)
            {
                exp.ToString();
                connect.Close();
                return;
            }
        }
        public StringBuilder load_Careers_For_Admin()
        {
            connect.Open();
            query = "SELECT * FROM [Careers]";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            StringBuilder table = new StringBuilder();
            while(reader.Read())
            {
                string title_Of_Job = reader.GetString(0);
                string details_Of_Jos = reader.GetString(1);
                string id_of_Job = reader.GetString(2);

                {
                    table.Append("<div class='ClassJob' runat='server'>");
                    table.Append("<h1 id='TextBox_TitleJob'> " + title_Of_Job + "</h1>");
                    table.Append("<input id='del_button' type='button' value='X' onclick='delCareers(" + Int32.Parse(id_of_Job) + ")' runat='server' />");
                    table.Append("<p id='TextBox_Detailsjob'>" + details_Of_Jos + "</p>");
                    table.Append("<label id='num_career_id_label'> Num id: " + Int32.Parse(id_of_Job) + "</label>");
                    table.Append("</div>");
                }
            }
            closeConnectAndReader();
            return table;
        }
        private bool isNumCareersExists(string id)
        {
            //this method check if "career num" already Exists is a system
            connect.Open();
            query = "SELECT Num FROM Careers";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                if((Int32.Parse(reader.GetString(0))).CompareTo(Int32.Parse(id)) == 0)
                {
                    closeConnectAndReader();
                    return true;
                }
            }
            closeConnectAndReader();
            return false;
        }
        //this meth create careers for simulation and for AdminUser
        public bool WriteCareersForSupport(string title, string details)
        {
            //this past creat "rendom num" for careers table
            Random rand = new Random();
            int num;
            do
            {
                num = rand.Next(9999) + 1;
            } while(isNumCareersExists(num.ToString()));

            connect.Open();
            query = "insert into Careers values ('" + title + "','" + details + "','" + num + "')";
            command = new SqlCommand(query, connect);
            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch(SqlException exp)
            {
                /*
                 * Console.WriteLine(exp.ErrorCode);
                 * Console.WriteLine(exp.Errors);
                 */
                exp.ToString();

                connect.Close();
                return false;
            }
        }

        public StringBuilder load_deals_For_User()
        {
            int flag = 0; // in no career
            connect.Open();
            query = "SELECT * FROM [Deals]";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            StringBuilder table = new StringBuilder();

            while(reader.Read())
            {
                flag = 1;

                string title = reader.GetString(0);
                string details = reader.GetString(1);
                string date = reader["date"].ToString();
                string num = reader.GetString(3);

                //create a new job's div
                table.Append("<div class='allDiv' runat='server' title='Click on me' OnClick='render(" + Int32.Parse(num) + ")'>");
                table.Append("<h1><u>" + title + "</u></h1>");
                table.Append("<p style='text-align: center;'>" + details + "</p>");
                table.Append("<label style='color:red;'><u>validity:</u> <br>" + date.Substring(0, 10) + "</label>");
                table.Append("<br /></div>");
            }
            if(flag == 0) //if no careers = show message 'no careers'.                
                table.Append("<h1 style='color: #ffffff; font-size: 100px; text-align: center;'> No Deals for now. Try again later </h1>");
            closeConnectAndReader();
            return table;
        }
        public StringBuilder load_deals_For_Admin()
        {
            connect.Open();
            query = "SELECT * FROM [Deals]";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            StringBuilder table = new StringBuilder();

            while(reader.Read())
            {

                string title = reader.GetString(0);
                string details = reader.GetString(1);
                string date = reader["date"].ToString();
                string num = reader.GetString(3);

                //create a new job's div
                table.Append("<div class='allDiv' runat='server'>");
                table.Append("<h1><u>" + title + "</u></h1>");
                table.Append("<p style='text-align: center;'>" + details + "</p>");
                table.Append("<label style='color:red;'><u>validity:</u> <br>" + date.Substring(0, 10) + "</label>");
                table.Append("<br /><button style='width:40px; height:40px;'onclick='delDeal(" + Int32.Parse(num) + ")'>X</button>");
                table.Append("<br /> Deal No. " + Int32.Parse(num)+ "</div>");
            }
            closeConnectAndReader();
            return table;
        }


        private bool isNumDealExists(string id)
        {
            //this method check if "career num" already Exists is a system
            connect.Open();
            query = "SELECT numDeals FROM Deals";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                if((Int32.Parse(reader.GetString(0))).CompareTo(Int32.Parse(id)) == 0)
                {
                    closeConnectAndReader();
                    return true;
                }
            }
            closeConnectAndReader();
            return false;
        }
        public void createDeal(string title, string details, string dayValidity, string mountValidity, string yearValidity)
        {
            //this past creat "rendom num" for careers table
            string validity = mountValidity + "/" + dayValidity + "/" + yearValidity;
            Random rand = new Random();
            int num;
            do
            {
                num = rand.Next(9999) + 1;
            } while(isNumDealExists(num.ToString()));

            connect.Open();
            query = "insert into Deals values ('" + title + "','" + details + "','" + validity + "','" + num + "')";
            command = new SqlCommand(query, connect);
            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return;
            }
            catch(SqlException exp)
            {
                /*
                 * Console.WriteLine(exp.ErrorCode);
                 * Console.WriteLine(exp.Errors);
                 */
                exp.ToString();

                connect.Close();
                return;
            }
        }
        public void del_deal(string id)
        {
            //return true;
            connect.Open();
            query = "DELETE FROM Deals WHERE numDeals=" + id;
            command = new SqlCommand(query, connect);
            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return;
            }
            catch(SqlException exp)
            {
                exp.ToString();
                connect.Close();
                return;
            }
        }

        //this methot return license_plate list
        public StringBuilder load_Cars_For_Admin(string startDateOfUser, string endDateOfUser, bool isManual, bool idPriceUp)
        {
            int sumDays = (DateTime.Parse(endDateOfUser) - DateTime.Parse(startDateOfUser)).Days; //'sumDays' is The difference between the dates, the total days.
            DateTime startTmp, endTemp;
            StringBuilder table = new StringBuilder();

            //List<string>[] myData = new List<string>[3];

            List<string> carList = new List<string>();
            List<string> caRentaList = new List<string>();
            List<string> freeCarList = new List<string>();
            List<string> toBuild = new List<string>();

            {//this part create list of all the cars in a company.
                connect.Open();
                query = "SELECT license_plate FROM [Cars]";
                command = new SqlCommand(query, connect);
                reader = command.ExecuteReader();
                while(reader.Read())
                    if(!(carList.Contains(reader.GetString(0)))) // if the license_plate is not exist in a list->
                        carList.Add(reader.GetString(0));
                closeConnectAndReader();
            }

            {//this part create list of all the car in caRentaList
                connect.Open();
                query = "SELECT Cars.license_plate, Cars.Type, Cars.Color, Cars.Value_coefficient, Cars.ImagePath, Rentals.Start_Rental, Rentals.End_Rental FROM Cars INNER JOIN Rentals ON Cars.license_plate = Rentals.license_plate WHERE (Cars.ManualBox)='" + (isManual ? "yes" : "no") + "' ORDER BY Cars.license_plate, Rentals.Start_Rental";
                command = new SqlCommand(query, connect);
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if(!(caRentaList.Contains(reader.GetString(0))))
                        caRentaList.Add(reader.GetString(0)); // full list caRental
                }
                closeConnectAndReader();
            }

            foreach(string s in caRentaList)
            {//this part create list of 'free car' in caRentaList
                string license_plate_tmp = null;
                connect.Open();
                query = "SELECT Cars.license_plate, Cars.Type, Cars.Color, Cars.Value_coefficient, Cars.ImagePath, Rentals.Start_Rental, Rentals.End_Rental FROM Cars INNER JOIN Rentals ON Cars.license_plate = Rentals.license_plate WHERE (Cars.ManualBox)='" + (isManual ? "yes" : "no") + "' AND (Cars.license_plate)='" + s + "' ORDER BY Cars.license_plate, Rentals.Start_Rental";
                command = new SqlCommand(query, connect);
                reader = command.ExecuteReader();

                if(reader.Read())
                {

                    startTmp = DateTime.Parse(reader.GetDateTime(5).ToString("dd-MM-yyyy"));
                    endTemp = DateTime.Parse(reader.GetDateTime(6).ToString("dd-MM-yyyy"));

                    {//if the time is before 
                        if(DateTime.Compare(DateTime.Parse(endDateOfUser), startTmp) <= 0)
                            freeCarList.Add(reader.GetString(0)); //full list freeCar
                    }

                    while(reader.Read())
                    {
                        license_plate_tmp = reader.GetString(0);

                        if((DateTime.Compare(DateTime.Parse(startDateOfUser), endTemp) >= 0) && (DateTime.Compare(DateTime.Parse(endDateOfUser), DateTime.Parse(reader.GetDateTime(5).ToString("dd-MM-yyyy"))) <= 0))
                            if(!(freeCarList.Contains(reader.GetString(0)))) // if the license_plate is not exist in a list->
                                freeCarList.Add(reader.GetString(0));
                        
                        startTmp = DateTime.Parse(reader.GetDateTime(5).ToString("dd-MM-yyyy"));
                        endTemp = DateTime.Parse(reader.GetDateTime(6).ToString("dd-MM-yyyy"));
                    }

                    {//if the time of user is after the last rental
                        if(DateTime.Compare(DateTime.Parse(startDateOfUser), endTemp) >= 0)
                            if(!(freeCarList.Contains(license_plate_tmp)))
                                freeCarList.Add(license_plate_tmp);
                    }
                }
                closeConnectAndReader();
            }

            {//added to "toBuild" list the carList(whitout caRentaList) && freeCarList
                foreach(string licenseplateTmp in carList)
                    if(!(caRentaList.Contains(licenseplateTmp)))
                        toBuild.Add(licenseplateTmp);
                foreach(string licenseplateTmp in freeCarList)
                    toBuild.Add(licenseplateTmp);
            }


            {//creart car to user                  
                connect.Open();
                query = "SELECT Cars.license_plate, Cars.Type, Cars.Color, Cars.Value_coefficient, Cars.ImagePath FROM Cars WHERE (Cars.ManualBox)='" + (isManual ? "yes" : "no") + "' AND (Cars.Status)='Available' ORDER BY Cars.Value_coefficient " + (idPriceUp ? " " : "DESC");
                command = new SqlCommand(query, connect);
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    if(toBuild.Contains(reader.GetString(0)))
                    {
                        string license = reader.GetString(0);
                        string type = reader.GetString(1);
                        string color = reader.GetString(2);
                        string price = (((double)reader.GetValue(3)) * sumDays * 9.12).ToString("F0"); // X.FF
                        string src = reader.GetString(4);

                        {//create a new car div 
                            table.Append("<div id='car_Div' style='z-index: -3; display:inline-block; '>");
                            table.Append("<img id='car_ImageButton' src='Image/Cars/" + src + "' style='z-index: -3;' />");
                            table.Append("<p id='typeIP' style='margin-top: 20px;'><u>Type</u>: " + type + "</p>");
                            table.Append("<p id='colorID'><u>Color</u>: " + color + "</p>");
                            table.Append("<p id='priceID' style='width: 100%; color: red;'><u>Price</u>: " + price + "$</p>");
                            table.Append("<button id='Select_Car' style='width: 100px; margin-left: 30%;' OnClick=\"Selected_car('" + license + "','" + startDateOfUser + "','" + endDateOfUser + "','" + price + "')\">Select</button>"); //there is " ' " char and "\" char for 'license' that contain '-' operation
                            table.Append("</div>");
                        }
                    }
                }
                closeConnectAndReader();

                return table;
            }
        }
        private string returnIDbyUserName(string userName)
        {//get ID by userName from Clients table
            
            string idTmp;
            connect.Open();
            query = "SELECT Id FROM Clients WHERE (Clients.UserName)='" + userName + "'";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            reader.Read();
            idTmp = reader.GetString(0);

            closeConnectAndReader();

            return idTmp;
        }

        public DataTable load_orderHistory_for_user(string userName)
        {
            string idTmp = returnIDbyUserName(userName);

            DataTable table = new DataTable();
            DataRow row = table.NewRow();

            {// create title to table
                table.Columns.Add("No. Invitations");
                table.Columns.Add("License plate");
                table.Columns.Add("Start Rental");
                table.Columns.Add("End Rental");
                table.Columns.Add("Price");
                table.Columns.Add("Order Date");
            }

            {//load base data table
                connect.Open();
                query = "SELECT * FROM Rentals WHERE Rentals.Id = '" + idTmp + "' ORDER BY Rentals.Start_Rental";
                command = new SqlCommand(query, connect);
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    int Num_Invitations = reader.GetInt32(0);
                    string license_plate = reader.GetString(2);
                    string Start_Rental = reader.GetDateTime(3).ToString("dd-MM-yyyy");
                    string End_Rental = reader.GetDateTime(4).ToString("dd-MM-yyyy");
                    int price = reader.GetInt32(5);
                    string Order_Date = (reader.GetDateTime(6).ToString("dd-MM-yyyy"));

                    {//every invitations
                        row = table.NewRow();
                        
                        row["No. Invitations"] = Num_Invitations.ToString();
                        row["license plate"] = license_plate;
                        row["Start Rental"] = Start_Rental;
                        row["End Rental"] = End_Rental;
                        row["Price"] = price + " $";
                        row["Order Date"] = Order_Date;

                        table.Rows.Add(row);
                    }
                }
            }

            closeConnectAndReader();
            return table;
        }
        public bool create_Message_to_Admin_From_User_exist(string userName, string message)
        {//if user want to delete him account..
            string idTmp = returnIDbyUserName(userName);
            int msgId = getNumOfMessage(); //find 'new ID' of this massege
            connect.Open();
            query = "insert into Message values ('" + userName + "',' ',' ','" + message + "','" + DateTime.Now + "')";
            command = new SqlCommand(query, connect);
            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch(SqlException exp)
            {
                /*
                 * Console.WriteLine(exp.ErrorCode);
                 * Console.WriteLine(exp.Errors);
                 */
                exp.ToString();

                connect.Close();
                return false;
            }
        }

        public bool is_Create_Rental_Line(string userName, string license_Plate, string startDate, string endDate, string price)
        {
            string id = returnIDbyUserName(userName);
            connect.Open();


            string query = "INSERT INTO [Rentals] (id,license_plate,Start_Rental,End_Rental,Price,OrderDate) VALUES (@id,@license_plate,@Start_Rental,@End_Rental," + price + ",@OrderDate)";
            SqlCommand sqlCmd = new SqlCommand(query, connect);
            sqlCmd.Parameters.AddWithValue("@id", id.Trim());
            sqlCmd.Parameters.AddWithValue("@license_plate", license_Plate.Trim());
            sqlCmd.Parameters.AddWithValue("@Start_Rental", DateTime.Parse(startDate.Trim()));
            sqlCmd.Parameters.AddWithValue("@End_Rental", DateTime.Parse(endDate.Trim()));
            sqlCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);

            try {
                sqlCmd.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch(SqlException exp) {
                exp.ToString();
                connect.Close();
                return false;
            }
        }
        public bool is_create_credit_card(string userName, string credit_card, string validity_Year, string validity_Mount , string cvv) 
        {
            string id = returnIDbyUserName(userName);
            connect.Open();
            query = "insert into [Credit_card] values ('" + id + "','" + credit_card + "','" + validity_Year + "','" + validity_Mount + "','" + cvv + "')";
            command = new SqlCommand(query, connect);

            try
            {
                command.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch(SqlException exp)
            {                
                exp.ToString();
                connect.Close();
                return false;
            }            
        }
        public string[] loadAddress()
        {            
            string[] details = new string[6];
            
            connect.Open();
            query = "SELECT * FROM Branches";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            reader.Read();

            for(int i=0; i<=5; i++)
                details[i] = reader.GetString(i);

            closeConnectAndReader();

            return details;
        }
        public bool isUpdateAddress(string address, string mail, string phone, string whatsapp, string fax, string map)
        {
            connect.Open();
            string query = "UPDATE [Branches] SET Address='" + address.Trim() +"', phone='" + phone.Trim() + "', mail='" + mail.Trim() + "', fax='" + fax.Trim() + "', WhatsApp='" + whatsapp.Trim() + "', mapAddress='"+ map.Trim() +"' WHERE id = '"+3+"'";
            command =new SqlCommand(query, connect);
                        
            try {
                command.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch(Exception exp) //catch(SqlException exp)
            {
                exp.ToString();
                connect.Close();
                return false;
            }
        }
    }
}