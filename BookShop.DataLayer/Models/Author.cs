using System.ComponentModel.DataAnnotations;

namespace BookShop.DataLayer.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for this book")]
        public string Name { get; set; }

        public string About { get; set; }

        public virtual List<Book> Books { get; set; }

        public Author()
        {

        }
    }
}
