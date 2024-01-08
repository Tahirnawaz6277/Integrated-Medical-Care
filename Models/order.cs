using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class order
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public user User { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public service Service { get; set; }
    }
}