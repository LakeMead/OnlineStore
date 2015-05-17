namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using OnlineStore.Data.Contracts;

    public class Discount : DeletableEntity, IAuditInfo
    {
        private ICollection<Product> products;

        public Discount()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public double Percent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // TODO: I am not sure about this one - to be checked with the team
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
