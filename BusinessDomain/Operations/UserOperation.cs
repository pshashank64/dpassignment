using NagarroTraining.MVC.DataLayer;
using NagarroTraining.MVC.DataLayer.CustomExceptionHandler;
using NagarroTraining.MVC.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NagarroTraining.MVC.BusinessDomain.Operations
{
    /// <summary>
    /// this function is used for user addition and validation purposes
    /// </summary>
    public class UserOperation
    {
        Logger Log = new Logger();

        private BookEventContext db;

        public UserOperation()
        {
            db = new BookEventContext();
        }

        public bool AddUser(User us)
        {
            try
            {
                var SpecialSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if (us == null || us.UserPassword.Length < 5 || !SpecialSymbols.IsMatch(us.UserPassword))
                {
                    return false;
                }
                db.Users.Add(us);
                db.SaveChanges();
                return true;
            }
            catch(Exception Ex)
            {
                Log.Warning("Unable to add the user!" +Ex);
                return false;
            }
            
        }

        // Function TO List All the User
        public List<User> GetUser()
        {
            try
            {
                var output = db.Users.ToList();
                return output;
            }
            catch(Exception Ex)
            {
                Log.Information("Unable to fetch the users!" + Ex);
                return null;
            }
            
        }

        // Function To List all user Id and Name
        public string[] UserIds(int userId)
        {

            var output = db.Users.Where(d => d.UserId != userId).ToList();
            string[] listUser = new string[2 * output.Count];
            var i = 0;
            foreach (var user in output)
            {
                // System.Diagnostics.Debug.WriteLine(user.UserName);
                listUser[i] = "" + user.UserId;
                listUser[i + 1] = user.UserName;
                i = i + 2;
            }
            return listUser;
        }

        // Function To Check ID and Password
        public int CheckUser(string useremail, string password)
        {
            try
            {
                int userId = 0;
                if (useremail == null && useremail == "" && password == null && password == "")
                {
                    return 0;
                }
                var userData = db.Users.ToList().Where(d => d.UserEmail == useremail && d.UserPassword == password);

                foreach (var item in userData)
                {
                    userId = item.UserId;

                }

                if (userData != null)
                {
                    return userId;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception Ex)
            {
                Log.Warning("Unable to chack the user!" + Ex);
                return 0;
            }
            
        }

        // Function to Get the User Role
        public string GetRole(int userId)
        {
            var result = db.Users.Single(d => d.UserId == userId);
            return result.UserRole;
        }

        public IEnumerable<User> GetUserData()
        {
            var output = db.Users.ToList().Where(d => d.UserRole == "U");
            return output;
        }

        // Function To get the Invited User
        public void AlreadyInvited(int eventId)
        {
            InvitationOperations inv = new InvitationOperations();
            var output = db.Invitations.ToList().Where(d => d.EventId == eventId);
        }
    }
}
