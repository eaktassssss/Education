using System.Web;
using System.Web.Mvc;
using Education.Filters;

namespace Education
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionFilter());
            filters.Add(new CustomFilterA());
        }
    }
}
