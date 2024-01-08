using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }

        [ForeignKey("ServiceProviderId")]
        public service ServiceProvider { get; set; }

        public int ServiceProviderId { get; set; }
    }
}