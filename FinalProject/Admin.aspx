<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FinalProject.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title> 
    <meta charset="utf-8" />
    <link href="StyleSheet/Admin_StyleSheet.css" rel="stylesheet" />
    <link href="StyleSheet/General_StyleSheet.css" rel="stylesheet" />
    <link rel="icon" href="Image/Porsche.png" />    
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <asp:LinkButton ID="idHelloAdmin" href="Admin.aspx" class="navbar-brand page-scroll" runat="server">Hello Admin</asp:LinkButton>
                    <asp:Label ID="Label1" class="navbar-brand page-scroll" runat="server">/</asp:Label>
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
        <div class="classAdmin">
            <h2 class="classAdminH2">Admin Control</h2>
        </div>

        <div class="all" runat="server">

            <div class="divMain" id="ddd" runat="server">
                <asp:Button ID="reportButtonId" runat="server" Text="Tables" OnClick="Show_Report_Click" formnovalidate="formnovalidate" />
                <asp:Button ID="CareersButtonId" runat="server" Text="Careers" OnClick="Show_Careers_Click" formnovalidate="formnovalidate" />
                <asp:Button ID="dealsButtonId" runat="server" Text="Deals" OnClick="Show_Deals_Click" formnovalidate="formnovalidate" />
                <asp:Button ID="myMessagesButtonId" runat="server" Text="Messages" OnClick="Show_Message_Click" formnovalidate="formnovalidate" />
                <asp:Button ID="addressDetailsButtonId" runat="server" Text="Branches Address" OnClick="Show_addressDetails_Click" formnovalidate="formnovalidate" />
                
                <asp:Button ID="fullMessagesButtonId" runat="server" Text="Full Messages" OnClick="Full_Messages_For_DB" formnovalidate="formnovalidate"/>
                <asp:Button ID="fullCareersButtonId" runat="server" Text="Full careers" OnClick="Full_Careers_For_DB" formnovalidate="formnovalidate"/>
                <asp:Button ID="fuulDealsButtonId" runat="server" Text="Full Deal" OnClick="Full_Deal_For_DB" formnovalidate="formnovalidate"/>
            </div>

            <div id="MassegeBoxId" class="divSecond" runat="server">
                
                <!--do no delete that, it's make able connection between c# methods and JavaScript-->
                <asp:ScriptManager ID="smMain" runat="server" EnablePageMethods="true" />

                <!--this placeHolder get message from DB to web-->
                <asp:PlaceHolder ID="PlaceHolder_Message" runat="server"></asp:PlaceHolder>
                
                <!--this placeHolder get message from Message to web-->
                <asp:PlaceHolder ID="PlaceHolder_Careers" runat="server"></asp:PlaceHolder>
                <!-- add new job button -->
                <div id="addJobId" class="ClassJob" runat="server" onclick="addJob()">+</div>


                <!--this placeHolder get deal from DB-->
                <asp:PlaceHolder ID="PlaceHolder_Deal" runat="server"></asp:PlaceHolder>
                <!-- add new deal -->
                <div id="addDealId" class="classDeal" runat="server" onclick="addDeal()">+</div>

                <asp:PlaceHolder ID="PlaceHolder_Report" runat="server">
                    <div style="float: left; padding:5px; margin-left: 10px; width: 160px; height: 100px; overflow: auto; z-index: 2; position: sticky; top: 0;">
                        <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
                        <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                    </div>
                    <div style="width: 90%; margin-left: auto; padding: 10px; margin-right: auto; position: sticky; top: 0; z-index: 1;">

                        <ul class="navi">
                            <li><asp:LinkButton class="nav_il" ID="Rentals_link_ID" runat="server" OnClick="Rental_Click">Rentals</asp:LinkButton></li>
                            <li><asp:LinkButton class="nav_il" ID="Cars_link_ID" runat="server" OnClick="Cars_Click">Cars</asp:LinkButton></li>
                            <li><asp:LinkButton class="nav_il" ID="Event_link_ID" runat="server" OnClick="Event_Click">Events</asp:LinkButton></li>
                            <li><asp:LinkButton class="nav_il" ID="Clients_link_ID" runat="server" OnClick="Clients_Click">Clients</asp:LinkButton></li>
                            <li><asp:LinkButton class="nav_il" ID="Credit_Card_link_ID" runat="server" OnClick="Credit_Card_Click">Cards</asp:LinkButton></li>
                        </ul>
                    </div>                   

                    <div style="margin: 10px;">

                        
                        <%-- gridView_Rental --%>
                                                
                        <asp:GridView ID="GridView_Report_Rental" runat="server" Width="75%" AutoGenerateColumns="false" DataKeyNames="Num_Invitations"
                            BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" ShowFooter="true" RowStyle-HorizontalAlign="Center"
                            OnRowCommand="GridView_Report_Rental_RowCommand" OnRowDeleting="GridView_Report_Rental_RowDeleting">
                         
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" font-size="Larger"/>
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

                            <Columns>

                                <asp:TemplateField HeaderText="No. Invitations" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Num_Invitations") %>' runat="server" Width="100px"/>
                                    </ItemTemplate>
                                    <FooterTemplate >
                                        <asp:Label ID="txt_Num_Invitations_Footer" runat="server" required="required" Width="100px"/>
                                    </FooterTemplate>
                                </asp:TemplateField >

                                <asp:TemplateField HeaderText="Id">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Id") %>' runat="server" Width="100px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Id_Footer" runat="server" pattern="[0-9]{9}" ToolTip="ID By 9 digit" required="required" Width="100px"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="license plate">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("license_plate") %>' runat="server" Width="120px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_license_plate_Footer" runat="server" required="required"  placeholder="XX-XXX-XX" pattern="[0-9]{2}-[0-9]{3}-[0-9]{2}" ToolTip="Format: XX-XXX-XX" Width="120px"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Start Rental">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Start_Rental") %>' runat="server" Width="150px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Start_Rental_Footer" placeholder="dd-MM-yyyy" runat="server" required="required" Width="150px"/>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="End Rental">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("End_Rental") %>' runat="server" Width="150px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_End_Rental_Footer" placeholder="dd-MM-yyyy" runat="server" required="required" Width="150px"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Price ($)">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Price")%>' runat="server" Width="100px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Price_Footer" runat="server" required="required" Width="100px"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Order Date">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("OrderDate") %>' runat="server" Width="150px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_OrderDate_Footer" runat="server" placeholder="dd-MM-yyyy" required="required" Width="150px"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="25px" Height="25px" formnovalidate="formnovalidate" OnClientClick="return confirm('Are you sure remove this line?')"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New"  Width="25px" Height="25px" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>




                        <%-- gridView_Cars --%>
                       
                        <asp:GridView ID="GridView_Report_Cars" runat="server"  Width="75%" AutoGenerateColumns="false" DataKeyNames="license_plate"
                            BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" ShowFooter="true" RowStyle-HorizontalAlign="Center" 
                            OnRowCommand="GridView_Report_Cars_RowCommand" OnRowDeleting="GridView_Report_Cars_RowDeleting" OnRowEditing="GridView_Report_Cars_RowEditing"
                            OnRowCancelingEdit="GridView_Report_Cars_RowCancelingEdit" OnRowUpdating="GridView_Report_Cars_RowUpdating" >
                        
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" font-size="Medium"/>
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center"/>
                            <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
                            
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

                            <Columns>

                                <asp:TemplateField HeaderText="license plate" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("license_plate") %>' runat="server"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txt_license_plate" Text='<%# Eval("license_plate") %>' runat="server" required="required" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_license_plate_Footer"  Width="100px" runat="server"  placeholder="XX-XXX-XX" required="required" pattern="[0-9]{2}-[0-9]{3}-[0-9]{2}" ToolTip="Format: XX-XXX-XX"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Type") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txt_Type" Text='<%# Eval("Type") %>' runat="server" Width="100px" required="required"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Type_Footer" runat="server" Width="100px" required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Year" >
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Year") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txt_Year" Text='<%# Eval("Year") %>' runat="server" Width="60px"  required="required"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Year_Footer" runat="server" Width="60px" pattern="[1-2]{1}[0-9]{3}" ToolTip="Format: 1,XXX or 2,XXX" required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Color" >
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Color") %>' runat="server"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_Color" Text='<%# Eval("Color") %>' runat="server" Width="100px" required="required"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Color_Footer" runat="server" Width="100px" required="required"/> 
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Miles">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Miles") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_Miles" Text='<%# Eval("Miles") %>' runat="server" Width="100px" required="required"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Miles_Footer" runat="server" Width="100px" required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Status") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>                                        
                                        <asp:DropDownList ID="txt_Status" runat="server" AutoPostBack="false" Width="70px" Height="24px">
                                            <asp:ListItem Text="Busy" />
                                            <asp:ListItem Text="Available" />
                                        </asp:DropDownList>
                                        <%--<asp:TextBox ID="txt_Status" Text='<%# Eval("Status") %>' runat="server" Width="70px" required="required"/>--%>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="txt_Status_Footer" runat="server" AutoPostBack="false" Width="90px" Height="24px">
                                            <asp:ListItem Text="Available"  />
                                            <asp:ListItem Text="Busy"/>
                                        </asp:DropDownList>
                                        <%--<asp:TextBox ID="txt_Status_Footer" runat="server" Width="70px" />--%>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Manual Box">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("ManualBox") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txt_ManualBox" Text='<%# Eval("ManualBox") %>' runat="server" Width="110px"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="txt_ManualBox_Footer" runat="server" AutoPostBack="false" Width="110px" Height="24px">
                                            <asp:ListItem Text="yes"  />
                                            <asp:ListItem Text="no"/>
                                        </asp:DropDownList>
                                        <%--<asp:TextBox ID="txt_ManualBox_Footer" runat="server" />--%>
                                    </FooterTemplate>
                                </asp:TemplateField>                              

                                <asp:TemplateField HeaderText="Value coefficient">
                                    <ItemTemplate>             
                                        <asp:Label Text='<%# Eval("Value_coefficient") %>' runat="server"  Width="120px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_Value_coefficient" Text='<%# Eval("Value_coefficient") %>' runat="server" Width="130px" required="required"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Value_coefficient_Footer" runat="server" Width="130px" required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Image Path">
                                    <ItemTemplate>
                                        <img id="myImg" src="Image/Cars/<%# Eval("ImagePath") %>" onclick="showImg('<%# Eval("ImagePath") %>')" style="float:left; Width:35px; height:23px; border: 1px solid black; margin-left: 7px;"/>                                        
                                        <div id="myModal" class="modal" onclick="closeShowImg()" >
                                            <img style="border: 5px solid blue;" class="modal-content" src="Image/GridView/img.png" id="img01">
                                            <div id="caption"></div>
                                        </div>
                                        <asp:Label Text='<%# Eval("ImagePath") %>' runat="server" /> </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:FileUpload ID="txt_ImagePath" ToolTip="non" runat="server" Width="180px" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:FileUpload ID="txt_ImagePath_Footer" runat="server" Width="180px" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="#" ItemStyle-Wrap="false" ControlStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" formnovalidate="formnovalidate"/>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Height="25px" formnovalidate="formnovalidate" OnClientClick="return confirm('Are you sure remove this Car?')"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" formnovalidate="formnovalidate"/>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" formnovalidate="formnovalidate"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                        
                        <%-- gridView_Event --%>

                        <asp:GridView ID="GridView_Report_Event" runat="server" Width="75%" AutoGenerateColumns="false" DataKeyNames="Num_Event"
                            BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" ShowFooter="true" RowStyle-HorizontalAlign="Center"
                            OnRowCommand="GridView_Report_Event_RowCommand" OnRowDeleting="GridView_Report_Event_RowDeleting">
                            
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" font-size="Larger"/>
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

                            <Columns>

                                <asp:TemplateField HeaderText="No. Event" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Num_Event") %>' runat="server"  />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="txt_Num_Event_Footer" runat="server" Width="100px" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Person Id">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Id") %>' runat="server" Width="100px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Id_Footer" runat="server" Width="100px"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Date") %>' runat="server" />
                                    </ItemTemplate>
                                    <FooterTemplate>                                       
                                        <asp:TextBox ID="txt_Date_Footer" runat="server" placeholder="dd-MM-yyyy" required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="license plate">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("license_plate") %>' runat="server" Width="150px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_license_plate_Footer" runat="server" placeholder="XX-XXX-XX" pattern="[0-9]{2}-[0-9]{3}-[0-9]{2}" ToolTip="Format: XX-XXX-XX" Width="150px" required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Type_Event") %>' runat="server" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="txt_Type_Event_Footer" runat="server" AutoPostBack="false" Width="200px" Height="24px">
                                            <asp:ListItem Text="Change color for car" />
                                            <asp:ListItem Text="Accident" />
                                            <asp:ListItem Text="Report - Police" />
                                            <asp:ListItem Text="Report - Parking" />
                                            <asp:ListItem Text="Report - Speed Trap" />
                                            <asp:ListItem Text="Report - Red light" />
                                            <asp:ListItem Text="Report - Other" />
                                            <asp:ListItem Text="Vehicle treatment" />
                                            <asp:ListItem Text="Garage care" />
                                            <asp:ListItem Text="Toll - Car license" />
                                            <asp:ListItem Text="Toll - The Carmel Tunnels" />
                                            <asp:ListItem Text="Toll - Road 6" />
                                            <asp:ListItem Text="Toll - Car towing" />
                                            <asp:ListItem Text="Toll - Other" />
                                            <asp:ListItem Text="Car Sale" />
                                            <asp:ListItem Text="Buying a car" />
                                        </asp:DropDownList>
                                        <%--<asp:TextBox ID="txt_Type_Event_Footer" runat="server" />--%>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Price") %> ' runat="server" Width="50px"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Price_Footer" runat="server" Width="80px"  required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField >

                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="25px" Height="25px" OnClientClick="return confirm('Are you sure remove this Event?')" formnovalidate="formnovalidate"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="25px" Height="25px"/>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>




                        <%-- gridView_Clients --%>

                        <asp:GridView ID="GridView_Report_Clients" runat="server" Width="75%" AutoGenerateColumns="false" DataKeyNames="Id"
                            BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" ShowFooter="true" RowStyle-HorizontalAlign="Center"
                            OnRowEditing="GridView_Report_Clients_RowEditing" OnRowCancelingEdit="GridView_Report_Clients_RowCancelingEdit"
                            OnRowUpdating="GridView_Report_Clients_RowUpdating" OnRowDeleting="GridView_Report_Clients_RowDeleting">
                            
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"/>
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" font-size="Larger"/>
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

                            <Columns>

                                <asp:TemplateField HeaderText="Id" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="id_ID" Text='<%# Eval("Id") %>' runat="server"  Width="100px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:label ID="txt_Id" Text='<%# Eval("Id") %>' runat="server" Width="100px" pattern="[0-9]{9}" ToolTip="ID By 9 digit"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("First_Name") %>' runat="server" Width="100px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_First_Name" Text='<%# Eval("First_Name") %>' runat="server" Width="100px"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Last_Name") %>' runat="server"  Width="100px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_Last_Name" Text='<%# Eval("Last_Name") %>' runat="server" Width="100px" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Age">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Age") %>' runat="server" Width="100px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:label ID="txt_Age" Text='<%# Eval("Age") %>' runat="server" Width="100px"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Address") %>' runat="server"  Width="90px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_Address" Text='<%# Eval("Address") %>' runat="server" Width="90px" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Mail">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Mail") %>' runat="server" Width="140px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_Mail" Text='<%# Eval("Mail") %> ' runat="server" Width="140px" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Phone">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Phone") %>' runat="server" Width="120px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_Phone" Text='<%# Eval("Phone") %> ' runat="server" Width="120px"  />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UserName">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("UserName") %>' runat="server" Width="100px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_UserName" Text='<%# Eval("UserName") %> ' runat="server" Width="100px" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Password">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Password") %>' runat="server"  Width="100px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_Password" Text='<%# Eval("Password") %> ' runat="server" Width="100px" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Join Date">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Join_Date") %>' runat="server" Width="100px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:label ID="txt_Join_Date" Text='<%# Eval("Join_Date") %>' runat="server" Width="100px"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="#" ItemStyle-Wrap="false" ControlStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" formnovalidate="formnovalidate"/>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Height="25px" OnClientClick="return confirm('Are you sure remove this Client?')" formnovalidate="formnovalidate"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" formnovalidate="formnovalidate"/>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" formnovalidate="formnovalidate"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>




                 <%-- gridView_Credit_Card --%>
                       


                        <asp:GridView ID="GridView_Credit_Card" Width="75%" runat="server" AutoGenerateColumns="false" DataKeyNames="Credit_card_number"
                            BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" ShowFooter="true" RowStyle-HorizontalAlign="Center"
                            OnRowCommand="GridView_Credit_Card_RowCommand" OnRowDeleting="GridView_Credit_Card_RowDeleting" OnRowEditing="GridView_Credit_Card_RowEditing"
                            OnRowCancelingEdit="GridView_Credit_Card_RowCancelingEdit" OnRowUpdating="GridView_Credit_Cards_RowUpdating">

                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"  HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" Font-Size="Larger" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

                            <Columns>

                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("ID") %>' runat="server" Width="120px" pattern="[0-9]{9}" ToolTip="ID By 9 digit"/>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_ID_Footer"  Width="120px" runat="server" required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Credit card No." ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Credit_card_number") %>' runat="server" Width="300px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txt_Credit_card_numbe" Text='<%# Eval("Credit_card_number") %>' runat="server" Width="300px" required="required"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_Credit_card_number_Footer" runat="server" Width="300px" required="required"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Validity Month" >
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Validity_Month") %>' runat="server" Width="120px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                       <asp:DropDownList ID="txt_Validity_Month" runat="server" AutoPostBack="false" Width="120px" Height="25px">
                                            <asp:ListItem Text="January" />
                                            <asp:ListItem Text="February" />
                                            <asp:ListItem Text="March" />
                                            <asp:ListItem Text="April" />
                                            <asp:ListItem Text="May" />
                                            <asp:ListItem Text="June" />
                                            <asp:ListItem Text="July" />
                                            <asp:ListItem Text="August" />
                                            <asp:ListItem Text="September" />
                                            <asp:ListItem Text="October" />
                                            <asp:ListItem Text="November" />
                                            <asp:ListItem Text="December" />
                                        </asp:DropDownList>
                                        
                                         <%--<asp:TextBox ID="txt_Validity_Month" Text='<%# Eval("Validity_Month") %>' runat="server" Width="120px" required="required"/>--%>
                                    </EditItemTemplate>
                                     <FooterTemplate>                                         
                                        <asp:DropDownList ID="txt_Validity_Month_Footer" runat="server" AutoPostBack="false" Width="120px" Height="25px">
                                            <asp:ListItem Text="January" />
                                            <asp:ListItem Text="February" />
                                            <asp:ListItem Text="March" />
                                            <asp:ListItem Text="April" />
                                            <asp:ListItem Text="May" />
                                            <asp:ListItem Text="June" />
                                            <asp:ListItem Text="July" />
                                            <asp:ListItem Text="August" />
                                            <asp:ListItem Text="September" />
                                            <asp:ListItem Text="October" />
                                            <asp:ListItem Text="November" />
                                            <asp:ListItem Text="December" />
                                        </asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Validity Year" >
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Validity_Year") %>' runat="server" Width="120px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="txt_Validity_Year" runat="server" AutoPostBack="false" Width="120px" Height="25px">
                                            <asp:ListItem Text="2020" />
                                            <asp:ListItem Text="2021" />
                                            <asp:ListItem Text="2022" />
                                            <asp:ListItem Text="2023" />
                                            <asp:ListItem Text="2024" />
                                            <asp:ListItem Text="2025" />
                                            <asp:ListItem Text="2026" />
                                            <asp:ListItem Text="2027" />
                                            <asp:ListItem Text="2028" />
                                            <asp:ListItem Text="2029" />
                                            <asp:ListItem Text="2030" />
                                        </asp:DropDownList>          
                                        <%--<asp:TextBox ID="txt_Validity_Year" Text='<%# Eval("Validity_Year") %>' runat="server" Width="120px"  required="required"/>--%>
                                    </EditItemTemplate>
                                     <FooterTemplate>
                                        <asp:DropDownList ID="txt_Validity_Year_Footer" runat="server" AutoPostBack="false" Width="120px" Height="25px">
                                            <asp:ListItem Text="2020" />
                                            <asp:ListItem Text="2021" />
                                            <asp:ListItem Text="2022" />
                                            <asp:ListItem Text="2023" />
                                            <asp:ListItem Text="2024" />
                                            <asp:ListItem Text="2025" />
                                            <asp:ListItem Text="2026" />
                                            <asp:ListItem Text="2027" />
                                            <asp:ListItem Text="2028" />
                                            <asp:ListItem Text="2029" />
                                            <asp:ListItem Text="2030" />
                                        </asp:DropDownList>                                        
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CVV">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("CVV") %>' runat="server" Width="80px"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_CVV" Text='<%# Eval("CVV") %>' runat="server" Width="80px" required="required"  pattern="[0-9]{3}" ToolTip="CVV By 3 dig"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txt_CVV_Footer" runat="server" Width="80px" required="required"  pattern="[0-9]{3}" ToolTip="CVV By 3 dig"/>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="#" ItemStyle-Wrap="false" ControlStyle-Width="30px">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" formnovalidate="formnovalidate"/>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Height="25px" formnovalidate="formnovalidate" OnClientClick="return confirm('Are you sure remove this Credit Card?')"/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" formnovalidate="formnovalidate"/>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" formnovalidate="formnovalidate"/>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ImageUrl="~/Image/GridView/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                                    </FooterTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                
                    </div>
                </asp:PlaceHolder>

                
                <!--this placeHolder get message from DB to web-->
                <asp:PlaceHolder ID="PlaceHolder_AddressDetails" runat="server">
                    <div style="margin: 25px;">
                        <label>addres</label>
                        <asp:TextBox ID="addressID" runat="server" placeholder="Address" required="required"></asp:TextBox><br />
                        <label>Mail</label>
                        <asp:TextBox ID="mailID" runat="server" placeholder="Mail" required="required"></asp:TextBox><br />
                        <label>Phone</label>
                        <asp:TextBox ID="phoneID" runat="server" placeholder="Phone No." required="required"></asp:TextBox><br />
                        <label>WhatsApp</label>
                        <asp:TextBox ID="whatsappID" runat="server" placeholder="What'sApp" required="required"></asp:TextBox><br />
                        <label>Fax</label>
                        <asp:TextBox ID="faxID" runat="server" placeholder="Fax" required="required"></asp:TextBox><br />
                        <label>Map</label>
                        <asp:TextBox ID="mapID" runat="server" placeholder="Map" required="required"></asp:TextBox><br />

                        <asp:Button runat="server" Text="Save" OnClick="save_Click" />
                    </div>
                </asp:PlaceHolder>



                <script type="text/javascript">
                    function delMsg(x) {
                        PageMethods.deleteMsgFromDB(x);
                        setTimeout(location.reload.bind(location), 10);
                    }
                    function delCareers(x) {
                        PageMethods.del_career_Click(x);
                        setTimeout(location.reload.bind(location), 10);
                    }
                    function addJob() {

                        var title = prompt('add title');
                        var details = prompt('add details');
                        if (title == null || details == null || title == "" || details == "") //if title or detail is missing, dont adding
                            alert("the Tittle or Details is Empty");
                        else
                            PageMethods.add_Job(title, details);
                        setTimeout(location.reload.bind(location), 10);
                    }
                    function addDeal() {
                        var title = prompt('add title');
                        var details = prompt('add details');
                        var day = prompt('add day');
                        var month = prompt('add mount');
                        var year = prompt('add year');

                        if (title == null || details == null || day == null || month == null || year == null || title == "" || details == "" || day == "" || month == "" || year == "") //if some cell missing, dont adding
                            alert("the Tittle or Details or Validity is Empty");
                        else if (!(day >= 1 && day <= 31 && month >= 1 && month <= 12))
                            alert("Error input data");
                        else
                            PageMethods.addDeal(title, details, day, month, year);
                        setTimeout(location.reload.bind(location), 10);
                    }
                    function delDeal(x) {
                        PageMethods.del_deal(x);
                        setTimeout(location.reload.bind(location), 10);
                    }

                    var modal = document.getElementById("myModal");
                    var modalImg = document.getElementById("img01");
                    var captionText = document.getElementById("caption");

                    function showImg(stringImgSrs) {
                        modal.style.display = "block";
                        modalImg.src = "Image/Cars/" + stringImgSrs;
                        captionText.innerHTML = stringImgSrs;
                        captionText.style.fontSize = "50px";
                        captionText.style.color = "red";
                    }

                    function closeShowImg() {
                        modal.style.display = "none";
                    }
                </script>
            </div>
        </div>
    </form>
</body>
</html>
