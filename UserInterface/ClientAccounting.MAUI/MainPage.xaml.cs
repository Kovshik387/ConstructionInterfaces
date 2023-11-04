using ClientAccounting.MAUI.Pages;
using ClientAccounting.MAUI.ViewModel.ClientVm;
using ClientAccounting.MAUI.ViewModel.ProductVm;

namespace ClientAccounting.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly ClientsView _clientsView;
        private readonly ClientView _clientView;
        private readonly AddClientView _addClientView;

        private readonly ProductsView _productsView;
        private readonly ProductView _productView;
        private readonly AddProductView _addProductView;

        public MainPage(ClientsView clientsView, ClientView clientView, AddClientView addClientView,
            ProductsView productsView, ProductView productView, AddProductView addProductView)
        {
            this.InitializeComponent();
            this._clientsView = clientsView; this._clientView = clientView; this._addClientView = addClientView;
            this._productsView = productsView; this._productView = productView; this._addProductView = addProductView;
        }

        private void Button_Clicked(object sender, EventArgs e) =>
           Navigation.PushAsync(new ListPage(_clientsView, _clientView,_addClientView));

        private void AddClient_Clicked(object sender, EventArgs e)  =>
            Navigation.PushAsync(new AddClientPage(_addClientView));

        private void Product_Clicked(object sender, EventArgs e) =>
            Navigation.PushAsync(new ProductListPage(_productsView, _productView));

        private void AddProduct_Clicked(object sender, EventArgs e) =>
            Navigation.PushAsync(new AddProductPage(_addProductView));
    }
}