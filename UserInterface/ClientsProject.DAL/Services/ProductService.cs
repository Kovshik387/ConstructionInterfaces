using ClientsProject.DAL.EF;
using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Product? GetProduct(int id)
        {
            using (var factory = _factory.CreateDbContext())
            {
                return factory.Products.
                    Where(p => p.IdProduct == id).
                    Include(p1 => p1.Reviews.Where(p2 => p2.IdProduct == id)).
                    ThenInclude(s => s.IdClientNavigation).
                    Include(i => i.Orders.Where(idp => idp.IdProduct == id)).
                    ThenInclude(s => s.IdClientNavigation).
                    Include(v => v.Viewclients.Where(s1 => s1.IdProduct == id)).
                    ThenInclude(s => s.IdClientNavigation).
                    FirstOrDefault();
            }
        }

        public List<Product> GetProducts(int id_client = 0)
        {
            using (var factory = _factory.CreateDbContext())
            {
               if (id_client == 0) return factory.Products.
                        Include(i => i.Viewclients).ThenInclude(s => s.IdClientNavigation).ToList();
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
                return orders.Select(x => x.IdProductNavigation).ToList();
            }
        }

        public List<Product> GetUserProduct(int id, string query = "")
        {
            using (var factory = _factory.CreateDbContext())
            {
                var orders = new List<Order>();
                var orders_quarable = factory.Orders.Include(p => p.IdProductNavigation).
                    ThenInclude(r => r.Reviews).
                    Where(i => i.IdClient == id);

                switch (query)
                {
                    case "":
                        orders = orders_quarable.ToList();
                        break;
                    default:
                        if (DateOnly.TryParse(query, out var date))
                        {
                            orders = orders_quarable.Where(q => q.Daterelease == date).ToList();
                        }
                        else orders = orders_quarable.Where(
                            q => Microsoft.EntityFrameworkCore.EF.Functions.Like(q.IdProductNavigation.Name!, $"%{query}%") ||
                            Microsoft.EntityFrameworkCore.EF.Functions.Like(q.IdProductNavigation.Branch!, $"%{query}%")).ToList();
                        break;
                };

                var products = new List<Product>();

                foreach (var order in orders)
                {
                    Product item = new()
                    {
                        Count = order.Count, Branch = order.IdProductNavigation.Branch,
                        Daterelease = order.Daterelease,
                        Name = order.IdProductNavigation.Name,
                        Price = (int)order.Purchaseprice!,
                        IdProduct = order.IdProduct,
                        Photo = order.IdProductNavigation.Photo,
                        Viewclients = order.IdProductNavigation.Viewclients,
                        Reviews = order.IdProductNavigation.Reviews,
                        Orders = order.IdProductNavigation.Orders,
                        Lastview = order.IdProductNavigation.Lastview,
                        Ispurchased = order.IdProductNavigation.Ispurchased,
                        
                    };
                    products.Add(item);
                }

                return products;
            }
        }

        public async Task<List<Product>> GetProductsByQuery(string query)
        {
            using (var factory = await _factory.CreateDbContextAsync())
                return factory.Products.Where(name => Microsoft.EntityFrameworkCore.EF.Functions.Like(name.Name!, $"%{query}%") 
                || Microsoft.EntityFrameworkCore.EF.Functions.Like(name.Branch!, $"%{query}%")).ToList();
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

                return products[new Random().Next(0,products.Count)];
            }
        }

        public async Task SaveChangeAsync()
        {
            using (var factory = await _factory.CreateDbContextAsync())
                await factory.SaveChangesAsync();
        }

        public List<Product> GetProductByDate(DateOnly dateStart, DateOnly dateEnd)
        {
            using var factory = _factory.CreateDbContext();
            return factory.Products.
                Where(d => d.Daterelease >= dateStart && d.Daterelease <= dateEnd).ToList();
        }

        public List<RatingQuery> GetHighBranch(DateOnly dateStart, DateOnly dateEnd)
        {
            using var factory = _factory.CreateDbContext();
            var temp = factory.Orders.Where(d => d.Daterelease >= dateStart && d.Daterelease <= dateEnd).
                Include(p => p.IdProductNavigation).
                GroupBy(x => x.IdProductNavigation.Branch).
                Select(s => new { Name = s.Key, Count = s.Count() }).Where(s => s.Count > 0).ToList();

            var temp_rating = new List<RatingQuery>();

            foreach (var item in temp) { temp_rating.Add(new RatingQuery() { Name = item.Name!, Count = item.Count}); }

            return temp_rating;
        }

        public List<Order> GetOrderByDate(DateOnly dateStart, DateOnly dateEnd)
        {
            using var factory = _factory.CreateDbContext();
            return factory.Orders.
                Where(d => d.Daterelease >= dateStart && d.Daterelease <= dateEnd).
                Include(s => s.IdProductNavigation).
                ToList();
        }
    }
}
