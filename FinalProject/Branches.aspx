<%@  Language="C#" AutoEventWireup="true" CodeBehind="Branches.aspx.cs" Inherits="FinalProject.Branches" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Branches</title> 
    <meta charset="utf-8" />
    <link href="StyleSheet/Branches_StyleSheet.css" rel="stylesheet" />
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
                    <asp:Label ID="Label1" class="navbar-brand page-scroll" runat="server" Text="Label">/</asp:Label>
                    <asp:LinkButton ID="idSignUp" href="SignUp.aspx" class="navbar-brand page-scroll" runat="server">Sign Up</asp:LinkButton>
                    <asp:LinkButton ID="idSignOut" class="navbar-brand page-scroll" runat="server" OnClick="SingOut_Click">Sign Out</asp:LinkButton>
                </div>
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a class="page-scroll" href="CaRental.aspx">Home</a></li>
                        <li><a class="page-scroll" href="Deals.aspx">Deals</a></li>
                        <li><a class="page-scroll" href="Branches.aspx" style="text-decoration: underline; color: white;">Branches</a></li>
                        <li><a class="page-scroll" href="Career.aspx">Career</a></li>
                        <li><a class="page-scroll" href="Contact.aspx">Contact</a></li>
                    </ul>
                </div>
            </div>
        </nav>
    </form>

    <div class="dANDm">
        <div class="details">
            <div class="classLine">
                <p class="title"><ins>Address</ins>:</></p>
                <p id="address_ID" runat="server" class="pergraph"></p>
            </div>
            <div class="classLine">
                <p class="title"><ins>Mail</ins>:</></p>
                <a id="mail_ID" runat="server" class="pergraph" title="Sent Email"><u>oznatan89@gmail.com</u></a>
            </div>
            <div class="classLine">
                <p class="title"><ins>Phone</ins>:</></p>
                <p id="phone_ID" runat="server" class="pergraph"></p>
            </div>
            <div class="classLine">
                <p class="title"><ins>WhatsApp</ins>:</></p>
                <a id="whatsapp_ID" runat="server" class="pergraph" title="Sent WhatApp"></a>
            </div>
            <div class="classLine">
                <p class="title"><ins>Fax</ins>:</></p>
                <p id="fax_ID" runat="server" class="pergraph"></p>
            </div>
        </div>
        <div>
            <iframe id="map_ID" runat="server" class="mapId"></iframe>
        </div>
    </div>
</body>
</html>
