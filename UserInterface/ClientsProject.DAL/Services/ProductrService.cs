using ClientsProject.DAL.EF;
using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ClientsProject.DAL.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbContextFactory<ClientAccountingContext> _factory;
        public ProductService(IDbContextFactory<ClientAccountingContext> factory) => _factory = factory;

        public async Task AddProductAsync(Product order)
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                await factory.Products.AddAsync(order); await factory.SaveChangesAsync();
            }
        }

        public async Task ChangeProductAsync(Product order)
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                factory.Products.Update(order); await factory.SaveChangesAsync();
            }
        }

        public async Task<Product?> GetProductAsync(Product product)
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                return await factory.Products.Where(p => p == product).Include(p1 => p1.Reviews.Where(p2 => p2.IdProduct == product.IdProduct)).FirstOrDefaultAsync();
            }
        }

        public List<Product> GetProducts()
        {
            using (var factory = _factory.CreateDbContext())
            {
                return factory.Products.ToList();
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                return await factory.Products.ToListAsync();
            }
        }

        public async Task<List<Product>> GetProductsByQuery(string query)
        {
            using (var factory = await _factory.CreateDbContextAsync())
                return factory.Products.Where(name => Microsoft.EntityFrameworkCore.EF.Functions.Like(name.Name!, $"%{query}%")).ToList();
        }

        public async Task SaveChangeAsync()
        {
            using (var factory = await _factory.CreateDbContextAsync())
                await factory.SaveChangesAsync();
        }
    }
}
