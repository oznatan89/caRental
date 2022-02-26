<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment_Page.aspx.cs" Inherits="FinalProject.Payment_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
    <meta charset="utf-8" />
    <link href="StyleSheet/PaymentPage_StyleSheet.css" rel="stylesheet" />
    <link rel="icon" href="Image/Porsche.png" />
</head>
<body>
    <form runat="server">

        <asp:PlaceHolder ID="PlaceHolder2" runat="server">

            <div id="contain">

                <div style="border: 1px solid grey; padding: 30px;">
                                        
                    <asp:TextBox ID="credit_No_ID" runat="server" placeholder="Credit card number" autofocus="autofocus" required="required" />

                    <select id="validity_Month_ID" runat="server">
                        <option value="January">January</option>
                        <option value="February">February </option>
                        <option value="March">March</option>
                        <option value="April">April</option>
                        <option value="May">May</option>
                        <option value="June">June</option>
                        <option value="July">July</option>
                        <option value="August">August</option>
                        <option value="September">September</option>
                        <option value="October">October</option>
                        <option value="November">November</option>
                        <option value="December">December</option>
                    </select>
                    <select id="validity_Year_ID" runat="server">
                        <option value="2020">2020</option>
                        <option value="2021">2021</option>
                        <option value="2022">2022</option>
                        <option value="2023">2023</option>
                        <option value="2024">2024</option>
                        <option value="2025">2025</option>
                        <option value="2026">2026</option>
                        <option value="2027">2027</option>
                        <option value="2028">2028</option>
                        <option value="2029">2029</option>
                        <option value="2030">2030</option>
                    </select>

                    <asp:TextBox ID="cvv_ID" runat="server" placeholder="CVV" pattern="[0-9]{3}" ToolTip="CVV By 3 dig" required="required" />
                    <div>
                        <asp:Button ID="submit_ID" Text="Submit" runat="server" onClientClick="Submit_c(credit_No_ID.value, validity_Month_ID.value, validity_Year_ID.value, cvv_ID.value)"/>
                    </div>

                </div>

                <div style="margin-top: 20px; text-align: center;">
                    <img src="Image/CreditCard/mastercard.jpg" style="width: 120px; height: 100px;" />
                    <img src="Image/CreditCard/amex.jpg" style="width: 120px; height: 100px;" />
                    <img src="Image/CreditCard/visa.jpg" style="width: 120px; height: 100px;" />
                    <img src="Image/CreditCard/Diners.jpg" style="width: 120px; height: 100px;" />
                </div>

            </div>

        </asp:PlaceHolder>

       
        <!--do no delete that, it's make able connection between c# methods and JavaScript-->
        <asp:ScriptManager ID="smMain" runat="server" EnablePageMethods="true" />

        <script type="text/javascript">
            function Submit_c(credit_No_ID, validity_Month_ID, validity_Year_ID, cvv_ID)
            {                
                PageMethods.Submit_Click(credit_No_ID, validity_Month_ID, validity_Year_ID, cvv_ID, OnSucceeded);
                function OnSucceeded(response) {
                    if (response) {
                        alert('Your CreditCard was saved!');
                        this.window.close();
                    }
                    else {
                        alert("wrong!")
                    }
                }
            }
        </script>

    </form>
</body>
</html>
