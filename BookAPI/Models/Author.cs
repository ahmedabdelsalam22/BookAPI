using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="First name can't be more than 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Last name can't be more than 200 characters")]
        public string LastName { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
