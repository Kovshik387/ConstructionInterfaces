using ClientsProject.DAL.Entities;
using ClientAccounting.MAUI.ViewModel.ClientVm;

namespace ClientAccounting.MAUI.Pages;

public partial class ListPage : ContentPage
{
    public ClientsView _clientsView;
    private ClientView _clientView;
    private AddClientView _addClientView;
    public ListPage(ClientsView clientsView, ClientView clientView, AddClientView addClientView)
    {
        InitializeComponent();

        this._clientsView = clientsView; this._clientView = clientView; this._addClientView = addClientView;
        this.BindingContext = _clientsView;
    }
    private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Client current)
        {
            _clientView.Client = current;
            await Navigation.PushAsync(new ClientPage(_clientView));
        }
    }
    protected override void OnAppearing()
    {
        _clientsView.GetAllClient();
        this.collectionView.ItemsSource = _clientsView.Clients;
        this.searchBar.Text = string.Empty;
    }
    private void Button_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new AddClientPage(_addClientView));
    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Equals("")) _clientsView.GetAllClient();
        else _clientsView.GetSearched(e.NewTextValue);

        this.collectionView.ItemsSource = _clientsView.Clients;
    }
}