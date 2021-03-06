//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Education.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
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
    
        public virtual Day Day { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
