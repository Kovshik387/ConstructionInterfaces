using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
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
    public class AddProductView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Product Product { get; set; } = new Product();

        private readonly IProductService _productService;
        public AddProductView(IProductService productService)
        {
            this._productService = productService;

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

        public DateOnly? DateRelease
        {
            get => Product.Daterelease; set
            {
                if (Product.Daterelease != value)
                {
                    if (value is null)
                        return;

                    Product.Daterelease = value;
                    OnPropertyChanged();
                }
            }
        }
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

        public void ChangeProduct() => this._productService.ChangeProductAsync(Product);
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            ChangeProduct();
        }
    }
}
