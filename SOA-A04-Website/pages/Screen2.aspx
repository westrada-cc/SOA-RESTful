<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Screen2.aspx.cs" Inherits="SOA_A04_Website.Screen2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" media="screen" href="/CrazyMelvinsCSS.css"/>
    <title>Crazy Melvins Shopping Emporium</title>
</head>
<body id="css-CrazyMelvins">    
    <div id="page_wrapper" class="page-wrapper">
        <form id="Screen2_Form" name="Screen2Form" runat="server">
            <header role="banner">
                <h1>Crazy Melvins Shopping Emporium</h1>
            </header>

            <input type="hidden" id="execTypeID" runat="server"/>

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
                poNumber&nbsp;<input type="text" size="15" id="poNumberID" name="ponumber" textmode="password" runat="server" />&nbsp;&nbsp;
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
                <p style="color:red" id="errorMessage"></p>
            </div>

            <div class="button-choices" id="CrazyMelvins_button_choices" role="article">   
                <!--Create the submit button (used to submit the web form) and the cancel button (refreshes the page to a "blank slate" state)-->
                <asp:Button ID="backBtn" runat="server" Text="Go Back" CausesValidation="false" OnClick="backBtn_Click" />
                <asp:Button ID="executeBtn" runat="server" Text="Execute" OnClick="executeBtn_Click" OnClientClick="return validateForm()"/>
                <asp:Button ID="leaveBtn" runat="server" Text="Get me outta here!" CausesValidation="false"/>
                <!--OnClientClick="return validateForm()"-->
            </div>
        </form>
    </div>
</body>
</html>

<script type="text/javascript">
    
    function validateForm()
    {
        var result = 1;
        var execType = document.getElementById('execTypeID').value;

        document.getElementById('errorMessage').innerHTML = '';

        //Customer Section Validation
        if (validateCustomerID() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Customer ID is invalid<br/>';
            result = 0;
        }
        if (validateCustomerFirstName() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Customer First Name is invalid<br/>';
            result = 0;
        }
        if (validateCustomerLastName() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Customer Last Name is invalid<br/>';
            result = 0;
        }
        if (validatePhoneNumber() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Customer Phone Number is invalid<br/>';
            result = 0;
        }

        //Product Section Validation
        if (validateProductID() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Product ID is invalid<br/>';
            result = 0;
        }
        if (validateProductName() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Product Name is invalid<br/>';
            result = 0;
        }
        if (validateProductPrice() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Product price is invalid<br/>';
            result = 0;
        }
        if (validateProductWeight() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Product Weight must be a number<br/>';
            result = 0;
        }

        //Order Section Validation
        if (validateOrderID() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Order ID is invalid<br/>';
            result = 0;
        }
        if (validateOrderCustomerID() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Order Customer ID is invalid<br/>';
            result = 0;
        }
        if (validateOrderPoNumber() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Order P.O. NUmber is invalid<br/>';
            result = 0;
        }
        if (validateOrderDate() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Order Date is invalid<br/>';
            result = 0;
        }

        //Cart Section Validation
        if (validateCartOrderID() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Cart Order ID is invalid<br/>';
            result = 0;
        }
        if (validateCartProductID() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Cart Product ID is invalid<br/>';
            result = 0;
        }
        if (validateCartQuantity() === false)
        {
            document.getElementById('errorMessage').innerHTML += 'Cart Quantity must be a number<br/>';
            result = 0;
        }

        document.getElementById('errorMessage').innerHTML += result;

        return Boolean(result);
    }

    function validateCustomerID()
    {
        var customerID = document.getElementById("custID").value;
        var numRegex = /^-?[\d.]+(?:e-?\d+)?$/;

        return numRegex.test(customerID);
    }

    function validateCustomerFirstName()
    {
        var customerFirstName = document.getElementById("firstNameID").value;
        var numRegex = /^[a-z ,.'-]+$/i;

        return numRegex.test(customerFirstName);
    }

    function validateCustomerLastName()
    {
        var customerLastName = document.getElementById("lastNameID").value;
        var numRegex = /^[a-z ,.'-]+$/i;

        return numRegex.test(customerLastName);
    }

    function validatePhoneNumber()
    {
        var phoneNumber = document.getElementById("phoneNumberID").value;
        var phoneRegex = /^\(?([0-9]{3})\)?[-]?([0-9]{3})[-]?([0-9]{4})$/;;
        if (phoneNumber != null)
        {
            return phoneRegex.test(phoneNumber);
        }
    }

    function validateProductID()
    {
        var productID = document.getElementById("prodID").value;
        var numRegex = /^-?[\d.]+(?:e-?\d+)?$/;

        return numRegex.test(productID);
    }

    function validateProductName()
    {

    }

    function validateProductPrice()
    {
        var price = document.getElementById("priceID").value;
        var priceRegex = /^\d+(?:\.\d{0,2})$/;

        return priceRegex.test(price);
    }

    function validateProductWeight()
    {
        var weight = document.getElementById("prodWeightID").value;
        var numRegex = /^-?[\d.]+(?:e-?\d+)?$/;

        return numRegex.test(weight);
    }

    function validateOrderID()
    {
        var orderID = document.getElementById("orderID").value;
        var numRegex = /^-?[\d.]+(?:e-?\d+)?$/;

        return numRegex.test(orderID);
    }

    function validateOrderCustomerID()
    {
        var customerID = document.getElementById("custID2").value;
        var numRegex = /^-?[\d.]+(?:e-?\d+)?$/;

        return numRegex.test(customerID);
    }

    function validateOrderPoNumber()
    {

    }

    function validateOrderDate() 
    {
        var orderDate = document.getElementById("orderDateID").value;
        var orderDateRegex = /^\d{1,2}\-\d{1,2}\-\d{4}$/;;

        return orderDateRegex.test(orderDate);
    }

    function validateCartOrderID()
    {
        var orderID = document.getElementById("orderID2").value;
        var numRegex = /^-?[\d.]+(?:e-?\d+)?$/;

        return numRegex.test(orderID);
    }

    function validateCartProductID()
    {
        var productID = document.getElementById("prodID2").value;
        var numRegex = /^-?[\d.]+(?:e-?\d+)?$/;

        return numRegex.test(productID);
    }

    function validateCartQuantity()
    {
        var quantity = document.getElementById("quantityID").value;
        var numRegex = /^-?[\d.]+(?:e-?\d+)?$/;

        return numRegex.test(quantity);
    }


</script>