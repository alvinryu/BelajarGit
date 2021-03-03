using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Person")]
    public class Person
    {
        [Key]
        [Required(ErrorMessage = "This field is required")]
        public string NIK { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Salary { get; set; }

        public string Email { get; set; }
        [JsonIgnore]

        public virtual Account Account { get; set; }

    }
}