using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Education.Filters;
using Education.Models.Context;
using Education.Models.Dto.Student;

namespace Education.Controllers
{
    [CustomAuthenticationFilter]
    public class EducationController : Controller
    {
 
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
                      Name = x.Name,PhoneNumber = x.PhoneNumber,ClassName =x.Class.Name,
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
            using (var context =new EducationContext())
            {
                ViewBag.studentClasses = context.Classes.ToList();
                TempData["studentClasses"] = context.Classes.ToList();
            }
            return View();
        }


        [HttpPost]
        public ActionResult Add(StudentViewModel viewModel)
        {
            /*
             * RouteValueDictionary 
             */
            try
            {
                using (var context =new EducationContext())
                {
                    if (!ModelState.IsValid)
                        return View(viewModel);
                    else
                    {
                        var student = new Student()
                        {
                            PhoneNumber = viewModel.PhoneNumber,ClassId = viewModel.ClassId,IdentityNumber = viewModel.IdentityNumber,
                            LastName = viewModel.LastName,Name = viewModel.Name,CreateDate = viewModel.CreateDate,SchoolNumber = viewModel.SchoolNumber,
                            IsDeleted = viewModel.IsDeleted
                        };
                        context.Students.Add(student);
                        context.SaveChanges();
                        return RedirectToAction("Index","Education");
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
                        Id = student.Id
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

                    var student = context.Students?.FirstOrDefault(s=> s.Id==viewModel.Id && s.IsDeleted==false);
                    if (student==null)
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
                    context.SaveChanges();
                    return RedirectToAction("Index","Education");
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
                using (var context =new EducationContext())
                {
                    var student = context.Students?.FirstOrDefault(s=> s.Id==studentId && s.IsDeleted==false);
                    if (student==null)
                    {
                        return View("Error");
                    }
                    student.IsDeleted = true;
                    context.SaveChanges();
                    return  RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}