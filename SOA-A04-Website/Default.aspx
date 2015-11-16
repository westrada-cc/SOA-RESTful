<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SOA_A04_Website._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crazy Melvins Shopping Emporium</title>
</head>
<body>
    <form id="defaultPageForm" runat="server">
    <h3>Crazy Melvins Shopping Emporium</h3>
    <br />
    <br />
    <p>Here at Crazy Melvin's we believe in selling things cheap!! That's why our user interface is cheap!</p>
    <br />
    <br />
    <p>Use the buttons below to tell me what you'd like to do here at Crazy Melvin's??</p>
    <div>    
        <table border="0" width="80%">
            <tr>
                <!--Create the submit button (used to submit the web form) and the cancel button (refreshes the page to a "blank slate" state)-->
                <td />
                <td />
                <td align="left">
                    <asp:Button ID="searchBtn" runat="server" Text="Search" CausesValidation="false" OnClick="searchBtn_Click" />
                    <asp:Button ID="insertBtn" runat="server" Text="Insert some Stuff" CausesValidation="False" OnClick="insertBtn_Click" />
                    <asp:Button ID="updateBtn" runat="server" Text="Update some Stuff" CausesValidation="false" OnClick="updateBtn_Click" />
                    <asp:Button ID="deleteBtn" runat="server" Text="Delete some Stuff" CausesValidation="false" OnClick="deleteBtn_Click" />                    
                </td>
            </tr>
            <tr>
                <td />
                <td />
                <td align="left">
                    <asp:Button ID="leaveBtn" runat="server" Text="Get me outta here!" CausesValidation="false"/> 
                </td>
            </tr>
        </table>        
    </div>
    </form>
</body>
</html>
