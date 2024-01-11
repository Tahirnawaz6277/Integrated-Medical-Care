﻿namespace imc_web_api.Dtos.ServiceProviderDtos
{
    public class ServiceRequestDTO
    {
        public string ServiceName { get; set; }
        public decimal charges { get; set; }

        public string image { get; set; }
        public int AvailableQuantity { get; set; }

        public int TotalQuantity { get; set; }
        public string Status { get; set; }

        public Guid CreatedByProviderTypeId { get; set; }
    }
}