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
        public Customer GetCustomer(string id)
        {
            var custId = int.Parse(id);
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                var customer = context.Customers.Where(o => o.custID == custId).FirstOrDefault();
                var customerToReturn = new Customer()
                {
                    custID = customer.custID,
                    firstName = customer.firstName,
                    lastName = customer.lastName,
                    phoneNumber = customer.phoneNumber
                };
                return customerToReturn;
            }
        }

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

        public void AddCustomer(Customer customer)
        {
            using (var context = new Models.CrazyMelvinsShoppingEmporiumDbEntities())
            {
                //context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }


        public void DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }
    }
}
