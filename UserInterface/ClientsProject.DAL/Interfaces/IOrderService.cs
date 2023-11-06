using ClientsProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsProject.DAL.Interfaces
{
    public interface IProductService
    {
        public Task AddProductAsync(Product order);
        public Task ChangeProductAsync(Product order);
        public Task<Product?> GetProductAsync(Product order);
        public Task<List<Product>> GetProductsAsync();
        public List<Product> GetProducts();
        public Task<List<Product>> GetProductsByQuery(string query);
        public Task SaveChangeAsync();
    }
}
