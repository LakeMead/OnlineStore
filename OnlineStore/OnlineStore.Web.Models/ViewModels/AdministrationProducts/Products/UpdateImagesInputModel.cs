namespace OnlineStore.Web.Models.ViewModels.AdministrationProducts.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class UpdateImagesInputModel
    {
        public int ProductId { get; set; }

        [UIHint("Upload")]
        public IEnumerable<HttpPostedFileBase> Images { get; set; }
    }
}
