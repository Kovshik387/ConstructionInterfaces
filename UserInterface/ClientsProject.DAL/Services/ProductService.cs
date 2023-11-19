using ClientsProject.DAL.EF;
using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Net.Sockets;

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

        public List<Product> GetProducts(int id_client = 0)
        {
            using (var factory = _factory.CreateDbContext())
            {
               if (id_client == 0) return factory.Products.ToList();
               else return factory.Products.Include(i => i.Orders.Where(id => id.IdClient == id_client)).ToList();
            }
        }

        public async Task<List<Product>> GetProductsAsync(int id_client = 0)
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                return await factory.Products.ToListAsync();
            }
        }

        public async Task<List<Product>> GetUserProductAsync(int id)
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                var orders = factory.Orders.Include(p => p.IdProductNavigation).Where(i => i.IdClient == id).ToList();

                var products = new List<Product>();

                foreach (var order in orders)
                {
                    var item = order.IdProductNavigation;

                    item.Count = order.Count;

                    products.Add(item);
                }

                return products;
            }
        }

        public List<Product> GetUserProduct(int id)
        {
            using (var factory = _factory.CreateDbContext())
            {
                var orders = factory.Orders.Include(p => p.IdProductNavigation).Where(i => i.IdClient == id).ToList();

                var products = new List<Product>();

                foreach (var order in orders)
                {
                    var item = order.IdProductNavigation;

                    item.Count = order.Count;

                    products.Add(item);
                }
                return products;
            }
        }

        public async Task<List<Product>> GetProductsByQuery(string query)
        {
            using (var factory = await _factory.CreateDbContextAsync())
                return factory.Products.Where(name => Microsoft.EntityFrameworkCore.EF.Functions.Like(name.Name!, $"%{query}%")).ToList();
        }

        public async Task<Product?> GetAnyProduct(string? branch)
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                if (branch is null)
                {
                    var rand_index = new Random().Next(1, factory.Products.Count());

                    var item = await factory.Products.
                        Where(i => i.IdProduct == rand_index && i.Count > 0).FirstOrDefaultAsync();

                    while(item is null)
                    {
                        rand_index = new Random().Next(1, factory.Products.Count());
                        item = await factory.Products.
                        Where(i => i.IdProduct == rand_index && i.Count > 0).FirstOrDefaultAsync();
                    }

                    return item;
                }

                var products = await factory.Products.Where(i => i.Branch == branch && i.Count > 0).ToListAsync();
                if (products.Count == 0) { return await factory.Products.Where(s => s.Count > 0).FirstOrDefaultAsync(); }

                return products[new Random().Next(0,products.Count)];
            }
        }

        public async Task SaveChangeAsync()
        {
            using (var factory = await _factory.CreateDbContextAsync())
                await factory.SaveChangesAsync();
        }
    }
}
