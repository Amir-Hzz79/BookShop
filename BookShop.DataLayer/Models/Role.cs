using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        //public virtual List<User> users { get; set; }

        //public Role()
        //{

        //}
    }
}
