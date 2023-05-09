using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Reviewer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "First name can't be more than 100 characters")]
        public string FirsName { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Last name can't be more than 200 characters")]
        public string LastName { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
