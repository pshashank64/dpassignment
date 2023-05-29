using NagarroTraining.MVC.BusinessDomain.Operations;
using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.Controllers
{
    /// <summary>
    /// verification of logged in user and fetching the user role
    /// </summary>
    public class CreatedEntrySingleton : Controller
    {
        private static CreatedEntrySingleton CreatedEntry;

        public CreatedEntrySingleton() { }

        public static CreatedEntrySingleton GetInstance()
        {
            if(CreatedEntry == null)
            {
                CreatedEntry = new CreatedEntrySingleton();
            }
            return CreatedEntry;
        }

        public bool CheckLoginUser()
        {
            int userId = (int)System.Web.HttpContext.Current.Session["userId"];

            if (userId > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckLogged()
        {
            bool loggedUserId = CheckLoginUser();
            if (loggedUserId)
            {
                
            }
            else
            {
                
                RedirectLogin();
            }
        }

        public ActionResult RedirectLogin()
        {
            
            return RedirectToAction("Login", "Authentication", "Security");
            
        }

        public int LoggedUserId()
        {

            var log = CheckLoginUser();
            int userId = 0;
            if (log)
            {
                userId = (int)System.Web.HttpContext.Current.Session["userId"];
            }

            return userId;
        }

        public string GetUserRole(int userId)
        {
            UserOperation UserOperations = new UserOperation();
            var role = UserOperations.GetRole(userId);
            return role;
        }
    }
}