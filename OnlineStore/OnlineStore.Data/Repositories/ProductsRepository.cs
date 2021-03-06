﻿namespace OnlineStore.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.AccessControl;

    using OnlineStore.Common.Enumerations;
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

            ////levelInstancesEntities = searchTerms.Aggregate(
            ////        levelInstancesEntities,
            ////        (current, element) => current.Where(x => x.NameEn.Contains(element) || x.NameBg.Contains(element)));
        }

        public IQueryable<Product> GetDiscounted()
        {
            return this.Context.Products.Where(p => p.DiscountId != null);
        }

        public IQueryable<Product> GetByDiscountId(int id)
        {
            return this.Context.Products.Where(p => p.DiscountId == id);
        }

        // Discounted products are excluded
        public IQueryable<Product> GetMostRated()
        {
            return this.Context.Products.Where(np => np.Discount == null).OrderByDescending(p => p.Ratings.Average(r => (int)r.Type)).ThenByDescending(p => p.Price);
        }

        public double GetRating(int id)
        {
            return this.Context.Products.FirstOrDefault(p => p.Id == id).Ratings.Average(r => (int)r.Type);
        }

        // Discounted products are excluded
        public IQueryable<Product> GetTheNewest()
        {
            return this.Context.Products.Where(np => np.Discount == null).OrderByDescending(p => p.CreatedOn);
        }

        // Discounted products are excluded
        public IQueryable<Product> GetMostOrdered()
        {
            return this.Context.Products.Where(np => np.Discount == null).OrderByDescending(p => p.Orders.Count(o => o.OrderStatus == OrderStatus.Delivered)).ThenByDescending(p => p.Price);
        }

        public IQueryable<Product> GetByOrderId(int id)
        {
            return this.Context.Products.Where(p => p.Orders.Select(o => o.Id).Contains(id));
        }

        public IQueryable<Product> GetFiltered(int? colorId, int? categoryId, int? labelId, decimal? minPrice, decimal? maxPrice)
        {
            var colorFilter = colorId == null ? this.Context.Products : this.GetByColorId(colorId.Value);
            var categoryFilter = categoryId == null ? colorFilter : colorFilter.Where(c => c.CategoryId == categoryId);
            var labelFilter = labelId == null ? categoryFilter : categoryFilter.Where(p => p.Labels.Select(l => l.Id).Contains(labelId.Value));
            var minPriceFilter = minPrice == null ? labelFilter : labelFilter.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            return minPriceFilter;
        }
    }
}
