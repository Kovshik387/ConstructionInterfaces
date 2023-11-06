using ClientAccounting.MAUI.ViewModel.ProductVm;
using ClientsProject.DAL.Entities;
using System.Globalization;

namespace ClientAccounting.MAUI.Pages;

public partial class ProductListPage : ContentPage
{
	private readonly ProductsView _productsVm;
    private readonly ProductView _productVm;
	public ProductListPage(ProductsView productsView, ProductView productView)
	{
		InitializeComponent();

        _productsVm = productsView; _productVm = productView;
		this.BindingContext = _productsVm;
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Product current) return;
        
        _productVm.Product = current;
        await Navigation.PushAsync(new ProductPage(_productVm));
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Equals("")) _productsVm.GetProducts();
        else _productsVm.GetSearched(e.NewTextValue);

        this.collectionView.ItemsSource = _productsVm.Products;
    }

    protected override void OnAppearing()
    {
        _productsVm.GetProducts();
        this.collectionView.ItemsSource = _productsVm.Products;
        base.OnAppearing();
    }
}