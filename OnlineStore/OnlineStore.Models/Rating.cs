namespace OnlineStore.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public RatingTypes Types { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        // TODO: needs to be optional
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }
    }
}
