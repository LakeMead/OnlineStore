namespace OnlineStore.Web.Models.ViewModels.Base.Home
{
    using System;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class NewestProductsViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
