﻿using System.ComponentModel.DataAnnotations;

namespace imc_web_api.Models
{
    public class serviceprovidertype
    {
        
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Provider name is required.")]
        [StringLength(50, ErrorMessage = "name cannot be longer than 30 characters.")]
        public string ProviderName { get; set; }

        public user User { get; set; }
        public List<pharmacyambulanceservice> givenServices { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}