using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.IBookEventRepository
{
    public interface ISecurityRepository
    {
        ActionResult Login();
        ActionResult Validate();
        ActionResult Register();
        ActionResult Registeration();
        ActionResult Home();
        ActionResult Logout();
    }
}
