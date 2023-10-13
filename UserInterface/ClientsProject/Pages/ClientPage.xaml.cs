using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using ClientsProject.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace ClientsProject.Pages;

public partial class ClientPage : ContentPage
{
    private ClientView _clientView;
    private ClientsView _clientsView;
    public ClientPage(ClientsView clientsView, ClientView clientView)
	{
        InitializeComponent();
        _clientView = clientView;
        _clientsView = clientsView;
        
        this.BindingContext = _clientsView;
    }
    
    protected override bool OnBackButtonPressed()
    {
        if (Microsoft.Maui.Controls.Application.Current?.MainPage is NavigationPage navPage)
        {
            IReadOnlyList<Microsoft.Maui.Controls.Page> navStack = navPage.Navigation.NavigationStack;

            int pageCount = navPage.Navigation.NavigationStack.Count;
            if (navStack[pageCount - 2] is ListPage mainPage)
                mainPage._clientsView.UpdateClients(_clientView.Client);
        }
        return base.OnBackButtonPressed();
    }
}