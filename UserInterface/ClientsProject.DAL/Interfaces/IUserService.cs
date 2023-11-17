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
        public Task PurchaseByIdAsync(int id_user, int id_product);
        public Task<string?> GetProductForUser(int id_user);
    }
}
