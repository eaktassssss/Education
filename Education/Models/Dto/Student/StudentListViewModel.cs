﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.Models.Dto.Student
{
    public class StudentListViewModel
    {
        public System.DateTime CreateDate { get; set; }
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string SchoolNumber { get; set; }
        public bool IsDeleted { get; set; }
        public string IdentityNumber { get; set; }
    }
}