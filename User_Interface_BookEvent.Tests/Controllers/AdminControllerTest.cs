using Microsoft.VisualStudio.TestTools.UnitTesting;
using NagarroTraining.MVC.UserInterfaceBookEvent.BookEvent.Admin.Controllers;
using System.Web.Mvc;

namespace Nagarrotraining.MVC.UserInterfaceBookEvent.Tests.Controllers
{
    /// <summary>
    /// test class method for admin to fetch all users and all events
    /// </summary>
    [TestClass]
    public class AdminControllerTest
    {

        [TestMethod]
        public void AllUsers()
        {
            // Arrange
            AdminController controller = new AdminController();
            string viewName = "AllUsers";

            // Act
            ViewResult result = controller.AllUsers() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void AllEvents()
        {
            // Arrange
            AdminController controller = new AdminController();
            string viewName = "AllEvents";

            // Act
            ViewResult result = controller.AllEvents() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }
    }
}
