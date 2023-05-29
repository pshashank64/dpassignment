using NagarroTraining.MVC.DataLayer;
using NagarroTraining.MVC.DataLayer.EntityModel;
using System.Collections.Generic;
using System.Linq;

namespace NagarroTraining.MVC.BusinessDomain.Operations
{
    /// <summary>
    /// this function is used to perform various invitation for book events
    /// </summary>
    public class InvitationOperations
    {

        private BookEventContext db;

        public InvitationOperations()
        {
            db = new BookEventContext();
        }

        public bool AddInvitation(Invitation invitation)
        {
            db.Invitations.Add(invitation);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Invitation> GetInvitation(int userId)
        {
            var output = db.Invitations.ToList().Where(d => d.UserId == userId);
            return output;
        }

        // Function To Invite the User
        public bool InviteUser(int eventId, int[] userId)
        {

            Invitation invitation = new Invitation();

            for (int i = 0; i < userId.Length; i++)
            {
                invitation.EventId = eventId;
                invitation.UserId = userId[i];
                invitation.InvitationActive = 1;

                db.Invitations.Add(invitation);
                db.SaveChanges();
            }
            return true;
        }
        public int TotalInventiations(int id)
        {
            var output = db.Invitations.Count(d => d.UserId == id);

            return output;
        }

    }
}
