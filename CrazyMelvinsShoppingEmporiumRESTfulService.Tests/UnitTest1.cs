using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyMelvinsShoppingEmporiumRESTfulService.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new ShoppingEmporiumService.ShoppingEmporiumClient();
            service.AddCustomer(new ShoppingEmporiumService.Customer() 
            { 
                custID = 3, firstName = "Stefan", lastName = "Vas", phoneNumber = "124243" 
            });
            
        }
    }
}
