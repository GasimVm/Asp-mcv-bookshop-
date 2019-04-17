using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;

namespace BookRead.AdminAtuhen
{
    public class AdminAnthunetion : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)) return;



            if (HttpContext.Current.Session["admin"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Admin/Index");
            }
        }
    }
}