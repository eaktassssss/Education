using System;
using System.Data.Entity;
using Education.Filters;
using Education.Models.Context;
using Education.Models.Dto.Student;
using System.Linq;
using System.Web.Mvc;

namespace Education.Controllers
{
    [CustomAuthenticationFilter]

    public class EducationController : Controller
    {
        /*
         * Bundle  işlemleri  için Microsoft.AspNet.Optimization kurulması
         */

        [HttpGet]
        
        public ActionResult Index()
        {
            /*
             * LazyLoading , Include ve Select  Yöntemleri üzerine konuş.
             */
            using (var context = new EducationContext())
            {
                var students = context.Students.Where(x=> x.IsDeleted==false).Include("Class").Select(x => new StudentListViewModel()
                {
                     Id = x.Id,LastName = x.LastName,SchoolNumber = x.SchoolNumber, IsDeleted = x.IsDeleted,
                      Name = x.Name,PhoneNumber = x.PhoneNumber,ClassName =x.Class.Name,Email = x.Email,Age = x.Age,
                      CreateDate = x.CreateDate,IdentityNumber = x.IdentityNumber
                }).ToList();
                return View(students);
            }
        }

        [HttpGet]
       
        public ActionResult Add()
        {
            /*
             * Html.BeginForm
             * ViewBag
             * TempData
             * Mvc Html Helper kullanımı
             * Üzerine konuş
             */
            using (var context = new EducationContext())
            {
                ViewBag.studentClasses = context.Classes.ToList();
                TempData["studentClasses"] = context.Classes.ToList();
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(StudentViewModel viewModel)
        {
            /*
             * RouteValueDictionary
             * DatabaseFirst
             */
            try
            {
                using (var context = new EducationContext())
                {
                    TempData["studentClasses"] = context.Classes.ToList();
                    if (!ModelState.IsValid)
                        return View(viewModel);
                    else
                    {
                        var student = new Student()
                        {
                            PhoneNumber = viewModel.PhoneNumber,
                            ClassId = viewModel.ClassId,
                            IdentityNumber = viewModel.IdentityNumber,
                            LastName = viewModel.LastName,
                            Name = viewModel.Name,
                            CreateDate = viewModel.CreateDate,
                            SchoolNumber = viewModel.SchoolNumber,
                            IsDeleted = viewModel.IsDeleted,
                            Age = viewModel.Age,
                            Email = viewModel.Email
                        };
                        context.Students.Add(student);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Education");
                    }
                }
            }
            catch
            {
                return View(viewModel);
            }
        }


        [HttpGet]
        
        public ActionResult Update(int studentId)
        {
            try
            {
                using (var context = new EducationContext())
                {
                    TempData["studentClasses"] = context.Classes.ToList();
                    var student = context.Students.FirstOrDefault(s => s.Id == studentId);
                    if (student == null)
                    {
                        return View("Error");
                    }
                    var model = new StudentViewModel()
                    {
                        PhoneNumber = student.PhoneNumber,
                        ClassId = student.ClassId,
                        IdentityNumber = student.IdentityNumber,
                        LastName = student.LastName,
                        Name = student.Name,
                        SchoolNumber = student.SchoolNumber,
                        Id = student.Id,
                        Age = student.Age,
                        Email = student.Email
                    };
                    return View(model);
                }
            }
            catch
            {
                return View("Error");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(StudentViewModel viewModel)
        {
            try
            {
                using (var context = new EducationContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(viewModel);
                    }

                    var student = context.Students?.FirstOrDefault(s => s.Id == viewModel.Id && s.IsDeleted == false);
                    if (student == null)
                    {
                        return View("Error");
                    }

                    student.PhoneNumber = viewModel.PhoneNumber;
                    student.ClassId = viewModel.ClassId;
                    student.IdentityNumber = viewModel.IdentityNumber;
                    student.LastName = viewModel.LastName;
                    student.Name = viewModel.Name;
                    student.SchoolNumber = viewModel.SchoolNumber;
                    student.Id = viewModel.Id;
                    student.Email = viewModel.Email; student.Age = viewModel.Age;
                    context.SaveChanges();
                    return RedirectToAction("Index", "Education");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int studentId)
        {
            try
            {
                using (var context = new EducationContext())
                {
                    var student = context.Students?.FirstOrDefault(s => s.Id == studentId && s.IsDeleted == false);
                    if (student == null)
                    {
                        return View("Error");
                    }
                    student.IsDeleted = true;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Error");
            }
        }


        [HttpGet]
        public ActionResult ErrorPageTest()
        {
            return View();
        }

        [HttpPost]
        [CustomExceptionFilter]
        public ActionResult ErrorPageTest(int customId)
        { 
                using (var context = new EducationContext())
                {
                    var student = new Student();
                    student.Id = customId;
                    context.Students.Add(student);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
        }

        public PartialViewResult GetPartialViewResult()
        {
            using (var context = new EducationContext())
            {
                var students = context.Students.Where(x => x.IsDeleted == false).Include("Class").Select(x => new StudentListViewModel()
                {
                    Id = x.Id,
                    LastName = x.LastName,
                    SchoolNumber = x.SchoolNumber,
                    IsDeleted = x.IsDeleted,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    ClassName = x.Class.Name,
                    Email = x.Email,
                    Age = x.Age,
                    CreateDate = x.CreateDate,
                    IdentityNumber = x.IdentityNumber
                }).ToList();
                return PartialView("ListPartialView",students);
            }
        }
    }
}