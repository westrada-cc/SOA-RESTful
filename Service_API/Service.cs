using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Xml;

namespace Service_API
{
    public class Service
    {
        private const string SERVICE_URL = "http://localhost:3745/ShoppingEmporium.svc/";
        private HttpClient client;

        #region insert methods
        public void insertCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "custID", customerID.ToString() },
                { "firstName", firstName },
                { "lastName", lastName },
                { "phoneNumber", phoneNumber }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync(SERVICE_URL + "customers/", content);

            //var responseString = await response.Content.ReadAsStringAsync();
        }

        public void insertProduct(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "inStock", soldOut.ToString() },
                { "price", price.ToString() },
                { "prodID", productID.ToString() },
                { "prodName", productName },
                { "prodWeight", productWeight.ToString() }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync(SERVICE_URL + "products/", content);
        }

        public void insertOrder(int orderID, int customerID, string poNumber, string orderDate)
        {
            client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "custID", customerID.ToString() },
                { "orderDate", orderDate },
                { "orderID", orderID.ToString() },
                { "poNumber", poNumber }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync(SERVICE_URL + "orders/", content);
        }

        public void insertCart(int orderID, int productID, int quantity)
        {
            client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "orderID", orderID.ToString() },
                { "prodID", productID.ToString() },
                { "quantity", quantity.ToString() }
            };

            var content = new FormUrlEncodedContent(values;

            var response = client.PostAsync(SERVICE_URL + "carts/", content);
        }
        #endregion

        #region update methods
        public void updateCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "custID", customerID.ToString() },
                { "firstName", firstName },
                { "lastName", lastName },
                { "phoneNumber", phoneNumber }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PutAsync(SERVICE_URL + "customers/", content);
        }

        public void updateProduct(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "inStock", soldOut.ToString() },
                { "price", price.ToString() },
                { "prodID", productID.ToString() },
                { "prodName", productName },
                { "prodWeight", productWeight.ToString() }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PutAsync(SERVICE_URL + "products/", content);
        }

        public void updateOrder(int orderID, int customerID, string poNumber, string orderDate)
        {
            client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "custID", customerID.ToString() },
                { "orderDate", orderDate },
                { "orderID", orderID.ToString() },
                { "poNumber", poNumber }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PutAsync(SERVICE_URL + "orders/", content);
        }

        public void updateCart(int orderID, int productID, int quantity)
        {
            client = new HttpClient();

            var values = new Dictionary<string, string>
            {
                { "orderID", orderID.ToString() },
                { "prodID", productID.ToString() },
                { "quantity", quantity.ToString() }
            };

            var content = new FormUrlEncodedContent(values);

            var response = client.PutAsync(SERVICE_URL + "carts/", content);
        }
        #endregion

        #region delete methods
        public void deleteCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            client = new HttpClient();

            var response = client.DeleteAsync(SERVICE_URL + "customers/" + customerID.ToString());
        }

        public void deleteProduct(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            client = new HttpClient();

            var response = client.DeleteAsync(SERVICE_URL + "products/" + productID.ToString());
        }

        public void deleteOrder(int orderID, int customerID, string poNumber, string orderDate)
        {
            client = new HttpClient();

            var response = client.DeleteAsync(SERVICE_URL + "orders/" + orderID.ToString());
        }

        public void deleteCart(int orderID, int productID, int quantity)
        {
            client = new HttpClient();

            var response = client.DeleteAsync(SERVICE_URL + "carts/" + orderID);
        }
        #endregion

        #region search methods
        public Customer searchCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            XmlDocument xml = new XmlDocument();
            client = new HttpClient();
            Customer customer = new Customer();

            var responseString = client.GetStringAsync(SERVICE_URL + "customers/" + firstName);

            xml.LoadXml(responseString.ToString());

            XmlNodeList nodes = xml.GetElementsByTagName("customer");

            foreach (XmlNode node in nodes)
            {
                XmlNodeList children = node.ChildNodes;

                foreach (XmlNode child in children)
                {
                    if (child.Name == "custID")
                    {
                        customer.customerID = Convert.ToInt32(child.InnerText);
                    }
                    else if (child.Name == "firstName")
                    {
                        customer.firstName = child.InnerText;
                    }
                    else if (child.Name == "lastName")
                    {
                        customer.lastName = child.InnerText;
                    }
                    else if (child.Name == "phoneNumber")
                    {
                        customer.phoneNumber = child.InnerText;
                    }
                }
            }

            return customer;
        }

        public Product searchProduct(int productID, string productName, float price, float productWeight, bool soldOut)
        {
            XmlDocument xml = new XmlDocument();
            client = new HttpClient();
            Product product = new Product();

            var responseString = client.GetStringAsync(SERVICE_URL + "customers/" + productID);

            xml.LoadXml(responseString.ToString());

            XmlNodeList nodes = xml.GetElementsByTagName("product");

            foreach (XmlNode node in nodes)
            {
                XmlNodeList children = node.ChildNodes;

                foreach (XmlNode child in children)
                {
                    if (child.Name == "prodID")
                    {
                        product.productID = Convert.ToInt32(child.InnerText);
                    }
                    else if (child.Name == "prodName")
                    {
                        product.productName = child.InnerText;
                    }
                    else if (child.Name == "price")
                    {
                        float tempValue;
                        float.TryParse(child.InnerText, out tempValue);
                        product.price = tempValue;
                    }
                    else if (child.Name == "prodWeight")
                    {
                        float tempValue;
                        float.TryParse(child.InnerText, out tempValue);
                        product.productWeight = tempValue;
                    }
                    else if (child.Name == "inStock")
                    {
                        bool tempValue;
                        bool.TryParse(child.InnerText, out tempValue);
                        product.soldOut = tempValue;
                    }
                }
            }

            return product;
        }

        public Order searchOrder(int orderID, int customerID, string poNumber, string orderDate)
        {
            XmlDocument xml = new XmlDocument();
            client = new HttpClient();
            Order order = new Order();

            var responseString = client.GetStringAsync(SERVICE_URL + "orders/" + orderID);

            xml.LoadXml(responseString.ToString());

            XmlNodeList nodes = xml.GetElementsByTagName("order");

            foreach (XmlNode node in nodes)
            {
                XmlNodeList children = node.ChildNodes;

                foreach (XmlNode child in children)
                {
                    if (child.Name == "orderID")
                    {
                        order.orderID = Convert.ToInt32(child.InnerText);
                    }
                    else if (child.Name == "custID")
                    {
                        order.customerID = Convert.ToInt32(child.InnerText);
                    }
                    else if (child.Name == "poNumber")
                    {
                        order.poNumber = child.InnerText;
                    }
                    else if (child.Name == "orderDate")
                    {
                        order.orderDate = child.InnerText;
                    }
                }
            }

            return order;
        }

        public Cart searchCart(int orderID, int productID, int quantity)
        {
            XmlDocument xml = new XmlDocument();
            client = new HttpClient();
            Cart cart = new Cart();

            var responseString = client.GetStringAsync(SERVICE_URL + "carts/" + orderID);

            xml.LoadXml(responseString.ToString());

            XmlNodeList nodes = xml.GetElementsByTagName("cart");

            foreach (XmlNode node in nodes)
            {
                XmlNodeList children = node.ChildNodes;

                foreach (XmlNode child in children)
                {
                    if (child.Name == "orderID")
                    {
                        cart.orderID = Convert.ToInt32(child.InnerText);
                    }
                    else if (child.Name == "prodID")
                    {
                        cart.productID = Convert.ToInt32(child.InnerText);
                    }
                    else if (child.Name == "quantity")
                    {
                        cart.quantity = Convert.ToInt32(child.InnerText);
                    }
                }
            }

            return cart;
        }
        #endregion
    }
}
