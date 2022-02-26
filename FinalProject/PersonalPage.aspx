<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalPage.aspx.cs" Inherits="FinalProject.PersonalPage" %>

<!DOCTYPE html> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <title>PersonalPage</title>
    <meta charset="utf-8" />
    <link href="StyleSheet/PersonalPage_StyleSheet.css" rel="stylesheet" />
    <link href="StyleSheet/General_StyleSheet.css" rel="stylesheet" />
    <link rel="icon" href="Image/Porsche.png" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <asp:LinkButton ID="idHelloUser" href="Admin.aspx" class="navbar-brand page-scroll" runat="server">Hello User</asp:LinkButton>
                    <asp:Label class="navbar-brand page-scroll" runat="server">/</asp:Label>
                    <asp:LinkButton ID="idSignOut" class="navbar-brand page-scroll" runat="server" OnClick="SingOut_Click">Sign Out</asp:LinkButton>
                </div>
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a class="page-scroll" href="CaRental.aspx">Home</a></li>
                        <li><a class="page-scroll" href="Deals.aspx">Deals</a></li>
                        <li><a class="page-scroll" href="Branches.aspx">Branches</a></li>
                        <li><a class="page-scroll" href="Career.aspx">Career</a></li>
                        <li><a class="page-scroll" href="Contact.aspx">Contact</a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="all" runat="server">
            <div class="divMain" runat="server">
                <asp:Button ID="carBookingButtonID" class="Button-class" runat="server" Text="Car booking" OnClick="CarBooking_click" />
                <asp:Button ID="orderHhistoryButtonID" class="Button-class" runat="server" Text="Order history" OnClick="OrderHistory_click" />
                <asp:Button ID="SettingsButtonID" class="Button-class" runat="server" Text="Settings" OnClick="Settings_click" />
            </div>

            <div class="divSecond" runat="server">

                <asp:Panel ID="Panel_CarBookingID" runat="server">
                    <div id="divDate_ID" style="z-index: 3; position: sticky; top: 5px;">
                        <div id="div_Start_ID" style="z-index: 3;">
                            <asp:TextBox ID="TextBox_Start_ID" runat="server" ReadOnly="true">01-01-2021</asp:TextBox>
                            <asp:ImageButton ID="ImageButton_Start_ID" runat="server" Height="20px" ImageUrl="~/Image/calendar.jpg" OnClick="ImageButton_Start_Click" />
                            <asp:Calendar ID="Calendar_Start_ID" runat="server" OnSelectionChanged="Calendar_Start_SelectionChanged" Visible="False" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                        </div>
                        <div id="div_End_ID" style="z-index: 3;">
                            <asp:TextBox ID="TextBox_End_ID" runat="server" ReadOnly="true">05-01-2021</asp:TextBox>
                            <asp:ImageButton ID="ImageButton_End_ID" runat="server" Height="20px" ImageUrl="~/Image/calendar.jpg" OnClick="ImageButton_End_Click" />
                            <asp:Calendar ID="Calendar_End_ID" runat="server" OnSelectionChanged="Calendar_End_SelectionChanged" Visible="False" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            </asp:Calendar>
                        </div>
                        <asp:CheckBox ID="ManualBox_ID" runat="server" Checked="true" Text="Manual Box" />
                                                
                            <div style="display: inline-block; border: 1px solid #808080; padding: 5px;">                              
                                    <asp:RadioButton ID="priceID_up" runat="server" GroupName="price" Checked="true" Text="Price up" />
                                    <asp:RadioButton ID="priceID_down" runat="server" GroupName="price" Text="Price down" />
                            </div>

                        <asp:Button ID="Search_ID" runat="server" Text="Search" OnClick="Search_ID_Click" />
                    </div>

                    <%--<div id="car_Div" style="z-index: -3; display:inline-block;">
                        <img id="car_ImageButton" src="Image/Cars/RollsRoyce.jpg" style="z-index: -3;" />
                        <p id="typeIP" style="margin-top: 20px;"><u>Type</u>: Cadillac 2006</p>
                        <p id="colorID"><u>Color</u>: Black</p>
                        <p id="priceID" style="width: 100%; color: red;"><u>Price</u>: 96$</p>
                        <button id="Select_Car" style="width: 100px; margin-left: 30%;" onclick="Selected_car(22-222-22)">Select</button>
                    </div>--%>

                    <!--this placeHolder show Car from DB to web for Rental -->
                    <asp:PlaceHolder ID="PlaceHolder_Car" runat="server"></asp:PlaceHolder>

                </asp:Panel>

                <asp:Panel ID="Panel_orderHistoryID" runat="server">
                    <asp:GridView ID="GridView_orderHistoryID" runat="server" Height="500px" Width="900px" BackColor="White"
                        BorderColor="#999999" BorderStyle="Groove" BorderWidth="1px" CellPadding="4"  >

                        <AlternatingRowStyle BackColor="#DCDCDC"  HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black"  />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White"  />

                    </asp:GridView>
                </asp:Panel>               

                <asp:Panel ID="Panel_settingID" runat="server">                    
                        <button class="wanTo" onclick="changeFN()">Change My First Name</button>
                        <button class="wanTo" onclick="changeLN()">Change My Last Name</button>
                        <button class="wanTo" onclick="changeAdrs()">Change My Address</button>
                        <button class="wanTo" onclick="changeEmail()">Change My eMail</button>
                        <button class="wanTo" onclick="changePhoneNumber()">Change My Phone number</button>
                        <button class="wanTo" onclick="changeUsername()">Change My User Name</button>
                        <button class="wanTo" onclick="changePassword()">Change My Password</button>
                        <button class="wanTo" onclick="delMyAccount()" id="delMYaccount">Delete Account</button>
                </asp:Panel>
                
                <!--do no delete that, it's make able connection between c# methods and JavaScript-->
                <asp:ScriptManager ID="smMain" runat="server" EnablePageMethods="true" />

                <script type="text/javascript">

                    function Selected_car(license_Plate, startDate, endDate, price) {
                        PageMethods.create_Rental(license_Plate, startDate, endDate, price, OnSucceeded);
                        function OnSucceeded(response) {
                            if (response) {
                                var myWindow = window.open("Payment_Page.aspx", "MsgWindow", "width=550,height=600");
                                window.location.href = 'PersonalPage.aspx';                                
                            }
                            else
                                alert("wrong!");
                        }
                    }
                    function changeFN() {
                        var tmp = prompt("what is it your new First Name?");
                        if ((!(tmp == null)) && (!(tmp == "")))
                            PageMethods.change_First_Name(tmp);
                    }
                    function changeLN() {
                        var tmp = prompt("what is it your new Last Name?");
                        if ((!(tmp == null)) && (!(tmp == "")))
                            PageMethods.change_Last_Name(tmp);
                    }
                    function changeAdrs() {
                        var tmp = prompt("what is it your new Address?");
                        if ((!(tmp == null)) && (!(tmp == "")))
                            PageMethods.change_Address(tmp);
                    }
                    function changeEmail() {
                        var tmp = prompt("what is it your new eMail?");
                        if ((!(tmp == null)) && (!(tmp == "")))
                            PageMethods.change_Email(tmp);
                    }
                    function changePhoneNumber() {
                        var tmp = prompt("what is it your new Phone number?");
                        if ((!(tmp == null)) && (!(tmp == "")))
                            PageMethods.change_Phone_Number(tmp);
                    }
                    function changeUsername() {
                        var tmp = prompt("what is it your new UserName?");
                        if ((!(tmp == null)) && (!(tmp == "")))
                            PageMethods.change_User_Name(tmp);
                    }
                    function changePassword() {
                        var tmp = prompt("what is it your new Password?");
                        if ((!(tmp == null)) && (!(tmp == "")))
                            PageMethods.change_Password(tmp);
                    }
                    function delMyAccount() {
                        if (confirm('Are you sure you want to Delete your Account?'))
                            PageMethods.delete_Account("yes");
                    }
                    
                </script>
            </div>
        </div>
    </form>
</body>
</html>
