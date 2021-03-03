using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Education")]
    public class Education
    {
        [Key]
        [Required(ErrorMessage = "This field is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Degree  { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string GPA { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int University_Id { get; set; }

        [JsonIgnore]
        public virtual University University { get; set; }

        [JsonIgnore]
        public virtual List<Profiling> Profiling { get; set; } = new List<Profiling>();
    }
}
