using NagarroTraining.MVC.BusinessDomain.Operations;
using NagarroTraining.MVC.DataLayer.EntityModel;
using NagarroTraining.MVC.UserInterfaceBookEvent.Controllers;
using NagarroTraining.MVC.UserInterfaceBookEvent.IBookEventRepository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.BookEvent.User.Controllers
{
    /// <summary>
    /// this controller is used for validation of users and then managing the events
    /// </summary>
    public class EventsController : Controller, IUserRepository
    {

        private bool result = false;

        private OperationFacade OperationFacade;
        private CreatedEntrySingleton CreateEntry;

        public EventsController()
        {
            OperationFacade = new OperationFacade();
            CreateEntry = new CreatedEntrySingleton();
        }

        // GET: User/Events
        public ActionResult Index()
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Event events)
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }

            events.UserId = CreateEntry.LoggedUserId();

            result = OperationFacade.AddEvents(events);

            return RedirectToAction("Index");
        }

        // Function To View Edit Form of Event
        public ActionResult Edit(int id)
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }

            if (id == 0)
            {
                return HttpNotFound();
            }
            var output = OperationFacade.GetEventDetails(id);
            return View(output);
        }

        // Function To Edit the Event
        public ActionResult UpdateEvent(Event ev)
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }

            OperationFacade.EditEvents(ev, CreateEntry.LoggedUserId());

            return Redirect("/User/Events/Index");
        }

        // Function TO View Invitation Form
        public ActionResult Invite(int id)
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }
            var output = OperationFacade.GetEventDetails(id);
            ViewBag.eventId = id;
            ViewBag.userlist = OperationFacade.UserIds(CreateEntry.LoggedUserId());
            return View(output);
        }

        // Function To Invite Registered User
        public ActionResult InviteUser()
        {
            string userId = Request.Form["userId"];
            string eventId = Request.Form["eventId"];
            char[] spearator = { ',', ' ' };
            string[] userIds = userId.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            System.Diagnostics.Debug.WriteLine(userId.Length);
            System.Diagnostics.Debug.WriteLine(userId);

            OperationFacade.InviteUser(Int32.Parse(eventId), Array.ConvertAll(userIds, int.Parse));
            return Redirect("/User/Events/ViewMyEvent");
        }

        // Function To Event Created By User
        public ActionResult ViewMyEvent()
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }

            var output = OperationFacade.GetCreatedEvent(CreateEntry.LoggedUserId());

            return View(output);
        }

        // Function To View Public Event
        public ActionResult PublicEvents()
        {
            var output = OperationFacade.GetPublicEvent();
            return View(output);
        }

        // Function To View Event Detail
        public ActionResult ViewPublicDetail(int id)
        {
            ViewBag.Count = OperationFacade.TotalInventiations(id);
            var output = OperationFacade.GetEventDetails(id);
            return View(output);
        }

        // Function To View Upcoming Event
        public ActionResult UpcomingEvents()
        {
            var output = OperationFacade.GetPublicEvent();
            return View(output);
        }

        // Function To View Past Event
        public ActionResult PastEvents()
        {
            var output = OperationFacade.GetPublicEvent();
            return View(output);
        }

        // Function to Show Delete Form of an Event
        public ActionResult Delete(int id)
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }

            var output = OperationFacade.GetEventDetails(id);
            ViewBag.eventid = id;
            return View();
        }

        // Function To Delete An Event
        public ActionResult DeleteEvent(int id)
        {
            bool result = OperationFacade.DeleteEvent(id);
            return Redirect("/User/Events/ViewMyEvent");
        }

        public ActionResult Invitations()
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }
            // System.Diagnostics.Debug.WriteLine(cf.LoggedUserId());
            var userInvitations = OperationFacade.GetInvitation(CreateEntry.LoggedUserId());
            List<Event> getEvent = new List<Event>();
            foreach (var output in userInvitations)
            {
                // System.Diagnostics.Debug.WriteLine(output.EventId);
                getEvent.Add(OperationFacade.GetEventDetails(output.EventId));
            }
            return View(getEvent);
        }
    }
}