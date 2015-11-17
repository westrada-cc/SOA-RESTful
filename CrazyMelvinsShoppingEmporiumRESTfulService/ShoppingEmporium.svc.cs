using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    
    public class ShoppingEmporium : IShoppingEmporium
    {
        public object[] Search(string search)
        {
            if (search != null && search.Length > 0 && search.Contains("="))
            {
                var arguments = new Dictionary<string, string>(); // this is where we are going to store parsed arguments.
                var searchBits = search.Split(new string[] {"|"}, StringSplitOptions.None);
                foreach (var bit in searchBits)
                {
                    var argumentAndValue = bit.Split(new string[] {"="}, StringSplitOptions.None);
                    if (argumentAndValue.Count() == 2)
                    {
                        arguments.Add(argumentAndValue[0], argumentAndValue[1]);
                    }
                }

                if (arguments.ContainsKey("custID") ||
                    arguments.ContainsKey("firstName") ||
                    arguments.ContainsKey("lastName") ||
                    arguments.ContainsKey("phoneNumber"))
                {
                    return this.GetCustomerBy(
                        arguments.ContainsKey("custID")  ? int.Parse(arguments["custID"]) as int? : null,
                    arguments.ContainsKey("firstName")  ? arguments["firstName"] : null,
                    arguments.ContainsKey("lastName") ? arguments["lastName"] : null,
                    arguments.ContainsKey("phoneNumber")  ? arguments["phoneNumber"] : null).ToArray();
                }


                // Go through arguments and depending on what arguments are, query the database. //
                if (arguments.ContainsKey("prodID") ||
                    arguments.ContainsKey("prodName") ||
                    arguments.ContainsKey("price") ||
                    arguments.ContainsKey("prodWeight") ||
                    arguments.ContainsKey("inStock"))
                {
                    return this.GetProductsBy(
                        (arguments.ContainsKey("prodID") ? int.Parse(arguments["prodID"]) as int? : null), 
                        arguments.ContainsKey("prodName") ? arguments["prodName"] : null, 
                        arguments.ContainsKey("price") ? double.Parse(arguments["price"]) as double? : null, 
                        arguments.ContainsKey("prodWeight") ? double.Parse(arguments["prodWeight"]) as double? : null,
                        arguments.ContainsKey("inStock") ? bool.Parse(arguments["inStock"]) as bool? : null).ToArray();
                }



               
            }

            return null;
        }

        private Customer GetCustomerById(int id)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedCustomer = context.Customers.Where(o => o.custID == id).FirstOrDefault();
                if (fetchedCustomer != null)
                {
                    return new Customer(fetchedCustomer);
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Customer not found", "Customer with ID " + id + " not found."), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        private Customer GetCustomerByFirstName(string firstName)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedCustomer = context.Customers.Where(o => o.firstName == firstName).FirstOrDefault();
                if (fetchedCustomer != null)
                {
                    return new Customer(fetchedCustomer);
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Customer not found",""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        private Customer GetCustomerByLastName(string lastName)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedCustomer = context.Customers.Where(o => o.lastName == lastName).FirstOrDefault();
                if (fetchedCustomer != null)
                {
                    return new Customer(fetchedCustomer);
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Customer not found", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        private Customer GetCustomerByPhoneNumber(string phone)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedCustomer = context.Customers.Where(o => o.phoneNumber == phone).FirstOrDefault();
                if (fetchedCustomer != null)
                {
                    return new Customer(fetchedCustomer);
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Customer not found", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        public IList<Customer> GetCustomerBy(int? custID, string firstName, string lastName, string phoneNumber)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                IQueryable<Models.Customer> query = context.Customers;
                if (custID != null)
                {
                    query = query.Where(o => o.custID == custID.Value);
                }
                if (firstName != null)
                {
                    query = query.Where(o => o.firstName == firstName);
                }
                if (lastName != null)
                {
                    query = query.Where(o => o.lastName == lastName);
                }
                if (phoneNumber != null)
                {
                    query = query.Where(o => o.phoneNumber == phoneNumber);
                }

                var fetchedList = query.ToList();
                if (fetchedList != null && fetchedList.Count > 0)
                {
                    var convertedList = new List<Customer>();
                    foreach (var item in fetchedList)
                    {
                        convertedList.Add(new Customer(item));
                    }
                    return convertedList;
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Customer not found", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        private IList<Product> GetProductsBy(int? prodId, string prodName, double? price, double? prodWeight, bool? inStock)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                IQueryable<Models.Product> productQuery = context.Products;
                if (prodId != null)
                {
                    productQuery = productQuery.Where(o => o.prodID == prodId.Value);
                }
                if (prodName != null)
                {
                    productQuery = productQuery.Where(o => o.prodName == prodName);
                }
                if (price != null)
                {
                    productQuery = productQuery.Where(o => o.price == price.Value);
                }
                if (prodWeight != null)
                {
                    productQuery = productQuery.Where(o => o.prodWeight == prodWeight.Value);
                }
                if (inStock != null)
                {
                    productQuery = productQuery.Where(o => o.inStock == inStock.Value);
                }

                var fetchedList = productQuery.ToList();
                if (fetchedList != null && fetchedList.Count > 0)
                {
                    var convertedList = new List<Product>();
                    foreach(var item in fetchedList)
                    {
                        convertedList.Add(new Product(item));
                    }
                    return convertedList;
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Product not found", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        private IList<Order> GetOrderBy(int? orderId, int? custId, string poNumber, DateTime? orderDate)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                IQueryable<Models.Order> query = context.Orders;
                if (orderId != null)
                {
                    query = query.Where(o => o.orderID == orderId.Value);
                }
                if (custId != null)
                {
                    query = query.Where(o => o.custID == custId.Value);
                }
                if (poNumber != null)
                {
                    query = query.Where(o => o.poNumber == poNumber);
                }
                if (orderDate != null)
                {
                    query = query.Where(o => o.orderDate == orderDate.Value);
                }

                var fetchedList = query.ToList();
                if (fetchedList != null && fetchedList.Count > 0)
                {
                    var convertedList = new List<Order>();
                    foreach (var item in fetchedList)
                    {
                        convertedList.Add(new Order(item));
                    }
                    return convertedList;
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Product not found", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        private Cart GetCartBy(int orderId, int prodId, int quantity)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedCustomer = context.Carts.Where(o => o.orderID == orderId || o.prodID == prodId || o.quantity == quantity).FirstOrDefault();
                if (fetchedCustomer != null)
                {
                    return new Cart(fetchedCustomer);
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Cart not found", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        #region | Customers |

        public IList<Customer> GetCustomerList()
        {
            try
            {
                using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
                {
                    var customerList = context.Customers;
                    var customersToReturn = new List<Customer>();
                    foreach (var c in customerList)
                    {
                        customersToReturn.Add(new Customer(c));
                    }

                    return customersToReturn;
                }
            }
            catch (Exception ex)
            {
                throw new WebFaultException<Error>(new Error("Unexpected Exception", ex.Message), System.Net.HttpStatusCode.InternalServerError);
            }
        }

        public Customer GetCustomer(string search)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                IQueryable<Models.Customer> customerQuery = null;
                // Try parsing search string as every property of customer.
                int custId = 0;
                if (int.TryParse(search, out custId))
                {
                    customerQuery = context.Customers.Where(o => o.custID == custId);
                }

                var fetchedCustomer = customerQuery.FirstOrDefault();
                if (fetchedCustomer != null)
                {
                    return new Customer(fetchedCustomer); 
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Customer not found", "Customer with ID " + search + " not found."), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        public void AddCustomer(Customer customer)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                context.Customers.Add(customer.GenerateDbModel());
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedCustomerToUpdate = context.Customers.Where(o => o.custID == customer.custID).FirstOrDefault();
                if (fetchedCustomerToUpdate != null)
                {
                    fetchedCustomerToUpdate.firstName = customer.firstName;
                    fetchedCustomerToUpdate.lastName = customer.lastName;
                    fetchedCustomerToUpdate.phoneNumber = customer.phoneNumber;
                    context.SaveChanges(); 
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Customer with ID " + customer.custID + " not found.", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        public void DeleteCustomer(string id)
        {
            int customerWithIdToDelete = 0;
            if (int.TryParse(id, out customerWithIdToDelete))
            {
                using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
                {
                    var fetchedCustomerToDelete = context.Customers.Where(o => o.custID == customerWithIdToDelete).FirstOrDefault();
                    if (fetchedCustomerToDelete != null)
                    {
                        context.Customers.Remove(fetchedCustomerToDelete);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new WebFaultException<Error>(new Error("Customer with ID " + id + " not found.", ""), System.Net.HttpStatusCode.NotFound);
                    }
                }
            }
        }

	    #endregion
        #region | Products |

        public IList<Product> GetProductList()
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedProducts = context.Products;
                var productList = new List<Product>();
                foreach (var c in fetchedProducts)
                {
                    productList.Add(new Product(c));
                }

                return productList;
            }
        }

        public Product GetProducts(string search)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                IQueryable<Models.Product> productQuery = null;
                // Try parsing search string as every property of customer.
                int prodId = 0;
                if (int.TryParse(search, out prodId))
                {
                    productQuery = context.Products.Where(o => o.prodID == prodId);
                }
                else
                {
                    productQuery = context.Products.Where(o => o.prodName == search);
                }

                var fetchedProduct = productQuery.FirstOrDefault();
                if (fetchedProduct != null)
                {
                    return new Product(fetchedProduct);
                }
                else
                {
                    return null;
                }
            }
        }

        public void AddProduct(Product product)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                context.Products.Add(product.GenerateDbModel());
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedProductToUpdate = context.Products.Where(o => o.prodID == product.prodID).FirstOrDefault();
                if (fetchedProductToUpdate != null)
                {
                    fetchedProductToUpdate.prodName = product.prodName;
                    fetchedProductToUpdate.price = product.price;
                    fetchedProductToUpdate.prodWeight = product.prodWeight;
                    fetchedProductToUpdate.inStock = product.inStock;
                    context.SaveChanges();
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Product with ID " + product.prodID + " not found.", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        public void DeleteProduct(string id)
        {
            int productWithIdToDelete = 0;
            if (int.TryParse(id, out productWithIdToDelete))
            {
                using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
                {
                    var fetchedProductToDelete = context.Products.Where(o => o.prodID == productWithIdToDelete).FirstOrDefault();
                    if (fetchedProductToDelete != null)
                    {
                        context.Products.Remove(fetchedProductToDelete);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new WebFaultException<Error>(new Error("Product with ID " + id + " not found.", ""), System.Net.HttpStatusCode.NotFound);
                    }
                }
            }
        } 

        #endregion
        #region | Orders |

        public IList<Order> GetOrderList()
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedOrders = context.Orders;
                var orderList = new List<Order>();
                foreach (var o in fetchedOrders)
                {
                    orderList.Add(new Order(o));
                }

                return orderList;
            }
        }

        public Order GetOrder(string search)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                IQueryable<Models.Order> orderQuery = null;
                // Try parsing search string as every property of customer.
                int prodId = 0;
                if (int.TryParse(search, out prodId))
                {
                    orderQuery = context.Orders.Where(o => o.orderID == prodId || o.custID == prodId);
                }
                else
                {
                    // TODO: orderQuery = context.Orders.Where(o => o. == search);
                }

                var fetchedOrder = orderQuery.FirstOrDefault();
                if (fetchedOrder != null)
                {
                    return new Order(fetchedOrder);
                }
                else
                {
                    return null;
                }
            }
        }

        public void AddOrder(Order order)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                context.Orders.Add(order.GenerateDbModel());
                context.SaveChanges();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedOrderToUpdate = context.Orders.Where(o => o.orderID == order.orderID).FirstOrDefault();
                if (fetchedOrderToUpdate != null)
                {
                    fetchedOrderToUpdate.custID = order.custID;
                    fetchedOrderToUpdate.orderDate = order.orderDate;
                    fetchedOrderToUpdate.poNumber = order.poNumber;
                    context.SaveChanges();
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Order with ID " + order.orderID + " not found.", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        public void DeleteOrder(string id)
        {
            int orderWithIdToDelete = 0;
            if (int.TryParse(id, out orderWithIdToDelete))
            {
                using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
                {
                    var fetchedOrderToDelete = context.Orders.Where(o => o.orderID == orderWithIdToDelete).FirstOrDefault();
                    if (fetchedOrderToDelete != null)
                    {
                        context.Orders.Remove(fetchedOrderToDelete);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new WebFaultException<Error>(new Error("Order with ID " + id + " not found.", ""), System.Net.HttpStatusCode.NotFound);
                    }
                }
            }
        } 

        #endregion
        #region | Carts |

        public IList<Cart> GetCartList()
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedCarts = context.Carts;
                var cartList = new List<Cart>();
                foreach (var c in fetchedCarts)
                {
                    cartList.Add(new Cart(c));
                }

                return cartList;
            }
        }

        public Cart GetCart(string search)
        {
            throw new NotImplementedException();
        }

        public void AddCart(Cart cart)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                context.Carts.Add(cart.GenerateDbModel());
                context.SaveChanges();
            }
        }

        public void UpdateCart(Cart cart)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var fetchedCartToUpdate = context.Carts.Where(o => o.orderID == cart.orderID && o.prodID == cart.prodID).FirstOrDefault();
                if (fetchedCartToUpdate != null)
                {
                    fetchedCartToUpdate.quantity = cart.quantity;
                    context.SaveChanges();
                }
                else
                {
                    throw new WebFaultException<Error>(new Error("Cart with order ID " + cart.orderID + " and product ID " + cart.prodID + " not found.", ""), System.Net.HttpStatusCode.NotFound);
                }
            }
        }

        public void DeleteCart(string orderId, string prodId)
        {
            int orderIdToDelete = 0;
            int prodIdToDelete = 0;
            if (int.TryParse(orderId, out orderIdToDelete) && int.TryParse(prodId, out prodIdToDelete))
            {
                using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
                {
                    var fetchedCartToDelete = context.Carts.Where(o => o.orderID == orderIdToDelete && o.prodID == prodIdToDelete).FirstOrDefault();
                    if (fetchedCartToDelete != null)
                    {
                        context.Carts.Remove(fetchedCartToDelete);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new WebFaultException<Error>(new Error("Cart with order ID " + orderId + " and product ID " + prodId + " not found.", ""), System.Net.HttpStatusCode.NotFound);
                    }
                }
            }
        } 

        #endregion
    }
}
