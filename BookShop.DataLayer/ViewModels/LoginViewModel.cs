using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username required!!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required!!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
