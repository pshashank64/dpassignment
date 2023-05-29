using NagarroTraining.MVC.DataLayer;
using NagarroTraining.MVC.DataLayer.EntityModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NagarroTraining.MVC.BusinessDomain.Operations
{
    /// <summary>
    /// This function is used to perform various book event operations
    /// </summary>
    public class EventOperations
    {  
        private BookEventContext db;

        public EventOperations()
        {
            db = new BookEventContext();
        }

        // Function To Create Event
        public bool AddEvents(Event events)
        {
            if (events == null)
            {
                return false;
            }

            if (events.EventDate == null || events.EventDescription == null || events.EventLocation == null ||
                events.EventName == null || events.EventOtherDetails == null || events.EventStartTime == null || events.EventDuration>4)
            {
                return false;
            }

            db.Events.Add(events);
            db.SaveChanges();
            // ModelState.Clear();
            return true;
        }

        // Function To List All the Evevt Created By User
        public List<Event> GetEvents()
        {
            var output = db.Events.ToList();
            return output;
        }

        // Function To Update The Event By Event ID
        public bool EditEvents(Event ev, int userId)
        {
            ev.UserId = userId;
            db.Entry(ev).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // Functio TO Get Event Detail By Event Id
        public Event GetEventDetails(int id)
        {
            var output = db.Events.Single(x => x.EventId == id);
            return output;
        }

        // Function To Remove Event
        public bool DeleteEvent(int id)
        {
            var output = db.Events.Single(x => x.EventId == id);
            if (output == null)
            {
                return false;
            }

            db.Events.Remove(output);
            db.SaveChanges();

            InvitationOperations inv = new InvitationOperations();
            var outputs = db.Invitations.Where(d => d.EventId == id);
            foreach (var x in outputs)
            {
                db.Invitations.Remove(x);
            }

            return true;
        }

        // Get All Event For Logged User
        public IEnumerable<Event> GetCreatedEvent(int userId)
        {

            var output = GetEvents().Where(d => d.UserId == userId);

            return output;
        }

        // Function To List All Invited Event
        public List<Event> GetInvitedEvent()
        {
            var output = db.Events.ToList();
            return output;
        }

        // Function To Find All Public Events
        public IEnumerable<Event> GetPublicEvent()
        {
            var output = GetEvents().Where(d => d.EventType == 2);
            return output;
        }
       
    }
}
