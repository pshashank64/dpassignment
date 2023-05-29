using System;

namespace UserInterfaceBookEvent.RoleBasedAuth
{
    /// <summary>
    /// Defines the role attribute 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AccessControlAttribute : Attribute
    {
        public string RoleGroup { get; set; }
    }

}