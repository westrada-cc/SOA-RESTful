using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrazyMelvinsShoppingEmporiumRESTfulService
{
    [DataContract]
    public class PurchaseOrder
    {
        [DataMember]
        public Customer Customer { get; set; }

        [DataMember]
        public Order Order { get; set; }

        [DataMember]
        public List<OrderedProduct> OrderedProducts { get; set; }

        [DataMember]
        public double SubTotal
        {
            get
            {
                double subTotal = 0;

                if (this.OrderedProducts != null && this.OrderedProducts.Count > 0)
                {
                    foreach (var orderedProduct in this.OrderedProducts)
                    {
                        // We can only sell product that are in stock.
                        if (orderedProduct.Product.inStock)
                        {
                            subTotal += orderedProduct.Product.price * orderedProduct.quantity;
                        }
                    }
                }

                return subTotal;
            }
            set { /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }

        [DataMember]
        public double Tax
        {
            get
            {
                return this.SubTotal * 0.13;
            }
            set { /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }

        [DataMember]
        public double Total
        {
            get
            {
                return this.SubTotal + this.Tax;
            }
            set { /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }

        [DataMember]
        public int TotalQuanity
        {
            get
            {
                int toatlQuantity = 0;

                if (this.OrderedProducts != null && this.OrderedProducts.Count > 0)
                {
                    foreach (var orderedProduct in this.OrderedProducts)
                    {
                        // We can only sell product that are in stock.
                        if (orderedProduct.Product.inStock)
                        {
                            toatlQuantity += orderedProduct.quantity;
                        }
                    }
                }

                return toatlQuantity;
            }
            set { /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }

        [DataMember]
        public double TotalWeight
        {
            get
            {
                double totalWeight = 0;

                if (this.OrderedProducts != null && this.OrderedProducts.Count > 0)
                {
                    foreach (var orderedProduct in this.OrderedProducts)
                    {
                        // We can only sell product that are in stock.
                        if (orderedProduct.Product.inStock)
                        {
                            totalWeight += orderedProduct.Product.prodWeight;
                        }
                    }
                }

                return totalWeight;
            }
            set { /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }
    }

    [DataContract]
    public class OrderedProduct
    {
        [DataMember]
        public Product Product { get; set; }

        [DataMember]
        public int quantity { get; set; }
    }
}