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
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await this.ClientsButton.ScaleTo(1.05, 150);
        await this.ClientsButton.ScaleTo(1, 150);
        await Shell.Current.GoToAsync("clientlist", true);//await Navigation.PushAsync(new ListPage(_clientsView, _clientView, _addClientView));
    }

    private async void AddClient_Clicked(object sender, EventArgs e)
    {
        await this.AddButton.ScaleTo(1.05, 150);
        await this.AddButton.ScaleTo(1, 150);
        await Shell.Current.GoToAsync("addclient", true);
    }

    private async void Product_Clicked(object sender, EventArgs e)
    {
        await this.ListButton.ScaleTo(1.05, 150);
        await this.ListButton.ScaleTo(1, 150);
        await Shell.Current.GoToAsync("product_list_user", true);//await Navigation.PushAsync(new ProductListPage(_productsView, _productView));
    }

    private async void AddProduct_Clicked(object sender, EventArgs e)
    {
        await this.ProductButton.ScaleTo(1.05, 150);
        await this.ProductButton.ScaleTo(1, 150);
        await Shell.Current.GoToAsync("addproduct", true);
    }

    private async void Snapshot_Clicked(object sender, EventArgs e)
    {
        await this.SnapshotButton.ScaleTo(1.05, 150);
        await this.SnapshotButton.ScaleTo(1, 150);
        await Shell.Current.GoToAsync("snapshot", true);
    }
}