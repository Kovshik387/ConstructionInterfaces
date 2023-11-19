using ClientsProject.DAL.EF;
using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientsProject.DAL.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContextFactory<ClientAccountingContext> _factory;
        public UserService(IDbContextFactory<ClientAccountingContext> factory) => _factory = factory; 
        public async Task<Client?> GetClientByIdAsync(int id)
        {
            using (var factory = await _factory.CreateDbContextAsync())
                return await factory.Clients.Where(u => u.IdClient == id).Include(f => f.Orders.Where(o => o.IdClient == id)).FirstOrDefaultAsync();
        }

        public Client? GetClientById(int id)
        {
            using (var factory = _factory.CreateDbContext())
                return factory.Clients.Where(u => u.IdClient == id).Include(f => f.Orders.Where(o => o.IdClient == id)).FirstOrDefault();
        }

        public async Task<string?> GetProductForUser(int id_user)
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                var query = factory.Orders.Include(p => p.IdProductNavigation).
                    Where(i => i.IdClient == id_user).
                    GroupBy(o => o.IdProductNavigation.Branch).
                    OrderByDescending(c => c.Count()).
                    Select(c => new { Name = c.Key, Count = c.Count() }).
                    ToList().FirstOrDefault();

                if (query is null) return null;
                else return query.Name;
            }
        }

        public async Task PurchaseByIdAsync(int id_user, int id_product)
        {
            using (var factory = await _factory.CreateDbContextAsync())
            {
                var repeats = factory.Orders.Where(i => i.IdProduct == id_product).FirstOrDefault();
                if (repeats is not null) 
                {
                    repeats.Count++;
                    factory.Update(repeats); await factory.SaveChangesAsync();
                    return;
                }

                var order = new Order() {
                    Count = 1, Name = factory.Products.Where(i => i.IdProduct == id_product).FirstOrDefault()!.Name,
                    Daterelease = DateOnly.FromDateTime(DateTime.Now),
                    IdClient = id_user, IdProduct = id_product
                };

                await factory.AddAsync(order); await factory.SaveChangesAsync();
            }
        }
    }
}
