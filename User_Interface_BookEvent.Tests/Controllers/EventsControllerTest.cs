﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NagarroTraining.MVC.UserInterfaceBookEvent.BookEvent.User.Controllers;
using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.Tests.Controllers
{
    /// <summary>
    /// to view various types of events
    /// </summary>
    [TestClass]
    class EventsControllerTest
    {

        [TestMethod]
        public void Index()
        {

            // Arrange
            EventsController controller = new EventsController();
            string viewName = "Index";

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void ViewMyEvent()
        {
            // Arrange
            EventsController controller = new EventsController();
            string viewName = "ViewMyEvent";

            // Act
            ViewResult result = controller.ViewMyEvent() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void PublicEvents()
        {
            // Arrange
            EventsController controller = new EventsController();
            string viewName = "PublicEvents";

            // Act
            ViewResult result = controller.PublicEvents() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void UpcomingEvents()
        {
            // Arrange
            EventsController controller = new EventsController();
            string viewName = "UpcomingEvents";

            // Act
            ViewResult result = controller.UpcomingEvents() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void PastEvents()
        {
            // Arrange
            EventsController controller = new EventsController();
            string viewName = "PastEvents";

            // Act
            ViewResult result = controller.PastEvents() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void Invitations()
        {
            // Arrange
            EventsController controller = new EventsController();
            string viewName = "Invitations";

            // Act
            ViewResult result = controller.Invitations() as ViewResult;

            // Assert
            Assert.AreEqual(viewName, result.ViewName);
        }
    }
}
