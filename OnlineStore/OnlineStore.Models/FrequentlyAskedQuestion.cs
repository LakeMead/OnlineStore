namespace OnlineStore.Models
{
    using OnlineStore.Data.Contracts;

    public class FrequentlyAskedQuestion : DeletableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int? Order { get; set; }
    }
}
