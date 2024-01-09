﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace imc_web_api.Models
{
    public class user : IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string Role { get; set; }

        public Guid?  ServiceProvidertypeId { get; set; }

        [ForeignKey("ServiceProvidertypeId")]
        public serviceprovidertype ServiceProviderType { get; set; }

        public Guid? User_QualificationId { get; set; }
        [ForeignKey("User_QualificationId")]
        public user_qualification User_Qualification { get; set; }
    }
}

