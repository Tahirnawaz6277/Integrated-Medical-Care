﻿using System.ComponentModel.DataAnnotations.Schema;
using imc_web_api.Models;

namespace imc_web_api.Dtos.AdminDtos.OrderDtos
{
    public class OrderResponseDTO
    {
        public Guid Id { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }

        public string OrderStatus { get; set; }
        public int Amount { get; set; }
        public string PaymentMode { get; set; }
        public bool IsDeleted { get; set; }
        public string OrderByUserId { get; set; }

        [ForeignKey("OrderByUserId")]
        public user OrderBy { get; set; }

        public DateTime OrderDate { get; set; }
    }
}