namespace BookAPI.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
