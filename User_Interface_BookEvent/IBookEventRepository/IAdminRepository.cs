using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.IBookEventRepository
{
    public interface IAdminRepository
    {
        ActionResult AllUsers();
        ActionResult AllEvents();
    }
}
