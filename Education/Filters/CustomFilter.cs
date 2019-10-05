using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Education.Filters
{
    public class CustomFilter:FilterAttribute,IAuthenticationFilter,IAuthorizationFilter,IActionFilter,IResultFilter,IExceptionFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            /*
            * Kullanıcın authenticad olmuş mu
            */
            Debug.WriteLine("OnAuthentication");
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            /*
           * Olmamışsa şunu yap
           */
            Debug.WriteLine("OnAuthenticationChallenge");
        }


        public void OnAuthorization(AuthorizationContext filterContext)
        {
             
            /*
             * Kullanıcın yetkisi var mı 
             */
            Debug.WriteLine("OnAuthorization");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /*
             * Metod çalışmadan önce
             */
            Debug.WriteLine("OnActionExecuting");
        }
      

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            /*
             * Metod çalıştıktan  sonra
             */
            Debug.WriteLine("OnActionExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        { /*
             * Kullanıcıya bir  sonuç döndükten önce çalışır
             */
            Debug.WriteLine("OnResultExecuting");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            /*
             * Kullanıcıya bir  sonuç döndükten sonra çalışır
             */
            Debug.WriteLine("OnResultExecuted");
        }

        public void OnException(ExceptionContext filterContext)
        {
            /*
             * Bir hata oluştuğu zaman çalışır
             */
            Debug.WriteLine("OnException");
        }
    }
}