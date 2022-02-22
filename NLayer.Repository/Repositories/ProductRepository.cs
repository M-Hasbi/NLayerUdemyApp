using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //eager loading --> when we take the first products and if we get the categories it called eager loading
            //lazy loading  --> when we get the category with the products, it called lazy loading
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
