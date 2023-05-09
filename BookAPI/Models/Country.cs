﻿namespace BookAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
