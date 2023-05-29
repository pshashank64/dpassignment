using NagarroTraining.MVC.DataLayer.EntityModel;
using System.Collections.Generic;

namespace NagarroTraining.MVC.BusinessDomain.Operations
{
    /// <summary>
    /// Implementation of facade for all the operations of events, invitations and users
    /// </summary>
    public class OperationFacade
    {
        private EventOperations _eventOperations;
        private InvitationOperations _invitationOperations;
        private UserOperation _userOperation;

        public OperationFacade()
        {
            _eventOperations = new EventOperations();
            _invitationOperations = new InvitationOperations();
            _userOperation = new UserOperation();
        }

        public bool AddEvents(Event events)
        {
            return _eventOperations.AddEvents(events);
        }

        public List<Event> GetEvents()
        {
            return _eventOperations.GetEvents();
        }

        public bool EditEvents(Event ev, int userId)
        {
            return _eventOperations.EditEvents(ev, userId);
        }

        public Event GetEventDetails(int id)
        {
            return _eventOperations.GetEventDetails(id);
        }

        public bool DeleteEvent(int id)
        {
            return _eventOperations.DeleteEvent(id);
        }

        public IEnumerable<Event> GetCreatedEvent(int userId)
        {
            return _eventOperations.GetCreatedEvent(userId);
        }

        public List<Event> GetInvitedEvent()
        {
            return _eventOperations.GetInvitedEvent();
        }

        public IEnumerable<Event> GetPublicEvent()
        {
            return _eventOperations.GetPublicEvent();
        }

        public bool AddInvitation(Invitation invitation)
        {
            return _invitationOperations.AddInvitation(invitation);
        }

        public IEnumerable<Invitation> GetInvitation(int userId)
        {
            return _invitationOperations.GetInvitation(userId);
        }

        public bool InviteUser(int eventId, int[] userId)
        {
            return _invitationOperations.InviteUser(eventId, userId);
        }

        public int TotalInventiations(int id)
        {
            return _invitationOperations.TotalInventiations(id);
        }

        public bool AddUser(User us)
        {
            return _userOperation.AddUser(us);
        }

        public List<User> GetUser()
        {
            return _userOperation.GetUser();
        }

        public string[] UserIds(int userId)
        {
            return _userOperation.UserIds(userId);
        }

        public int CheckUser(string useremail, string password)
        {
            return _userOperation.CheckUser(useremail, password);
        }

        public string GetRole(int userId)
        {
            return _userOperation.GetRole(userId);
        }

        public IEnumerable<User> GetUserData()
        {
            return _userOperation.GetUserData();
        }

        public void AlreadyInvited(int eventId)
        {
            _userOperation.AlreadyInvited(eventId);
        }


    }
}
