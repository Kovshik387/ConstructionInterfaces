using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientAccounting.MAUI.ViewModel.UserVm
{
    public class StarProductView : INotifyPropertyChanged
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        private int price;
        private int sale_price;

        public event PropertyChangedEventHandler PropertyChanged;

        public Product Product { get; set; }

        public StarProductView(IProductService productService, IUserService userService) => 
            (_productService,_userService) = (productService,userService);

        public string Name { 
            get => Product.Name; set 
            { 
                Product.Name = value;
                OnPropertyChanged();
            } 
        }
        public int? Count
        {
            get => Product.Count; set
            {
                Product.Count = value;
                OnPropertyChanged();
            }
        }
        public DateOnly? Daterelease
        {
            get => Product.Daterelease; set
            {
                Product.Daterelease = value;
                OnPropertyChanged();
            }
        }
        public byte[] Photo
        {
            get => Product.Photo; set
            {
                Product.Photo = value;
                OnPropertyChanged();
            }
        }
        public int Price
        {
            get => Product.Price; set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        public string Branch
        {
            get => Product.Branch; set
            {
                Product.Branch = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public async Task<Product> ProductDefition()
        {
            var id_client = int.Parse(await SecureStorage.Default.GetAsync("id_user"));

            var branch = await _userService.GetProductForUser(id_client);

            Product = await _productService.GetAnyProduct(branch);

            price = Product.Price; sale_price = (int)(Product.Price * 0.85);
            Product.Price = sale_price;

            return Product;
        }

        public async Task<bool> Purchase(int count)
        {
            if (this.Product.Count <= 0) return false;

            var user_id = int.Parse(await SecureStorage.Default.GetAsync("id_user"));

            this.Product.Price = price; 

            this.Product.Count -= count; await _productService.ChangeProductAsync(Product); OnPropertyChanged();
            
            await _userService.PurchaseByIdAsync(user_id, this.Product.IdProduct,count, sale_price);

            return true;
        }
    }
}
