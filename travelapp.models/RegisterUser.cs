using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelapp.models
{
    public class RegisterUser
    {
        public int Id { get; set; }
        [Required]
        public string  UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string HashPassword { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
