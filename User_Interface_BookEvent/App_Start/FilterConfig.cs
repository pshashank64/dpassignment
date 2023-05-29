using System.Web.Mvc;

namespace NagarroTraining.MVC.UserInterfaceBookEvent
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
