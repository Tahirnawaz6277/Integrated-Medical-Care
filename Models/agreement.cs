using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class agreement
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsAgreed { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public user User { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}