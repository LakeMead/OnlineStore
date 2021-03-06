﻿namespace OnlineStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data.Contracts;

    public class Order : DeletableEntity
    {
        private ICollection<OrderDetail> orderDetails;

        public Order()
        {
            this.orderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }

        [Index]
        public OrderStatus OrderStatus { get; set; }

        public decimal Total { get; set; }

        public int CustomerInfoId { get; set; }

        public virtual CustomerInfo CustomerInfo { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails
        {
            get { return this.orderDetails; }
            set { this.orderDetails = value; }
        }
    }
}
