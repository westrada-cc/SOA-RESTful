using System;
using System.Collections.Generic;
using System.Text;

namespace Service_API
{
    public class Service
    {
        #region insert methods
        public void insertCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            Customer customer = new Customer(customerID, firstName, lastName, phoneNumber);
            
        }

        public void insertProduct(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            Product product = new Product(productID, productName, price, productWeight, soldOut);

        }

        public void insertOrder(int orderID, int customerID, string poNumber, string orderDate)
        {
            Order order = new Order(orderID, customerID, poNumber, orderDate);
        }

        public void insertCart(int orderID, int productID, int quantity)
        {
            Cart cart = new Cart(orderID, productID, quantity);
        }
        #endregion

        #region update methods
        public void updateCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            Customer customer = new Customer(customerID, firstName, lastName, phoneNumber);
        }

        public void updateProduct(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            Product product = new Product(productID, productName, price, productWeight, soldOut);
        }

        public void updateOrder(int orderID, int customerID, string poNumber, string orderDate)
        {
            Order order = new Order(orderID, customerID, poNumber, orderDate);
        }

        public void updateCart(int orderID, int productID, int quantity)
        {
            Cart cart = new Cart(orderID, productID, quantity);
        }
        #endregion

        #region delete methods
        public void deleteCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            Customer customer = new Customer(customerID, firstName, lastName, phoneNumber);
        }

        public void deleteProduct(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            Product product = new Product(productID, productName, price, productWeight, soldOut);
        }

        public void deleteOrder(int orderID, int customerID, string poNumber, string orderDate)
        {
            Order order = new Order(orderID, customerID, poNumber, orderDate);
        }

        public void deleteCart(int orderID, int productID, int quantity)
        {
            Cart cart = new Cart(orderID, productID, quantity);
        }
        #endregion

        #region search methods
        public void searchCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            Customer customer = new Customer(customerID, firstName, lastName, phoneNumber);
        }

        public void searchProduct(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            Product product = new Product(productID, productName, price, productWeight, soldOut);
        }

        public void searchOrder(int orderID, int customerID, string poNumber, string orderDate)
        {
            Order order = new Order(orderID, customerID, poNumber, orderDate);
        }

        public void searchCart(int orderID, int productID, int quantity)
        {
            Cart cart = new Cart(orderID, productID, quantity);
        }
        #endregion
    }
}
