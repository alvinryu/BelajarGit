using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class RegisterVM
    {
        public string Nik { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is Required")]
        public string RoleName { get; set; }
    }
}
