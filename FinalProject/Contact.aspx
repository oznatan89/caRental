<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="FinalProject.Contact" %>

<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact</title>
    <meta charset="utf-8" />
    <link href="StyleSheet/Contact_StyleSheet.css" rel="stylesheet" />
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
                    <asp:LinkButton ID="idHelloUser" href="Admin.aspx" class="navbar-brand page-scroll" runat="server">Hello User</asp:LinkButton>S
                    <asp:Label class="navbar-brand page-scroll" runat="server">/</asp:Label>
                    <asp:LinkButton ID="idSignUp" href="SignUp.aspx" class="navbar-brand page-scroll" runat="server">Sign Up</asp:LinkButton>
                    <asp:LinkButton ID="idSignOut" class="navbar-brand page-scroll" runat="server" OnClick="SingOut_Click">Sign Out</asp:LinkButton>
                </div>
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a class="page-scroll" href="CaRental.aspx">Home</a></li>
                        <li><a class="page-scroll" href="Deals.aspx">Deals</a></li>
                        <li><a class="page-scroll" href="Branches.aspx">Branches</a></li>
                        <li><a class="page-scroll" href="Career.aspx">Career</a></li>
                        <li><a class="page-scroll" style="text-decoration: underline; color: white;" href="Contact.aspx">Contact</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <div id="container123">
            <h2 id="h2123">Contact Us</h2>
            <div id="panel123">
                <input type="text" id="NameId" name="name" runat="server" placeholder="Your Name" autofocus="autofocus" />
                <input type="email" id="EmailId" name="email" runat="server" placeholder="Your Email" />
                <input type="tel" id="PhoneID" name="telephone" runat="server" placeholder="Phone Number" />
                <div>
                    <textarea name="message" id="textareaID" style="margin-bottom: 0px;" onkeyup="refresh()" maxlength="150" minlength="10" placeholder="Enter your message..." runat="server" required="required"></textarea>
                    <asp:Label ID="Label1" Style="margin-left: 50px;" runat="server" Text="0/150"></asp:Label>
                </div>
            </div>
            <div id="buttons">
                <asp:Button ID="resetButten" runat="server" Text="Reset" OnClick="ResetButten_Click" Height="35px" Width="100px" formnovalidate="formnovalidate" />
                <asp:Button ID="sendButton" runat="server" Text="Send" OnClick="SendButton_Click" Height="35px" Width="100px" />
            </div>
        </div>
    </form>

    <script type="text/javascript">

        GetURLParameter_career('career');
        GetURLParameter_deal('deal');


        //this function get value 'c1' in URL 
        function GetURLParameter_career(sParam) {
            var sPageURL = window.location.search.substring(1);
            var sURLVariables = sPageURL.split('&');
            for (var i = 0; i < sURLVariables.length; i++) {
                var sParameterName = sURLVariables[i].split('=');
                if (sParameterName[0] == sParam)
                    document.getElementById('textareaID').innerHTML = "Hello, I am interested in job no. " + sParameterName[1];
            }
        }


        //this function get value 'd1' in URL 
        function GetURLParameter_deal(sParam) {
            var sPageURL = window.location.search.substring(1);
            var sURLVariables = sPageURL.split('&');
            for (var i = 0; i < sURLVariables.length; i++) {
                var sParameterName = sURLVariables[i].split('=');
                if (sParameterName[0] == sParam)
                    document.getElementById('textareaID').innerHTML = "hay, I am interested in Deal No. " + sParameterName[1];
            }
        }

        function refresh() {
            Label1.innerHTML = textareaID.value.length + "/150";
        }
    </script>
</body>
</html>
