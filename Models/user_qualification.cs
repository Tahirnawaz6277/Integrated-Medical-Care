using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class user_qualification
    {
        [Key]
        public Guid Id { get; set; }

        public string qualification { get; set; }

        public string experience { get; set; }

        public string userId { get; set; }
        [ForeignKey("userId")]  
        public user User { get; set; }
    }
}
