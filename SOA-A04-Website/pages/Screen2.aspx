<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Screen2.aspx.cs" Inherits="SOA_A04_Website.Screen2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" media="screen" href="/CrazyMelvinsCSS.css"/>
    <title>Crazy Melvins Shopping Emporium</title>
</head>
<body id="css-CrazyMelvins">    
    <div class="page-wrapper">
        <form id="Screen2_Form" runat="server">
            <header role="banner">
                <h1>Crazy Melvins Shopping Emporium</h1>
            </header>
            <div class="po-genrator" id="CrazyMelvins_po_generator" role="form" runat="server">
                Please generate a Purchase Order (P.O.)&nbsp;&nbsp;<input type="checkbox" id="poChkBoxID" name="poGenCheckBox" value="po" />
            </div>   
            
            <br />
            <br />

            <div class="customer-form" id="CrazyMelvins_customer_form" role="form">
                <h1>Customer</h1>
                <!--User input field for customer id will be a TextBox-->
                custID&nbsp;<input type="text" size="15" id="custID" name="customer" runat="server"/>&nbsp;&nbsp;
                <!--User input field for first name will be a TextBox-->
                firstName&nbsp;<input type="text" size="15" id="firstNameID" name="firstname" runat="server"/>&nbsp;&nbsp;
                <!--User input field for last name will be a TextBox-->
                lastName&nbsp;<input type="text" size="15" id="lastNameID" name="lastname" runat="server"/>&nbsp;&nbsp;
                <!--User input field for phone number will be a TextBox-->
                phoneNumber&nbsp;<input type="text" size="15" id="phoneNumberID" name="phonenumber" runat="server"/>xxx-xxx-xxxx&nbsp;&nbsp;
            </div>

            <br />
            <br />

            <div class="product-form" id="CrazyMelvins_product_form" role="form">
                <h1>Product</h1>
                <!--User input field for product id will be a TextBox-->
                prodID&nbsp;<input type="text" size="15" id="prodID" name="product" runat="server" />&nbsp;&nbsp;
                <!--User input field for City will be a TextBox-->
                prodName&nbsp;<input type="text" size="15" id="prodNameID" name="productname" runat="server" />&nbsp;&nbsp;
                <!--User input field for Street Address will be a TextBox-->
                price&nbsp;<input type="text" size="15" id="priceID" name="price" runat="server" />&nbsp;&nbsp;
                <!--User input field for City will be a TextBox-->
                prodWeight&nbsp;<input type="text" size="15" id="prodWeightID" name="productweight" runat="server" />kg.&nbsp;&nbsp;
                Sold Out&nbsp;<input type="checkbox" id="soChkBoxID" name="soCheckBox" value="so" runat="server" />&nbsp;&nbsp;
            </div>
            
            <br />
            <br />

            <div class="order-form" id="CrazyMelvins_order_form" role="form">
                <h1>Order</h1>
                <!--User input field for Street Address will be a TextBox-->
                orderID&nbsp;<input type="text" size="15" id="orderID" name="order" runat="server" />&nbsp;&nbsp;
                 <!--User input field for City will be a TextBox-->
                custID&nbsp;<input type="text" size="15" id="custID2" name="customer2" runat="server" />&nbsp;&nbsp;
                <!--User input field for Street Address will be a TextBox-->
                poNumber&nbsp;<input type="text" size="15" id="poNumberID" name="ponumber" runat="server" />&nbsp;&nbsp;
                <!--User input field for City will be a TextBox-->
                orderDate&nbsp;<input type="text" size="15" id="orderDateID" name="orderdate" runat="server" />MM-DD-YY&nbsp;&nbsp;
            </div>
            
            <br />
            <br />

            <div class="cart-form" id="CrazyMelvins_cart_form" role="form">
                <h1>Cart</h1>
                <!--User input field for Street Address will be a TextBox-->
                orderID&nbsp;<input type="text" size="15" id="orderID2" name="orderid2" runat="server" />&nbsp;&nbsp;
                <!--User input field for City will be a TextBox-->
                prodID&nbsp;<input type="text" size="15" id="prodID2" name="prodid2" runat="server" />&nbsp;&nbsp;
                <!--User input field for Street Address will be a TextBox-->
                quantity&nbsp;<input type="text" size="15" id="quantityID" name="quantity" runat="server" />&nbsp;&nbsp;
            </div>
            
            <br />
            <br />

            <div class="error-message" id="CrazyMelvins_Error_Message" role="summary">
                <p id="error_message"></p>
            </div>

            <div class="button-choices" id="CrazyMelvins_button_choices" role="article">   
                <!--Create the submit button (used to submit the web form) and the cancel button (refreshes the page to a "blank slate" state)-->
                <asp:Button ID="backBtn" runat="server" Text="Go Back" CausesValidation="false" OnClick="backBtn_Click" />
                <asp:Button ID="executeBtn" runat="server" Text="Execute" OnClick="executeBtn_Click" />
                <asp:Button ID="leaveBtn" runat="server" Text="Get me outta here!" CausesValidation="false"/>
            </div>
        </form>
    </div>
</body>
</html>
