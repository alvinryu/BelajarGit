using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Profiling")]
    public class Profiling
    {
        [Key]
        [Required(ErrorMessage = "This field is required")]
        public string NIK { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Education_Id { get; set; }

        [JsonIgnore]
        public virtual Education Education { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }

    }
}
