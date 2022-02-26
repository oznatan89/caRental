<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="FinalProject.SignUp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title> 
    <meta charset="utf-8" />
    <link href="StyleSheet/SignUp_StyleSheet.css" rel="stylesheet" />
    <link href="StyleSheet/General_StyleSheet.css" rel="stylesheet" />
    <link rel="icon" href="Image/Porsche.png" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <asp:LinkButton ID="idSignIn" href="SignIn.aspx" class="navbar-brand page-scroll" runat="server">Sign In</asp:LinkButton>
                    <asp:Label class="navbar-brand page-scroll" runat="server">/</asp:Label>
                    <asp:LinkButton ID="idSignUp" href="SignUp.aspx" class="navbar-brand page-scroll" runat="server">Sign Up</asp:LinkButton>
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

        <div class="inlin">
            <div id="signout" class="contain">
                <h2 class="log">Sign up</h2>
                <div class="myform123" runat="server">
                    <div>
                        <asp:TextBox ID="id__ID" placeholder="ID" runat="server" pattern="[0-9]{9}" ToolTip="ID By 9 digit" required="required" autofocus="autofocus"></asp:TextBox>
                        <asp:TextBox ID="First__NameID" type="text" placeholder="First name" runat="server" required="required"></asp:TextBox>
                        <asp:TextBox ID="Last__NameID" type="text" placeholder="Last name" runat="server" required="required"></asp:TextBox>
                        <asp:TextBox ID="Age__Id" type="date" Style="text-align: left;"  value="1989-06-15" runat="server"></asp:TextBox>
                        <asp:TextBox ID="Address__ID" type="text" placeholder="Address" runat="server" required="required"></asp:TextBox>
                        <asp:TextBox ID="Mail__ID" type="email" placeholder="Mail" runat="server" required="required"></asp:TextBox>
                        <asp:TextBox ID="Phone__ID" type="tel" minLength="11" placeholder="Phone Number" runat="server" pattern="[0-9]{3}-[0-9]{7}" ToolTip="Format: 05*-*******" required="required"></asp:TextBox>
                        <asp:TextBox ID="UserName__ID" runat="server" placeholder="User Name" required="required"></asp:TextBox>
                        <asp:TextBox ID="PassWord__ID" type="password" placeholder="PassWord" runat="server" required="required"></asp:TextBox>
                    </div>
                    <div class="buttons" runat="server">
                        <asp:Button ID="singin" class="myBtn" runat="server" type="submit" Text="Sign In" OnClick="singin_Click" formnovalidate="formnovalidate"/>
                        <asp:Button ID="reset" class="myBtn" runat="server" type="reset" Text="Reset" OnClick="reset_Click" formnovalidate="formnovalidate"></asp:Button>
                        <asp:Button ID="creat" class="myBtn" runat="server" type="submit" Text="Create" OnClick="creat_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
