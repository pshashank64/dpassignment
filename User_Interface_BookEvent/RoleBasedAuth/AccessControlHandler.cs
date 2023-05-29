using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NagarroTraining.MVC.DataLayer;
using NagarroTraining.MVC.UserInterfaceBookEvent.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace UserInterfaceBookEvent.RoleBasedAuth
{
    /// <summary>
    /// Get and filter the roles to differentiate as admin or the user
    /// </summary>
    public class AccessControlHandler : System.Web.Mvc.IAuthorizationFilter
    {
        private BookEventContext db = new BookEventContext();
        private CreatedEntrySingleton CreateEntry = new CreatedEntrySingleton();
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userRole = GetCurrentUserRole(); // logic to retrieve current user's role
            var actionAttributes = context.ActionDescriptor.EndpointMetadata
                                        .OfType<AccessControlAttribute>();

            if (actionAttributes.Any() && !actionAttributes.Any(a => a.RoleGroup == userRole))
            {
                context.Result = new ForbidResult(); // user is not authorized for this action
            }
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            throw new NotImplementedException();
        }

        private string GetCurrentUserRole()
        {
            // logic to retrieve current user's role
            string userRole = CreateEntry.GetUserRole(CreateEntry.LoggedUserId());
            return userRole;
        }
    }

}