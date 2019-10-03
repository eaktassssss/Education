using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Education.Models.Dto.Student
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int ClassId { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        [RegularExpression(@"[A-z^şŞıİçÇöÖüÜĞğ\s]*", ErrorMessage = "Geçersiz metin girişi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [RegularExpression(@"[A-z^şŞıİçÇöÖüÜĞğ\s]*", ErrorMessage = "Geçersiz metin girişi")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Telefon numarası format dışı")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [MaxLength(11, ErrorMessage = "Okul numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "Okul numarası 11 haneli olmalıdır")]
        public string SchoolNumber { get; set; }

        public DateTime CreateDate
        {
            get { return DateTime.Now;}
        }
        public bool IsDeleted
        {
            get { return false;}
        }

        [Required(ErrorMessage = "Zorunlu alan")]
        [Range(1, 100, ErrorMessage = "1 ile 100 arası bir değer giriniz")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Format dışı email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        [MaxLength(11, ErrorMessage = "Kimlik numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "Kimlik numarası 11 haneli olmalıdır")]
        public string IdentityNumber { get; set; }
    }
}