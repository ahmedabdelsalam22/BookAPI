﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =3,ErrorMessage ="ISBN must be between 3 and 10 characters")]
        public string Isbn { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
