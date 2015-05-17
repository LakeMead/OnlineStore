namespace OnlineStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StaticPage
    {
        private ICollection<StaticPageSection> staticPageSections;

        public StaticPage()
        {
            this.staticPageSections = new HashSet<StaticPageSection>();
        }

        // TODO: Decide what will be the content of the Static Page
        [Key]
        public int Id { get; set; }

        public virtual ICollection<StaticPageSection> StaticPageSections
        {
            get { return this.staticPageSections; }
            set { this.staticPageSections = value; }
        }
    }
}
