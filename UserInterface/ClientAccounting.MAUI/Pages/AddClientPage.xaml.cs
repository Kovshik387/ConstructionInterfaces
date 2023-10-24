using ClientAccounting.MAUI.ViewModel;
using System.Windows.Input;

namespace ClientAccounting.MAUI.Pages;

public partial class AddClientPage : ContentPage
{
	private ICommand AddClient { get; }

	private readonly ClientView _clientView;

	public AddClientPage(ClientView clientView)
	{
		InitializeComponent();
		_clientView = clientView;
	}

    protected override bool OnBackButtonPressed()
    {
        if (Microsoft.Maui.Controls.Application.Current?.MainPage is NavigationPage navPage)
        {
            IReadOnlyList<Microsoft.Maui.Controls.Page> navStack = navPage.Navigation.NavigationStack;

            int pageCount = navPage.Navigation.NavigationStack.Count;
            if (navStack[pageCount - 2] is ListPage mainPage) mainPage._clientsView.AddClient(_clientView.Client);
        }
        return base.OnBackButtonPressed();
    }
}