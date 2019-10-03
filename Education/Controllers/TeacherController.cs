using Education.Models.Context;
using Education.Models.Dto.Base;
using Education.Models.Dto.Days;
using Education.Models.Dto.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Education.Filters;
using Education.Models.Dto.Teacher;

namespace Education.Controllers
{
    [CustomAuthenticationFilter]
    public class TeacherController : Controller
    {
        private EducationContext context;
        public TeacherController()
        {
            context=new EducationContext();
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
                /*
                 *  Yöntem 1 model içinde model
                 */

                baseModel = new BaseViewModel
                {
                    Days = context.Days.Select(day => new DayViewModel()
                    {
                        Name = day.Name,
                        Id = day.Id
                    }),
                    Lessons = context.Lessons.Select(day => new LessonViewModel()
                    {
                        Name = day.Name,
                        Id = day.Id

                    }),
                };


                /*
                 * Yöntem 2 tuple kullanmak
                 */

                var lessons = context.Lessons.Select(x => new LessonViewModel() { Id = x.Id, Name = x.Name })
                    .ToList();
                var days = context.Days.Select(x => new DayViewModel() { Id = x.Id, Name = x.Name })
                    .ToList();
                var tupleBaseModel = new Tuple<TeacherViewModel, List<LessonViewModel>, List<DayViewModel>>(new TeacherViewModel(), lessons, days);
                return View(tupleBaseModel);
                //return View(baseModel);
            }
            catch
            {
                return View("Error");
            }

        }

        [HttpPost]
        public JsonResult Add([Bind(Prefix = "Item1")] TeacherViewModel viewModel)
        {
            try
            {
                var teacher = new Teacher()
                {
                    Name =viewModel.Name,SurName = viewModel.SurName,PhoneNumber = viewModel.PhoneNumber,IdentityNumber = viewModel.IdentityNumber,
                    LessonId = viewModel.LessonId,Age = viewModel.Age,DayOffId = viewModel.DayOffId,Email = viewModel.Email,
                    CreateDate = DateTime.Now,IsDeleted = false
                };
                context.Teachers.Add(teacher);
                context.SaveChanges();
                return Json(new {result = "Öğretmen kaydı oluşturuldu.", resultType = true});
            }
            catch 
            {
                return Json(new { result = "Beklenmedik bir hata oluştu", resultType = false });
            }
          
        }

 
    }
}