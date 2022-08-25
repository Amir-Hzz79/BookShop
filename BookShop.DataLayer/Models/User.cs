using System.ComponentModel.DataAnnotations;

namespace BookShop.DataLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage ="Name is required!!")]
        //public string Name { get; set; }

        //[Required(ErrorMessage = "Email is required!!")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "Username is required!!")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Password is required!!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public virtual List<Role> roles { get; set; }

        //public User()
        //{

        //}
    }
}
