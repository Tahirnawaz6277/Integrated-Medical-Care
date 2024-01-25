using imc_web_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Dtos.AdminDtos.AgreementDtos
{
    public class AgreementResponseDto
    {
        public Guid Id { get; set; }

        public bool IsAgreed { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public user User { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
