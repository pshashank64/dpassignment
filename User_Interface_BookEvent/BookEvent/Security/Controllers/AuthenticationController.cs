using NagarroTraining.MVC.BusinessDomain.EventAbstractFactory;
using NagarroTraining.MVC.BusinessDomain.Operations;
using NagarroTraining.MVC.UserInterfaceBookEvent.Controllers;
using NagarroTraining.MVC.UserInterfaceBookEvent.IBookEventRepository;
using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.BookEvent.Security.Controllers
{
    /// <summary>
    /// This class is used for validation and management of sessions
    /// </summary>
    public class AuthenticationController : Controller, ISecurityRepository
    {
        private CreatedEntrySingleton CE;
        private OperationFacade OperationFacade;
        private IEventAbstract EventAbstract;

        public AuthenticationController()
        {
            OperationFacade = new OperationFacade();
            EventAbstract = new EventOperationsFactory();
            CE = new CreatedEntrySingleton();
        }

        // GET: Security/Authentication
        public ActionResult Login()
        {   
            return View();
        }

        public ActionResult Validate()
        {

            string UserEmail = Request.Form["UserEmail"];
            string Password = Request.Form["UserPassword"];

            System.Diagnostics.Debug.WriteLine(UserEmail);
            System.Diagnostics.Debug.WriteLine(Password);

            if (UserEmail != null && UserEmail != "" && Password != null && Password != "")
            {

                int UserId = OperationFacade.CheckUser(UserEmail, Password);
                if (UserId != 0)
                {
                    Session["userId"] = UserId;
                    System.Diagnostics.Debug.WriteLine((int)Session["userId"]);
                    return RedirectToAction("Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            Session["userId"] = 0;
            return View();
        }

        public ActionResult Registeration()
        {
            string username = Request.Form["UserName"];
            string useremail = Request.Form["UserEmail"];
            string password = Request.Form["UserPassword"];

            System.Diagnostics.Debug.WriteLine(username);
            System.Diagnostics.Debug.WriteLine(useremail);
            System.Diagnostics.Debug.WriteLine(password);

            if (username == null || username == "" || useremail == null || useremail == "" || password == null || password == "")
            {
                return RedirectToAction("Register");
            }
            DataLayer.EntityModel.User usr = new DataLayer.EntityModel.User();
            usr.UserName = username;
            usr.UserEmail = useremail;
            usr.UserPassword = password;
            usr.UserRole = "U";

            bool result = OperationFacade.AddUser(usr);
            if (result)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }

        public ActionResult Home()
        {
            EventOperations eventOperations = EventAbstract.CreateEventOperations();
            var test = CE.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }
            var output = eventOperations.GetPublicEvent();

            return View(output);
        }

        public ActionResult Logout()
        {

            Session["userId"] = 0;
            return Redirect("/Security/Authentication/Login");
        }
    }
}