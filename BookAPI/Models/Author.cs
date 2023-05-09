namespace BookAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public virtual Country Country { get; set; }
    }
}
