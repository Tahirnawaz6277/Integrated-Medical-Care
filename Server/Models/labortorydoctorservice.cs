using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class labortorydoctorservice
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }

        public double Fees { get; set; }

        public double Price { get; set; }

        public Guid? CreatedByProviderTypeId { get; set; } = null;

        [ForeignKey("CreatedByProviderTypeId")]
        public serviceprovidertype ServiceProviderType { get; set; }

        public string? CreatedByAdminId { get; set; }

        [ForeignKey("CreatedByAdminId")]
        public user User { get; set; }

        public List<feedback> User_Feedbacks { get; set; }

        public order order { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}