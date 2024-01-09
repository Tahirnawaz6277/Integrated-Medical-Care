using System.ComponentModel.DataAnnotations;

namespace imc_web_api.Models
{
    public class user_qualification
    {
        [Key]
        public Guid Id { get; set; }

        public string qualification { get; set; }

        public string experience { get; set; }

        public int userId { get; set; }
        public user User { get; set; }
    }
}
