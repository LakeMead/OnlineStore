namespace OnlineStore.Web.Models.ViewModels.Base.Products
{
    using System;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        // TODO: Username map
        public string Username { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
