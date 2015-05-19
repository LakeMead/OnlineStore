namespace OnlineStore.Web.Models.ViewModels.Home
{
    public class TopRatedProductsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public double Rating { get; set; }
    }
}
