using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ComponentModel;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// For help in browser see http://localhost:3745/ShoppingEmporium.svc/HELP
    /// </remarks>
    [ServiceContract]
    public interface IShoppingEmporium
    {
        [OperationContract]
        [WebGet(UriTemplate="Customers/"), Description("Returns information about all customers.")]
        IList<Customer> GetCustomerList();

        [OperationContract]
        [WebGet(UriTemplate = "Customers/{id}"), Description("Returns information about specific customer.")]
        Customer GetCustomer(string id);

        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="Customers/"), Description("Add a new customer.")]
        void AddCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Customers/"), Description("Update existing customer.")]
        void UpdateCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Customers/{id}"), Description("Delete existing customer.")]
        void DeleteCustomer(string id);
    }
    
}
