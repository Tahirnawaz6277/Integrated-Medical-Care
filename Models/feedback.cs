using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class feedback
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public user User { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public service Service { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public order Order { get; set; }
    }
}