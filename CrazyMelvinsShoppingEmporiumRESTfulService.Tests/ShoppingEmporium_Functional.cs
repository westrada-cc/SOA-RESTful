using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyMelvinsShoppingEmporiumRESTfulService.Tests
{
    [TestClass]
    public class ShoppingEmporium_Functional
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new ShoppingEmporium();
        }



        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var service = new ShoppingEmporium();
        //    var newCustomer = new Customer()
        //    {
        //        firstName = "Test",
        //        lastName = "Test",
        //        phoneNumber = "555-5555-555"
        //    };
        //    service.AddCustomer(newCustomer);
        //}

        //[TestMethod]
        //public void TestMethod2()
        //{
        //    try
        //    {
        //        var service = new ShoppingEmporium();
        //        var newCustomer = new Customer()
        //        {
        //            firstName = "Test",
        //            lastName = "Test",
        //            phoneNumber = "555-55555-555"
        //        };
        //        service.AddCustomer(newCustomer);
        //        Assert.IsTrue(false);
        //    }
        //    catch
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}

        //[TestMethod]
        //public void TestMethod3()
        //{
        //    try
        //    {
        //        var service = new ShoppingEmporium();
        //        var newCustomer = new Customer()
        //        {
        //            firstName = "Test",
        //            lastName = "Test",
        //            phoneNumber = "5555555555"
        //        };
        //        service.AddCustomer(newCustomer);
        //        Assert.IsTrue(false);
        //    }
        //    catch
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}

        //[TestMethod]
        //public void TestMethod4()
        //{
        //    try
        //    {
        //        var service = new ShoppingEmporium();
        //        var newCustomer = new Customer()
        //        {
        //            firstName = "Test",
        //            lastName = "Test",
        //            phoneNumber = ""
        //        };
        //        service.AddCustomer(newCustomer);
        //        Assert.IsTrue(false);
        //    }
        //    catch
        //    {
        //        Assert.IsTrue(true);
        //    }
        //}
    }
}
