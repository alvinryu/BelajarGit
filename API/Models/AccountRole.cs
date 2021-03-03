using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("Tb_T_AccountRole")]
    public class AccountRole
    {
        [JsonIgnore]
        public int Id { get; set; }
        public virtual Role Role { get; set; }
        public string NIK { get; set; }
        public virtual Account Account { get; set; }
    }
}
