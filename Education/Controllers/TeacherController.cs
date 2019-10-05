using Education.Filters;
using Education.Models.Context;
using Education.Models.Dto.Base;
using Education.Models.Dto.Days;
using Education.Models.Dto.Lesson;
using Education.Models.Dto.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Education.Controllers
{
    [CustomAuthenticationFilter]
    public class TeacherController : Controller
    {
        private EducationContext context;
        public TeacherController()
        {
            context = new EducationContext();
        }

        [HttpGet]
        public ActionResult Index()
        {


            var result = context.Teachers.Where(x => x.IsDeleted == false).ToList();
            return View(result);

        }



        private BaseViewModel baseModel;
        [HttpGet]
        public ActionResult Add()
        {
            try
            {

                var lessons = context.Lessons.Select(x => new LessonViewModel() { Id = x.Id, Name = x.Name })
                    .ToList();
                var days = context.Days.Select(x => new DayViewModel() { Id = x.Id, Name = x.Name })
                    .ToList();
                var tupleBaseModel = new Tuple<TeacherViewModel, List<LessonViewModel>, List<DayViewModel>>(new TeacherViewModel(), lessons, days);
                return View(tupleBaseModel);

            }
            catch
            {
                return View("Error");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add([Bind(Prefix = "Item1")] TeacherViewModel viewModel)
        {
            try
            {
                var teacher = new Teacher()
                {
                    Name = viewModel.Name,
                    SurName = viewModel.SurName,
                    PhoneNumber = viewModel.PhoneNumber,
                    IdentityNumber = viewModel.IdentityNumber,
                    LessonId = viewModel.LessonId,
                    Age = viewModel.Age,
                    DayOffId = viewModel.DayOffId,
                    Email = viewModel.Email,
                    CreateDate = DateTime.Now,
                    IsDeleted = false
                };
                context.Teachers.Add(teacher);
                context.SaveChanges();
                return Json(new { result = "İşlem  başarılı", resultType = true });
            }
            catch
            {
                return Json(new { result = "Beklenmedik bir hata oluştu", resultType = false });
            }

        }


        [HttpGet]
        public ActionResult Update(int teacherId)
        {
            try
            {
                var teacher = context.Teachers?.Find(teacherId);
                if (teacher != null)
                {
                    var viewModel = new TeacherViewModel
                    {
                        IdentityNumber = teacher.IdentityNumber,
                        Id = teacher.Id,
                        Age = teacher.Age,
                        Email = teacher.Email,
                        PhoneNumber = teacher.PhoneNumber,
                        SurName = teacher.SurName,
                        LessonId = teacher.LessonId,
                        DayOffId = teacher.DayOffId,
                        Name = teacher.Name,
                    };
                    var baseModel = new BaseViewModel()
                    {
                        Teacher = viewModel,
                        Lessons = context.Lessons.Select(x => new LessonViewModel() { Id = x.Id, Name = x.Name }).ToList(),
                        Days = context.Lessons.Select(x => new DayViewModel() { Id = x.Id, Name = x.Name }).ToList(),
                    };
                    return View(baseModel);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return View();
        }
        [HttpPost]
        public JsonResult Update(TeacherViewModel viewModel)
        {
            try
            {
                var teacher = context.Teachers.FirstOrDefault(x => x.Id == viewModel.Id);
                if (teacher != null)
                {
                    teacher.IdentityNumber = viewModel.IdentityNumber;
                    teacher.Id = viewModel.Id;
                    teacher.LessonId = viewModel.LessonId;
                    teacher.Age = viewModel.Age;
                    teacher.Email = viewModel.Email;
                    teacher.SurName = viewModel.SurName;
                    teacher.Name = viewModel.Name;
                    teacher.DayOffId = viewModel.DayOffId;
                    teacher.PhoneNumber = viewModel.PhoneNumber;
                    teacher.IsDeleted = false;
                    teacher.CreateDate=DateTime.Now;
                    
                     
                    context.SaveChanges();
                    return Json(new { result = "Güncelleme başarılı", resultType = true});
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return Json(new { result = "Beklenmedik bir hata oluştu", resultType = false });
        }


        public JsonResult Delete(int teacherId)
        {
            try
            {
                var teacher = context.Teachers?.Find(teacherId);
                if (teacher !=null)
                {
                    teacher.IsDeleted = true;
                    context.SaveChanges();
                    return Json(new {result = "Kayıt silindi", resultType = true});
                }
            }
            catch (Exception exception)
            {
               
                throw new Exception(exception.Message);
            }
            return Json(new { result = "Beklenmedik bir hata oluştu", resultType = false });
        }


        /*
         * NonAction Attribute ile bir actio işleme kapatılabilir.
         *
         */


    }
}