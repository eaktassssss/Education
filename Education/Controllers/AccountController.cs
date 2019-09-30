using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Education.Models.Context;
using Education.Models.Dto.Account;

namespace Education.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            try
            {
                using (var context =new EducationContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(viewModel);
                    }

                    var user = context.Users.FirstOrDefault(x => x.UserName.Trim().ToLower() == viewModel.UserName.Trim().ToLower() && x.Password.Trim().ToLower() == viewModel.Password.Trim().ToLower());
                    if (user!=null)
                    {
                       FormsAuthentication.SetAuthCookie(user.UserName,true);
                       return RedirectToAction("Index", "Education");
                    }
                    else
                    {
                        ModelState.AddModelError("Error","Kullanıcı adı veya parola hatalı");
                    }
                }
                return View(viewModel);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}