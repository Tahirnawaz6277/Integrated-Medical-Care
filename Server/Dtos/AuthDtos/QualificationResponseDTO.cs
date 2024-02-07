using imc_web_api.Models;

namespace imc_web_api.Dtos.AuthDtos
{
    public class QualificationResponseDTO
    {
        public Guid Id { get; set; }

        public string qualification { get; set; }

        public string experience { get; set; }



        public user User { get; set; }
    }
}