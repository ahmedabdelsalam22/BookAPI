using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Category can't be more than 50 characters")]
        public string Name { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
}
