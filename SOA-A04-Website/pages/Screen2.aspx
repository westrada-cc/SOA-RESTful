<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Screen2.aspx.cs" Inherits="SOA_A04_Website.Screen2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Crazy Melvins Shopping Emporium</h3>
    <div>
        <table border="0" width="100%">
            <tr>
                <!--Create the submit button (used to submit the web form) and the cancel button (refreshes the page to a "blank slate" state)-->
               <td align="left">
                    <div id="poGenDiv" runat="server">Please generate a Purchase Order (P.O.)&nbsp;&nbsp;<input type="checkbox" id="poChkBoxID" name="poGenCheckBox" value="po" /></div>                  
                </td>
                <td />
                <td />
                <td />
                <td />
                <td />
                <td />
                <td />
                <td />
                <td />
                <td />
                <td />
                <td />
            </tr>
            <tr>
                <td><h1>Customer</h1></td>
                <!--User input field for customer id will be a TextBox-->
                <td align="right">custID</td>
                <td />
                <td align="left"><input type="text" size="15" id="custID" name="customer" runat="server"/></td>

                <!--User input field for first name will be a TextBox-->
                <td align="right">firstName</td>
                <td />
                <td align="left"><input type="text" size="15" id="firstNameID" name="firstname" runat="server"/></td>
                                
                <!--User input field for last name will be a TextBox-->
                <td align="right">lastName</td>
                <td />
                <td align="left"><input type="text" size="15" id="lastNameID" name="lastname" runat="server"/></td>

                <!--User input field for phone number will be a TextBox-->
                <td align="right">phoneNumber</td>
                <td />
                <td align="left"><input type="text" size="15" id="phoneNumberID" name="phonenumber" runat="server"/>xxx-xxx-xxxx&nbsp;</td>

                <td />
                <td />
                <td />
            </tr>
            <tr>
                <td><h1>Product</h1></td>
                <!--User input field for product id will be a TextBox-->
                <td align="right">prodID</td>
                <td />
                <td align="left"><input type="text" size="15" id="prodID" name="product" runat="server" /></td>

                <!--User input field for City will be a TextBox-->
                <td align="right">prodName</td>
                <td />
                <td align="left"><input type="text" size="15" id="prodNameID" name="productname" runat="server" /></td>
                                
                <!--User input field for Street Address will be a TextBox-->
                <td align="right">price</td>
                <td />
                <td align="left"><input type="text" size="15" id="priceID" name="price" runat="server" /></td>

                <!--User input field for City will be a TextBox-->
                <td align="right">prodWeight</td>
                <td />
                <td align="left"><input type="text" size="15" id="prodWeightID" name="productweight" runat="server" />kg.&nbsp;</td>

                <td align="right">Sold Out</td>
                <td />
                <td align="left"><input type="checkbox" id="soChkBoxID" name="soCheckBox" value="so" runat="server" /></td>

                <td />
                <td />
                <td />
            </tr>
            <tr>
                <td><h1>Order</h1></td>
                <!--User input field for Street Address will be a TextBox-->
                <td align="right">orderID</td>
                <td />
                <td align="left"><input type="text" size="15" id="orderID" name="order" runat="server" /></td>

                <!--User input field for City will be a TextBox-->
                <td align="right">custID</td>
                <td />
                <td align="left"><input type="text" size="15" id="custID2" name="customer2" runat="server" /></td>
                                
                <!--User input field for Street Address will be a TextBox-->
                <td align="right">poNumber</td>
                <td />
                <td align="left"><input type="text" size="15" id="poNumberID" name="ponumber" runat="server" /></td>

                <!--User input field for City will be a TextBox-->
                <td align="right">orderDate</td>
                <td />
                <td align="left"><input type="text" size="15" id="orderDateID" name="orderdate" runat="server" />MM-DD-YY&nbsp;</td>

                <td />
                <td />
                <td />
            </tr>
            <tr>
                <td><h1>Cart</h1></td>
                <!--User input field for Street Address will be a TextBox-->
                <td align="right">orderID</td>
                <td />
                <td align="left"><input type="text" size="15" id="orderID2" name="orderid2" runat="server" /></td>

                <!--User input field for City will be a TextBox-->
                <td align="right">prodID</td>
                <td />
                <td align="left"><input type="text" size="15" id="prodID2" name="prodid2" runat="server" /></td>
                                
                <!--User input field for Street Address will be a TextBox-->
                <td align="right">quantity</td>
                <td />
                <td align="left"><input type="text" size="15" id="quantityID" name="quantity" runat="server" /></td>

                <td />
                <td />
                <td />
                <td />
                <td />
                <td />
            </tr>
            <tr>
                <!--Create the submit button (used to submit the web form) and the cancel button (refreshes the page to a "blank slate" state)-->
                <td />
                <td />
                <td align="left">
                    <asp:Button ID="backBtn" runat="server" Text="Go Back" CausesValidation="false" OnClick="backBtn_Click" />
                    <asp:Button ID="executeBtn" runat="server" Text="Execute" OnClick="executeBtn_Click" />
                    <asp:Button ID="leaveBtn" runat="server" Text="Get me outta here!" CausesValidation="false"/>                  
                </td>
            </tr>
        </table>   
    </div>
    </form>
</body>
</html>
