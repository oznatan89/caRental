<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deals.aspx.cs" Inherits="FinalProject.Deals" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deals</title> 
    <meta charset="utf-8" />
    <link href="StyleSheet/Deals_StyleSheet.css" rel="stylesheet" />
    <link href="StyleSheet/General_StyleSheet.css" rel="stylesheet" />
    <link rel="icon" href="Image/Porsche.png" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <asp:LinkButton ID="idSignIn" href="SignIn.aspx" class="navbar-brand page-scroll" runat="server">Sign In</asp:LinkButton>
                    <asp:LinkButton ID="idHelloAdmin" href="Admin.aspx" class="navbar-brand page-scroll" runat="server">Hello Admin</asp:LinkButton>
                    <asp:LinkButton ID="idHelloUser" href="Admin.aspx" class="navbar-brand page-scroll" runat="server">Hello User</asp:LinkButton>
                    <asp:Label class="navbar-brand page-scroll" runat="server">/</asp:Label>
                    <asp:LinkButton ID="idSignUp" href="SignUp.aspx" class="navbar-brand page-scroll" runat="server">Sign Up</asp:LinkButton>
                    <asp:LinkButton ID="idSignOut" class="navbar-brand page-scroll" runat="server" OnClick="SingOut_Click">Sign Out</asp:LinkButton>
                </div>
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a class="page-scroll" href="CaRental.aspx">Home</a></li>
                        <li><a class="page-scroll" style="text-decoration: underline; color: white;" href="Deals.aspx">Deals</a></li>
                        <li><a class="page-scroll" href="Branches.aspx">Branches</a></li>
                        <li><a class="page-scroll" href="Career.aspx">Career</a></li>
                        <li><a class="page-scroll" href="Contact.aspx">Contact</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <!--
        <div class="allDiv" runat='server'>
            <h1>aaaaa</h1>
            <p id='TextBox_Detailsjob'>aaaaaaaa bbbbbb cccccccc ddd eeeeeee</p>
            <label style="color:red;">time</label>
        </div> -->

        <script type="text/javascript">
            function render(id) {
                window.location.href = "Contact.aspx?deal=" + id;
            }
        </script>
    </form>

</body>
</html>


