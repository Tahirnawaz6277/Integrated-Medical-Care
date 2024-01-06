using Microsoft.AspNetCore.Identity;

namespace imc_web_api.Models
{
    public class user : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string contact { get; set; }
        public string gender { get; set; }

        public string Role { get; set; }

    }
}
