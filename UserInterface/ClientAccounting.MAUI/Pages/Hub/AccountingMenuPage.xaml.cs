using ClientAccounting.MAUI.ViewModel.ClientVm;
using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI.Pages.Hub;

public partial class AccountingMenuPage : ContentPage
{
    private readonly ClientsView _clientsView;
    private readonly ClientView _clientView;
    private readonly AddClientView _addClientView;

    private readonly ProductsView _productsView;
    private readonly ProductView _productView;

    public AccountingMenuPage(ClientsView clientsView, ClientView clientView, AddClientView addClientView,
            ProductsView productsView, ProductView productView)
    {
        InitializeComponent();
        this._clientsView = clientsView; this._clientView = clientView; this._addClientView = addClientView;
        this._productsView = productsView; this._productView = productView;
    }
    private void Button_Clicked(object sender, EventArgs e) =>
        Navigation.PushAsync(new ListPage(_clientsView, _clientView, _addClientView));

    private async void AddClient_Clicked(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync("addclient", true);

    private void Product_Clicked(object sender, EventArgs e) =>
        Navigation.PushAsync(new ProductListPage(_productsView, _productView));

    private async void AddProduct_Clicked(object sender, EventArgs e) =>
        await Shell.Current.GoToAsync("addproduct", true);
}