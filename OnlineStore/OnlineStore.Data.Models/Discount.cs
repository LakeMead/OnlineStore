namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Data.Contracts;

    public class Discount : DeletableEntity, IAuditInfo
    {
        private ICollection<Product> products;

        public Discount()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

        [Index]
        public double Percent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
