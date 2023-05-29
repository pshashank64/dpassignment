using Microsoft.VisualStudio.TestTools.UnitTesting;
using NagarroTraining.MVC.UserInterfaceBookEvent.BookEvent.Common.Controllers;
using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.Tests.Controllers
{
    [TestClass]
    class HomeControllerTest
    {

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            string viewName = "Index";

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }
    }
}
