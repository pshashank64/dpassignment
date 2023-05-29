using NagarroTraining.MVC.BusinessDomain.EventAbstractFactory;
using NagarroTraining.MVC.BusinessDomain.Operations;
using NagarroTraining.MVC.UserInterfaceBookEvent.IBookEventRepository;
using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.BookEvent.Common.Controllers
{
    /// <summary>
    /// home controller to define and view the index page
    /// </summary>
    public class HomeController : Controller, IHomeRepository
    {
        private IEventAbstract EventAbstract;

        public HomeController()
        {
            EventAbstract = new EventOperationsFactory();
        }

        // GET: Common/Home
        public ActionResult Index()
        {
            EventOperations eventOperations = EventAbstract.CreateEventOperations();
            Session["userId"] = 0;
            var output = eventOperations.GetPublicEvent();

            return View(output);
        }
    }
}