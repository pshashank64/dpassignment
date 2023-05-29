using NagarroTraining.MVC.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace NagarroTraining.MVC.DataLayer.Migrations
{
    /// <summary>
    /// sealed class to prevent inheritence and adding configuations for the admin and validating them
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.BookEventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataLayer.BookEventContext context)
        {

            var users = new List<User>
            {
                new User{ UserName = "Shashank Pandey", UserEmail = "myadmin@bookevents.com", UserPassword = "admin@123", UserRole = "A", },
                new User { UserName = "User", UserEmail = "user@gmail.com", UserPassword = "user@123", UserRole = "U", }
            };

            users.ForEach(s => context.Users.AddOrUpdate(p => p.UserEmail, s));
            context.SaveChanges();

            var events = new List<Event> {
                new Event
                {
                    EventName = "Republic Day", EventDate = DateTime.Parse("2020-01-26"), EventLocation = "Delhi",
                    EventStartTime = "12:00", EventType = 2, EventDuration = 4, EventDescription = "Consititutions Dya",
                    EventOtherDetails = "26 Jan ", UserId = 1, EventActive = 1,
                }
            };

            events.ForEach(s => context.Events.AddOrUpdate(p => p.EventName, s));
            context.SaveChanges();

            var invitations = new List<Invitation> {
                new Invitation{ InvitationActive = 1, EventId = 1, UserId = 2}
            };
            invitations.ForEach(s => context.Invitations.AddOrUpdate(s));
            context.SaveChanges();

            var comment = new List<Comment> {
                new Comment{ UserComment = "Nice Event", UserId = 2, EventId = 1}
            };

            comment.ForEach(s => context.Comments.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
