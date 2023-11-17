using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using ClientsProject.DAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientAccounting.MAUI.ViewModel.ProductVm
{
    public class ProductView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Product Product { get; set; }

        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public ProductView(IProductService productService, IUserService userService)
        {
            this._productService = productService; this._userService = userService;
        }

        public string Name
        {
            get => Product.Name; set
            {
                if (Product.Name != value)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    Product.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int? Count
        {
            get => Product.Count; set
            {
                if (Product.Count != value)
                {
                    if (value is null)
                        return;

                    Product.Count = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Price
        {
            get => Product.Price; set
            {
                if (Product.Price != value && Product.Price > 0)
                {
                    Product.Price = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateOnly? DateRelease
        {
            get => Product.Daterelease; set
            {
                if (Product.Daterelease != value)
                {
                    if (value is null)
                        return;

                    Product.Daterelease = value;
                }
            }
        }
        public string Branch
        {
            get => Product.Branch; set
            {
                if (Product.Branch != value && value is not null && value.Length > 1 && value.Length < 20)
                {
                    Product.Branch = value;
                    OnPropertyChanged();
                }
            }
        }

        [AllowNull]
        public byte[] Photo
        {
            get => Product.Photo; set
            {
                if (Product.Photo != value)
                {
                    if (value is null)
                        return;

                    Product.Photo = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task<bool> Purchase()
        {
            if (this.Count <= 0) return false;

            var user_id = int.Parse(await SecureStorage.Default.GetAsync("id_user"));

            this.Count -= 1; await _productService.ChangeProductAsync(Product);

            await _userService.PurchaseByIdAsync(user_id, this.Product.IdProduct);
            
            return true;
        }

        public void ChangeProduct() => this._productService.ChangeProductAsync(Product);

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
