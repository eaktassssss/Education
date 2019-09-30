using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Education.Filters
{
    public class CustomAuthenticationFilter:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAuthenticated = filterContext.HttpContext.User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                filterContext.Result=new RedirectToRouteResult(new RouteValueDictionary()
                {
                    {"controller","Account"},
                    {"action","Login" }
                });
            }
        }
    }
}