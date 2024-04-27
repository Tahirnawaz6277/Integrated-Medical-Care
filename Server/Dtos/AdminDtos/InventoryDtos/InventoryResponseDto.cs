namespace imc_web_api.Dtos.AdminDtos.InventoryDtos
{
    public class InventoryResponseDto
    {
        public Guid Id { get; set; }
        public string Service { get; set; }
        public int TotalQuantity { get; set; }  =0;

        public int AvailableQuantity { get; set; } = 0;
    }
}
