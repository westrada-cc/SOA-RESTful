<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SOA_A04_Website._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
	<link rel="stylesheet" media="screen" href="/CrazyMelvinsCSS.css"/>
    <title>Crazy Melvins Shopping Emporium</title>
</head>
<body id="css-CrazyMelvins">
    <div class="page-wrapper">
        <form id="defaultPageForm" runat="server">
            <header role="banner">
                <h1>Crazy Melvins Shopping Emporium</h1>
                <h2>Here at Crazy Melvin's we believe in selling things cheap!! That's why our user interface is cheap!</h2>
            </header>

            <div class="summary" id="CrazyMelvins_summary" role="article">
                <p>Use the buttons below to tell me what you'd like to do here at Crazy Melvin's??</p>
            </div>

            <div class="button-choices" id="CrazyMelvins_button_choices" role="article">    
                <asp:Button ID="searchBtn" runat="server" Text="Search" CausesValidation="false" OnClick="searchBtn_Click" />
                <asp:Button ID="insertBtn" runat="server" Text="Insert some Stuff" CausesValidation="False" OnClick="insertBtn_Click" />
                <asp:Button ID="updateBtn" runat="server" Text="Update some Stuff" CausesValidation="false" OnClick="updateBtn_Click" />
                <asp:Button ID="deleteBtn" runat="server" Text="Delete some Stuff" CausesValidation="false" OnClick="deleteBtn_Click" />                    
                <asp:Button ID="leaveBtn" runat="server" Text="Get me outta here!" CausesValidation="false"/>       
            </div>
        </form>
    </div>
</body>
</html>
