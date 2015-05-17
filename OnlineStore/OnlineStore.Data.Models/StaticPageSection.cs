namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StaticPageSection
    {
        // TODO: Decide what will be the content of the Static Page Sections
        [Key]
        public int Id { get; set; }

        public int StaticPageId { get; set; }

        public virtual StaticPage StaticPage { get; set; }
    }
}
