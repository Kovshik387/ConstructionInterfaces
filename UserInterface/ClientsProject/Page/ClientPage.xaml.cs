using ClientsProject.ViewModel;

namespace ClientsProject.Page;

public partial class ClientPage : ContentPage
{
	private ClientView _clientView;
	public ClientPage(ClientView clientView)
	{
		InitializeComponent();
		_clientView = clientView;

        this.BindingContext = _clientView;
    }
}