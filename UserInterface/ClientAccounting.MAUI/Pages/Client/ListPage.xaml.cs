using ClientsProject.DAL.Entities;
using ClientAccounting.MAUI.ViewModel.ClientVm;

namespace ClientAccounting.MAUI.Pages;

public partial class ListPage : ContentPage
{
    public ClientsView _clientsView;
    public ListPage(ClientsView clientsView)
    {
        InitializeComponent();

        this._clientsView = clientsView;
        this.BindingContext = _clientsView;
    }
    private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Client current) {

            var navParam = new Dictionary<String, object>(){
                { "client",current }
            };

            await Shell.Current.GoToAsync("client", true, navParam);
        }
    }
    protected override void OnAppearing()
    {
        _clientsView.GetAllClient();
        this.collectionView.ItemsSource = _clientsView.Clients;
        this.searchBar.Text = string.Empty;
    }
    private async void Button_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("addproduct",true);
    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Equals("")) _clientsView.GetAllClient();
        else _clientsView.GetSearched(e.NewTextValue);

        this.collectionView.ItemsSource = _clientsView.Clients;
    }
}