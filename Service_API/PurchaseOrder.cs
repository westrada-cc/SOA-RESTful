using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service_API
{
    public class PurchaseOrder
    {
        public Customer Customer { get; set; }

        public Order Order { get; set; }

        public List<OrderedProduct> OrderedProducts { get; set; }

        public double SubTotal
        {
            get;
            //{
            //    double subTotal = 0;

            //    if (this.OrderedProducts != null && this.OrderedProducts.Count > 0)
            //    {
            //        foreach (var orderedProduct in this.OrderedProducts)
            //        {
            //            // We can only sell product that are in stock.
            //            if (orderedProduct.Product.inStock)
            //            {
            //                subTotal += orderedProduct.Product.price * orderedProduct.quantity;
            //            }
            //        }
            //    }

            //    return subTotal;
            //}
            set; //{ /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }

        public double Tax
        {
            get;
            //{
            //    return this.SubTotal * 0.13;
            //}
            set; //{ /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }

        public double Total
        {
            get;
            //{
            //    return this.SubTotal + this.Tax;
            //}
            set; //{ /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }

        public int TotalQuanity
        {
            get;
            //{
            //    int toatlQuantity = 0;

            //    if (this.OrderedProducts != null && this.OrderedProducts.Count > 0)
            //    {
            //        foreach (var orderedProduct in this.OrderedProducts)
            //        {
            //            // We can only sell product that are in stock.
            //            if (orderedProduct.Product.inStock)
            //            {
            //                toatlQuantity += orderedProduct.quantity;
            //            }
            //        }
            //    }

            //    return toatlQuantity;
            //}
            set; //{ /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }

        public double TotalWeight
        {
            get;
            //{
            //    double totalWeight = 0;

            //    if (this.OrderedProducts != null && this.OrderedProducts.Count > 0)
            //    {
            //        foreach (var orderedProduct in this.OrderedProducts)
            //        {
            //            // We can only sell product that are in stock.
            //            if (orderedProduct.Product.inStock)
            //            {
            //                totalWeight += orderedProduct.Product.prodWeight;
            //            }
            //        }
            //    }

            //    return totalWeight;
            //}
            set; //{ /* This Property is read-only. We need set in order to satisfy the DataContract serializer. */ }
        }
    }

    public class OrderedProduct
    {
        public Product Product { get; set; }

        public int quantity { get; set; }
    }
}