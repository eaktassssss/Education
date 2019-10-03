using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Models.Dto.Teacher
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }
        public int DayOffId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}