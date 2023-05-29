using NagarroTraining.MVC.BusinessDomain.EventAbstractFactory;
using NagarroTraining.MVC.BusinessDomain.Operations;
using NagarroTraining.MVC.UserInterfaceBookEvent.Controllers;
using NagarroTraining.MVC.UserInterfaceBookEvent.IBookEventRepository;
using System.Web.Mvc;
using UserInterfaceBookEvent.RoleBasedAuth;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.BookEvent.Admin.Controllers
{
    /// <summary>
    /// this controller is used to define the operations for the admin
    /// </summary>
    public class AdminController : Controller, IAdminRepository
    {

        private CreatedEntrySingleton CreateEntry;
        private OperationFacade OperationFacade;
        private IEventAbstract EventAbstract;


        public AdminController()
        {
            CreateEntry = new CreatedEntrySingleton();
            OperationFacade = new OperationFacade();
            EventAbstract = new EventOperationsFactory();
        }

        /// <summary>
        /// Used ROle Based Auth 
        /// </summary>
        /// <returns>View</returns>
        
        [AccessControl(RoleGroup = "A")]
        public ActionResult AllUsers()
        {
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }

            var output = OperationFacade.GetUserData();
            return View(output);

        }

        [AccessControl(RoleGroup = "A")]
        public ActionResult AllEvents()
        {
            EventOperations eventOperations = EventAbstract.CreateEventOperations();
            var test = CreateEntry.CheckLoginUser();
            if (!test)
            {
                return Redirect("/Security/Authentication/Login");
            }
            var output = eventOperations.GetEvents();
            return View(output);
        }
    }
}