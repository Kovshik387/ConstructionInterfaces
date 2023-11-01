using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using ClientsProject.DAL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAccounting.MAUI.ViewModel.ProductVm
{
    public class ProductsView
    {
        private readonly IProductService _productService;
        public ObservableCollection<Product> Products { get; private set; }
        public ProductsView(IProductService productService)
        {
            _productService = productService; 
            GetProductsAsync();
        }
        protected internal async void GetSearched(string query) => Products = new ObservableCollection<Product>(await _productService.GetProductsByQuery(query));
        protected internal async void GetProductsAsync() => Products = new ObservableCollection<Product>(await _productService.GetProductsAsync());
    }
}
