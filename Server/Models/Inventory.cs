namespace imc_web_api.Models
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public string Service { get; set; }
        public int TotalQuantity { get; set; } = 0;

        public int AvailableQuantity { get; set; } = 0;
    }
}