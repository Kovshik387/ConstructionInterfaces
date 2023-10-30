using ClientAccounting.MAUI.ViewModel;
using ClientAccounting.MAUI.Pages;

namespace ClientAccounting.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly ClientsView _clientsView;
        private readonly ClientView _clientView;
        private readonly AddClientView _addClientView;

        public MainPage(ClientsView clientsView, ClientView clientView, AddClientView addClientView)
        {
            this.InitializeComponent();
            this._clientsView = clientsView; this._clientView = clientView; this._addClientView = addClientView; 
        }
        private void Button_Clicked(object sender, EventArgs e) =>
           Navigation.PushAsync(new ListPage(_clientsView, _clientView,_addClientView));

        private void AddClient_Clicked(object sender, EventArgs e)  =>
            Navigation.PushAsync(new AddClientPage(_addClientView));
    }
}