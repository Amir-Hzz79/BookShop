using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Usename required!!")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Name required!!")]
        //public string Name { get; set; }

        [Required(ErrorMessage = "Email required!!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword required!!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Confirm password did not match!!")]
        public string ConfirmPassword { get; set; }
    }
}
