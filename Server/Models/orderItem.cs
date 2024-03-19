using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class orderItem
    {
        public Guid Id { get; set; }

        public Guid ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public service Service { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public order Order { get; set; }
    }
}