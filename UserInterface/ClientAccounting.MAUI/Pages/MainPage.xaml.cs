using ClientAccounting.MAUI.ViewModel;

namespace ClientAccounting.MAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly ClientsView _clientsView;
        private readonly ClientView _clientView;

        public MainPage(ClientsView clientsView, ClientView clientView)
        {
            this.InitializeComponent();
            this._clientsView = clientsView; this._clientView = clientView;
        }
        private void Button_Clicked(object sender, EventArgs e) => 
           Navigation.PushAsync(new ListPage(_clientsView, _clientView));
    }
}