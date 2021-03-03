using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_University")]
    public class University
    {
        [Key]
        [Required(ErrorMessage = "This field is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [JsonIgnore]

        public virtual List<Education> Education { get; set; } = new List<Education>();
    }
}