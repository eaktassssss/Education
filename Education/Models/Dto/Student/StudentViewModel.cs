using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Models.Dto.Student
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string SchoolNumber { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime CreateDate
        {
            get { return DateTime.Now;}
        }
        public bool IsDeleted
        {
            get { return false;}
        }
    }
}