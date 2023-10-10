using ClientsProject.ViewModel;

namespace ClientsProject.Page;

public partial class ListPage : ContentPage
{
    private readonly ClientsView _clientsView;
	public ListPage(ClientsView clientView)
	{
        _clientsView = clientView;
        this.BindingContext = clientView;
        InitializeComponent();
	}

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Navigation.PushAsync(new ClientPage(new ClientView(_clientsView.SelectedClient)));
    }
}