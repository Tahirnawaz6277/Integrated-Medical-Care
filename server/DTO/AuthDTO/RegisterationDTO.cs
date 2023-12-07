using server.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.DTO.AuthDTO
{
    public class RegisterationDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string Contact { get; set; }

        public string Gender { get; set; }

        public int RoleId { get; set; }

  
    }
}
