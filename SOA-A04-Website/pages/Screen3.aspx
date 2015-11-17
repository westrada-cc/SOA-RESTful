<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Screen3.aspx.cs" Inherits="SOA_A04_Website.pages.Screen3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" media="screen" href="/CrazyMelvinsCSS.css"/>
    <title>Crazy Melvins Shopping Emporium</title>
</head>
<body id="css-CrazyMelvins"> 
    <div class="page-wrapper">
        <form id="Screen3_Form" runat="server">
            <header role="banner">
                <h1>Crazy Melvins Shopping Emporium</h1>
            </header>
            <div>
                <asp:TextBox ID="outputTxtBox" runat="server" TextMode="MultiLine" 
                            BorderStyle="Solid" Height="480px" Width="640px" ReadOnly="true">
                </asp:TextBox>
            </div>

            <div class="button-choices" id="CrazyMelvins_button_choices" role="article">   
                <!--Create the submit button (used to submit the web form) and the cancel button (refreshes the page to a "blank slate" state)-->
                <asp:Button ID="backBtn" runat="server" Text="Go Back" CausesValidation="false" OnClick="backBtn_Click" />
                <asp:Button ID="printBtn" runat="server" Text="Print" OnClick="printBtn_Click" />
                <asp:Button ID="leaveBtn" runat="server" Text="Get me outta here!" CausesValidation="false"/>
            </div>
        </form>
    </div>
</body>
</html>
