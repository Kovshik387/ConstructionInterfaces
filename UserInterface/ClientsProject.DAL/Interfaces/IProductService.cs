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
        public Product? GetProduct(int id);
        public Task<List<Product>> GetUserProductAsync(int id);
        public List<Product> GetUserProduct(int id);
        public Task<List<Product>> GetProductsAsync(int id_client = 0);
        public List<Product> GetProducts(int id_client = 0);
        public Task<List<Product>> GetProductsByQuery(string query);
        public Task<Product?> GetAnyProduct(string? branch);
        public Task SaveChangeAsync();
        public List<RatingQuery> GetHighBranch(DateOnly date);
        public List<Product> GetProductByDate(DateOnly date);
        public List<Order> GetOrderByDate(DateOnly date);
    }
}
