using System.ComponentModel.DataAnnotations;

namespace BookShop.DataLayer.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for this book")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime AddDate { get; set; }

        [Required(ErrorMessage = "Please upload book file")]
        public string File { get; set; }

        public virtual List<Author> Authors { get; set; }

        public Book()
        {
            AddDate = DateTime.Now;
        }
    }
}
