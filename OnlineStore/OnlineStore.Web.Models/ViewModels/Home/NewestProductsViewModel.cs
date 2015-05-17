namespace OnlineStore.Web.Models.ViewModels.Home
{
    using System;

    public class NewestProductsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
