using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class agreement
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="IsAgreed is Required.")]
        public bool IsAgreed { get; set; }


        public string ServiceProviderId { get; set; }

        [ForeignKey("ServiceProviderId")]
        public user ServiceProvider { get; set; }

        public string AdminId { get; set; }

        [ForeignKey("AdminId")]
        public user Admin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}