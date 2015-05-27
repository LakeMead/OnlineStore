namespace OnlineStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Data.Contracts;

    public class Category : DeletableEntity
    {
        private ICollection<Product> products; 
        private ICollection<Category> subCategories;

        public Category()
        {
            this.products = new HashSet<Product>();
            this.subCategories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        [Index]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public int Order { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public virtual ICollection<Category> SubCategories
        {
            get { return this.subCategories; }
            set { this.subCategories = value; }
        }
    }
}
