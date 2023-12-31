﻿using ClientsProject.DAL.EF;
using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace ClientsProject.DAL.Services
{
    public class ClientService : IClientService
    {
        private readonly IDbContextFactory<ClientAccountingContext> _databaseFactory;

        public ClientService(IDbContextFactory<ClientAccountingContext> databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public ObservableCollection<Client> GetSearchedClients(string query)
        {
            using (var factory = _databaseFactory.CreateDbContext())
            {
                return new ObservableCollection<Client>(factory.Clients.Where(name => Microsoft.EntityFrameworkCore.EF.Functions.Like(name.Name, $"%{query}%")).ToList());
            }
        }

        public Client GetInfo(Client client)
        {
            using (var factory = _databaseFactory.CreateDbContext())
                return factory.Clients.Where(d_client => d_client == client).Include(r => r.Reviews).
                    ThenInclude(p => p.IdProductNavigation).Include(o => o.Orders).ThenInclude(p => p.IdProductNavigation).First();
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            using (var factory = _databaseFactory.CreateDbContext())
                return await factory.Clients.FirstOrDefaultAsync(_id => _id.IdClient == id);
        }

        public async Task<List<Client>> GetClientAllAsync()
        {
            using (var factory = _databaseFactory.CreateDbContext())
                return await factory.Clients.ToListAsync();
        }

        public void AddClient(Client client)
        {
            using (var factory = _databaseFactory.CreateDbContext())
            {
                factory.Clients.Add(client);
                factory.SaveChanges();
            }
        }
        public void ChangeClient(Client client)
        {
            using (var factory = _databaseFactory.CreateDbContext())
            {
                factory.Clients.Update(client);
                factory.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            using (var factory = _databaseFactory.CreateDbContext())
                factory.SaveChanges();
        }

        public List<Client> GetClientAll()
        {
            using (var factory = _databaseFactory.CreateDbContext())
                return factory.Clients.ToList();
        }

    }
}
