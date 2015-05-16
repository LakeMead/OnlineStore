namespace OnlineStore.Data.Models
{
    using OnlineStore.Data.Contracts;

    public class ContactFormFeedback : DeletableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
    }
}
