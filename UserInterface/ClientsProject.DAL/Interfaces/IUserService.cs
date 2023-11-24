using ClientsProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsProject.DAL.Interfaces
{
    public interface IUserService
    {
        public Task<Client?> GetClientByIdAsync(int id);
        public Client? GetClientById(int id);
        public Task PurchaseByIdAsync(int id_user, int id_product, int count, int price);
        public Task<string?> GetProductForUser(int id_user);
        public Task UserView(int id_user, int id_product);
        public Task AuthoLogg(int id);
        public List<Client> GetClients(DateOnly dateStart, DateOnly dateEnd);
    }
}
