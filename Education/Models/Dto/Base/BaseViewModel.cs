using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Education.Models.Dto.Days;
using Education.Models.Dto.Lesson;
using Education.Models.Dto.Teacher;

namespace Education.Models.Dto.Base
{
    public class BaseViewModel
    {
        public IEnumerable<LessonViewModel> Lessons { get; set; }
        public IEnumerable<DayViewModel> Days { get; set; }
        public TeacherViewModel Teacher { get; set; }
    }
}