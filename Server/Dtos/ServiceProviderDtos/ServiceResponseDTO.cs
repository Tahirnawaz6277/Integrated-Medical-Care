using System.ComponentModel.DataAnnotations.Schema;
using imc_web_api.Models;

namespace imc_web_api.Dtos.ServiceProviderDtos
{
    public class ServiceResponseDTO
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal charges { get; set; }


        public int AvailableQuantity { get; set; }

        public int TotalQuantity { get; set; }

        public bool QualityAgreementApproved { get; set; }
        public bool Status { get; set; }

        public int Ranking { get; set; } 
        public double Rating { get; set; }
        public string CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        public user User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}