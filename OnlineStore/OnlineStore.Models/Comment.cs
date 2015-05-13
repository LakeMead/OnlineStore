namespace OnlineStore.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }


    }
}
