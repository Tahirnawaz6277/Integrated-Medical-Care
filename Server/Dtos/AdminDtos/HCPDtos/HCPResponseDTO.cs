using imc_web_api.Models;

namespace imc_web_api.Dtos.AdminDtos.HCPDtos
{
    public class HCPResponseDTO
    {
     
        public Guid Id { get; set; }
        public string ProviderName { get; set; }


        public user User { get; set; }
        public List<pharmacyambulanceservice> givenServices { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
