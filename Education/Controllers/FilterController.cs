using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Filters;

namespace Education.Controllers
{
    [CustomAuthenticationFilter]
    [CustomFilterA]
    public class FilterController : Controller
    {
        [CustomFilter]
        public string Index()
        {
            Debug.WriteLine("Action Executed");
            return "Filter";
        }
        [CustomFilterA]
        public string Index2()
        {
            return "Filter2";
        }


        /*
         *
         * Filterlar 3 seviyede kullanılır. Controller ,Action , Global
         * Aynı tipteki aynı  filter (AuthanticationFilter)  bu üç seviyede aynı anda kullanılırsa en içteki  çalışır 
         *Action
         *Controller
         *Global
         *Burada order kullnılsa bile sonuç değişmez
         */

        /*
         *
         *  
         *Farklı tipteki farklı  filter (AuthanticationFilter,Authorization)  bu üç seviyede aynı anda kullanılırsa en dıştan başlar
         *Global
         *Controller
         * Action
         *Burada ise order kullanımında çalışma sırası belirleyebiliriz
         */

    }
}