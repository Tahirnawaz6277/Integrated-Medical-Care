using System.ComponentModel.DataAnnotations;

namespace imc_web_api.Models
{
    public class serviceprovidertype
    {

        [Key]
        public Guid Id { get; set; }
        public string ProviderName { get; set; }  


        public user User { get; set; }
        public List<service> givenServices { get; set; }
    }
}