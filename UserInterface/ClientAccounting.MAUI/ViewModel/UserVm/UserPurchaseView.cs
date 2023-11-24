using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System.Collections.ObjectModel;

namespace ClientAccounting.MAUI.ViewModel.UserVm
{
    public class UserPurchaseView
    {
        private readonly IProductService _productService;
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public UserPurchaseView(IProductService productService)
        {
            _productService = productService; GetProductsAsync();
        }

        protected internal async void GetProductsAsync() => this.Products = new ObservableCollection<Product>
            (await _productService.GetUserProductAsync(int.Parse(await SecureStorage.Default.GetAsync("id_user"))));

        protected internal async Task GetProducts(string query = "")
        {
            var id = int.Parse(await SecureStorage.GetAsync("id_user"));

            this.Products = new ObservableCollection<Product>
            (_productService.GetUserProduct(id, query));
        }
    }
}
