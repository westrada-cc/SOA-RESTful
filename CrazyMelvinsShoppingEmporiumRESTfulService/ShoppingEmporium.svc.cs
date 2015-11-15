using System;
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
        #region | Customers |

        public IList<Customer> GetCustomerList()
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var customerList = context.Customers;
                var customersToReturn = new List<Customer>();
                foreach (var c in customerList)
                {
                    var customerToReturn = new Customer()
                    {
                        custID = c.custID,
                        firstName = c.firstName,
                        lastName = c.lastName,
                        phoneNumber = c.phoneNumber
                    };
                    customersToReturn.Add(customerToReturn);
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
                else
                {
                    customerQuery = context.Customers.Where(o => o.lastName == search || o.firstName == search || o.phoneNumber == search);
                }

                var fetchedCustomer = customerQuery.FirstOrDefault();
                if (fetchedCustomer != null)
                {
                    var customerToReturn = new Customer()
                    {
                        custID = fetchedCustomer.custID,
                        firstName = fetchedCustomer.firstName,
                        lastName = fetchedCustomer.lastName,
                        phoneNumber = fetchedCustomer.phoneNumber
                    };
                    return customerToReturn; 
                }
                else
                {
                    return null;
                }
            }
        }

        public void AddCustomer(Customer customer)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var customerToAdd = new Models.Customer()
                {
                    firstName = customer.firstName,
                    lastName = customer.firstName,
                    phoneNumber = customer.phoneNumber
                
                };
                context.Customers.Add(customerToAdd);
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
                }
            }
        }

	    #endregion
        #region | Products |

        public IList<Product> GetProductList()
        {
            throw new NotImplementedException();
        }

        public Product GetProducts(string search)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(string id)
        {
            throw new NotImplementedException();
        } 

        #endregion
        #region | Orders |

        public IList<Order> GetOrderList()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(string search)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(string id)
        {
            throw new NotImplementedException();
        } 

        #endregion
        #region | Carts |

        public IList<Cart> GetCartList()
        {
            throw new NotImplementedException();
        }

        public Cart GetCart(string search)
        {
            throw new NotImplementedException();
        }

        public void AddCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public void UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public void DeleteCart(string id)
        {
            throw new NotImplementedException();
        } 

        #endregion
    }
}
