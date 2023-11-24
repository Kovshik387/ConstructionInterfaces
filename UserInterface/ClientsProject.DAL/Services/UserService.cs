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
            using var factory = await _factory.CreateDbContextAsync();
            return await factory.Clients.Where(u => u.IdClient == id).Include(f => f.Orders.Where(o => o.IdClient == id)).FirstOrDefaultAsync();
        }

        public Client? GetClientById(int id)
        {
            using var factory = _factory.CreateDbContext();
            return factory.Clients.Where(u => u.IdClient == id).Include(f => f.Orders.Where(o => o.IdClient == id)).FirstOrDefault();
        }

        public List<Client> GetClients(DateOnly dateStart, DateOnly dateEnd)
        {
            using var factory = _factory.CreateDbContext();
            return factory.Clients.Where(d => d.Registrationdate >= dateStart && d.Registrationdate <= dateEnd).ToList();
        }

        public async Task<string?> GetProductForUser(int id_user)
        {
            using var factory = await _factory.CreateDbContextAsync();
            var query = factory.Orders.Include(p => p.IdProductNavigation).
                Where(i => i.IdClient == id_user).
                GroupBy(o => o.IdProductNavigation.Branch).
                OrderByDescending(c => c.Count()).
                Select(c => new { Name = c.Key, Count = c.Count() }).
                ToList().FirstOrDefault();

            if (query is null) return null;
            else return query.Name;
        }

        public async Task PurchaseByIdAsync(int id_user, int id_product, int count, int price)
        {
            using var factory = await _factory.CreateDbContextAsync();
            
            var order = new Order()
            {
                Count = count,
                Name = factory.Products.Where(i => i.IdProduct == id_product).FirstOrDefault()!.Name,
                Daterelease = DateOnly.FromDateTime(DateTime.Now),
                IdClient = id_user,
                IdProduct = id_product,
                Purchaseprice = price
            };

            await factory.AddAsync(order); await factory.SaveChangesAsync();
        }

        public async Task UserView(int id_user,int id_product)
        {
            using (var factorty = await _factory.CreateDbContextAsync())
            {
                factorty.Viewclients.Add(new Viewclient()
                {
                    IdClient = id_user,
                    IdProduct = id_product,
                    Dateview = DateOnly.FromDateTime(DateTime.Now)
                });
                await factorty.SaveChangesAsync();
            }
        }

        public async Task AuthoLogg(int id)
        {
            using var factorty = await _factory.CreateDbContextAsync();
            factorty.Clients.Where(i => i.IdClient == id).First().Lastvisit = DateOnly.FromDateTime(DateTime.Now);
            factorty.SaveChanges();
        }
    }
}
