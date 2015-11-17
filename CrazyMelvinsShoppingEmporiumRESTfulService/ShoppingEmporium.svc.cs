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
            if (search != null && search.Length > 0 && search.Contains("|"))
            {
                var searchBits = search.Split(new string[] {"|"}, StringSplitOptions.RemoveEmptyEntries);
               
            }

            return null;
        }

        #region | Customers |

        public IList<Customer> GetCustomerList()
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
