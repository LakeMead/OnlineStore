namespace OnlineStore.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    
    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;

    public interface IProductsRepository : IDeletableEntityRepository<Product>
    {
        IQueryable<Product> GetByCategoryId(int id);

        IQueryable<Product> GetByCategoryName(string name);
        
        IQueryable<Product> GetByLabelId(int id);

        IQueryable<Product> GetByColorId(int id);

        IQueryable<Product> GetByColor(IEnumerable<int> ids);

        IQueryable<Product> GetDiscounted();

        IQueryable<Product> GetByDiscountId(int id);

        IQueryable<Product> GetMostRated();

        double GetRating(int id);

        IQueryable<Product> GetMostOrdered();

        IQueryable<Product> GetByOrderId(int id);

        IQueryable<Product> GetFiltered(int? colorId, int? categoryId, int? labelId, decimal? minPrice, decimal? maxPrice);
    }
}
