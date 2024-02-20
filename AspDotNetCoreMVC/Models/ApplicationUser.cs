using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public int Name { get; set; }

        public String? StreetAddress { get; set; }
        public String? City{ get; set; }
        public String? State { get; set; }
        public String? PostalCode { get; set; }
    }
}
