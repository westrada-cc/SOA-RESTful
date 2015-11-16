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
        #region | Customers |

        [OperationContract]
        [WebGet(UriTemplate = "Customers/"), Description("Returns information about all customers.")]
        IList<Customer> GetCustomerList();

        [OperationContract]
        [WebGet(UriTemplate = "Customers/{search}"), Description("Returns information about specific customer depending on the search string. If multiple customers are found only the first one is returned.")]
        Customer GetCustomer(string search);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Customers/"), Description("Add a new customer.")]
        void AddCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Customers/"), Description("Update existing customer.")]
        void UpdateCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Customers/{id}"), Description("Delete existing customer.")]
        void DeleteCustomer(string id); 

        #endregion
        #region | Products |

        [OperationContract]
        [WebGet(UriTemplate = "Products/"), Description("Returns information about all products.")]
        IList<Product> GetProductList();

        [OperationContract]
        [WebGet(UriTemplate = "Products/{search}"), Description("Returns information about specific products depending on the search string. If multiple products are found only the first one is returned.")]
        Product GetProducts(string search);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Products/"), Description("Add a new products.")]
        void AddProduct(Product product);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Products/"), Description("Update existing products.")]
        void UpdateProduct(Product product);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Products/{id}"), Description("Delete existing products.")]
        void DeleteProduct(string id); 

        #endregion
        #region | Orders |

        [OperationContract]
        [WebGet(UriTemplate = "Orders/"), Description("Returns information about all Orders.")]
        IList<Order> GetOrderList();

        [OperationContract]
        [WebGet(UriTemplate = "Orders/{search}"), Description("Returns information about specific Order depending on the search string. If multiple Orders are found only the first one is Order.")]
        Order GetOrder(string search);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Orders/"), Description("Add a new Order.")]
        void AddOrder(Order order);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Orders/"), Description("Update existing Order.")]
        void UpdateOrder(Order order);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Orders/{id}"), Description("Delete existing Order.")]
        void DeleteOrder(string id);

        #endregion
        #region | Carts |

        [OperationContract]
        [WebGet(UriTemplate = "Carts/"), Description("Returns information about all Carts.")]
        IList<Cart> GetCartList();

        [OperationContract]
        [WebGet(UriTemplate = "Carts/{search}"), Description("Returns information about specific Cart depending on the search string. If multiple Carts are found only the first one is returned.")]
        Cart GetCart(string search);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Carts/"), Description("Add a new Cart.")]
        void AddCart(Cart cart);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Carts/"), Description("Update existing Cart.")]
        void UpdateCart(Cart cart);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Carts/{id}"), Description("Delete existing Cart.")]
        void DeleteCart(string id);

        #endregion

    }
    
}
