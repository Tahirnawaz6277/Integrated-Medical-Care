namespace imc_web_api.Models
{
    public class serviceprovider
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }

        public string ContactNumber { get; set; }

        public string Specialization { get; set; }
        public string ProviderType { get; set; }
    }
}