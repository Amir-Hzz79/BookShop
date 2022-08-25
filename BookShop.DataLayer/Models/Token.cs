using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
