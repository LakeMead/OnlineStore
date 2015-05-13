namespace OnlineStore.Models
{
    public class StaticPageSection
    {
        // TODO: Decide what will be the content of the Static Page Sections
        public int Id { get; set; }

        public int StaticPageId { get; set; }

        public virtual StaticPage StaticPage { get; set; }
    }
}
