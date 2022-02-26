<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="FinalProject.SignIn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignIn</title>
    <meta charset="utf-8" /> 
    <link href="StyleSheet/SignIn_StyleSheet.css" rel="stylesheet" />
    <link href="StyleSheet/General_StyleSheet.css" rel="stylesheet" />
    <link rel="icon" href="Image/Porsche.png" />

    <script type="text/javascript">
        var char = null;
        function refresh() {
            Label1.innerHTML = textarea123.value.length + "/150";
        }
    </script>
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
            <div id="signin" class="contain" style="text-align: left;">
                <h2 class="log">Sign in</h2>
                <div class="myform123" runat="server">
                    <div>
                        <asp:TextBox ID="usernameID" type="text" name="Username1" placeholder="Username" runat="server" required="required"></asp:TextBox>
                        <asp:TextBox ID="passwordID" type="password" name="password" placeholder="Password" runat="server" required="required"></asp:TextBox>
                    </div>
                    <asp:LinkButton ID="LinkButton1" Style="padding-left: 25px; cursor: pointer;" runat="server" href="SignUp.aspx">Sign Up</asp:LinkButton>
                    <br />
                    <asp:Button ID="LogID" class="myBtn" runat="server" Text="Log" OnClick="SignIn_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
