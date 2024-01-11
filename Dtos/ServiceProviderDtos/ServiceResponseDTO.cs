using imc_web_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Dtos.ServiceProviderDtos
{
    public class ServiceResponseDTO
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal charges { get; set; }

        public string image { get; set; }
        public int AvailableQuantity { get; set; }

        public int TotalQuantity { get; set; }
        public string Status { get; set; }

        public Guid CreatedByProviderTypeId { get; set; }

        [ForeignKey("CreatedByProviderTypeId")]
        public serviceprovidertype ServiceProviderType { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
