using NagarroTraining.MVC.DataLayer.EntityModel;
using System.Data.Entity;

namespace NagarroTraining.MVC.DataLayer
{
    /// <summary>
    /// for creation and management of db context of the application for performing CRUD operations
    /// </summary>
    public class BookEventContext: DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
