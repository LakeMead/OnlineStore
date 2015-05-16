using OnlineStore.Common.Enumerations;

namespace OnlineStore.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories.Contracts;

    public class ProductsRepository : DeletableEntityRepository<Product>, IProductsRepository
    {
        public ProductsRepository(IOnlineStoreDbContext context) 
            : base(context)
        {
        }

        public IQueryable<Product> GetByCategoryId(int id)
        {
            return this.Context.Products.Where(p => p.CategoryId == id);
        }

        public IQueryable<Product> GetByCategoryName(string name)
        {
            return this.Context.Products.Where(p => p.Category.Name == name);
        }

        public IQueryable<Product> GetByLabelId(int id)
        {
            return this.Context.Products.Where(p => p.Labels.Select(l => l.Id).Contains(id));
        }

        public IQueryable<Product> GetByColorId(int id)
        {
            return this.Context.Products.Where(p => p.Colors.Select(c => c.Id).Contains(id));
        }

        public IQueryable<Product> GetByColor(IEnumerable<int> ids)
        {
            throw new NotImplementedException();

            //levelInstancesEntities = searchTerms.Aggregate(
            //        levelInstancesEntities,
            //        (current, element) => current.Where(x => x.NameEn.Contains(element) || x.NameBg.Contains(element)));

        }

        public IQueryable<Product> GetDiscounted()
        {
            return this.Context.Products.Where(p => p.DiscountId != null);
        }

        public IQueryable<Product> GetMostRated()
        {
            return this.Context.Products.OrderByDescending(p => p.Ratings.Select(r => r.Type));
        }

        public IQueryable<Product> GetMostOrdered()
        {
            return this.Context.Products.OrderByDescending(p => p.Orders.Count(o => o.OrderStatus == OrderStatus.Delivered));
        }

        public IQueryable<Product> GetFiltered(int? colorId, int? categoryId, int? labelId, decimal? minPrice, decimal? maxPrice)
        {
            string query = String.Empty;

            if (colorId != null)
            {
                    
            }

            return this.Context.Products.Where(p => p.Colors.Select(c => c.Id).Contains(colorId));
        }
    }
}
