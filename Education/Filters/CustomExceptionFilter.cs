using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Education.Models.Context;
using Education.Models.Dto.Account;

namespace Education.Filters
{
    public class CustomExceptionFilter:FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            using (var context =new EducationContext())
            {
                var user = HttpContext.Current.Session["LoginUser"] as LoginViewModel;
                var exception = new Log()
                {
                   UserName = user.UserName,ExceptionMessage = filterContext.Exception.Message,CreatedDate = DateTime.Now,
                   ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                   ActionName = filterContext.RouteData.Values["action"].ToString()
                };
                context.Logs.Add(exception);
                context.SaveChanges();

                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error"
                };
            }
        }
    }
}