using NagarroTraining.MVC.DataLayer.EntityModel;
using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent.IBookEventRepository
{
    public interface IUserRepository
    {
        ActionResult Index();
        ActionResult Create(Event events);
        ActionResult Edit(int id);
        ActionResult UpdateEvent(Event ev);
        ActionResult Invite(int id);
        ActionResult InviteUser();
        ActionResult ViewMyEvent();
        ActionResult PublicEvents();
        ActionResult ViewPublicDetail(int id);
        ActionResult UpcomingEvents();
        ActionResult PastEvents();
        ActionResult Delete(int id);
        ActionResult DeleteEvent(int id);
        ActionResult Invitations();

    }
}
