using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using ClientsProject.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace ClientsProject.Pages;

public partial class ClientPage : ContentPage
{
    private ClientView _clintView;
	public ClientPage(ClientView clientView)
	{
        InitializeComponent();
        _clintView = clientView;
        this.BindingContext = _clintView;
    }

    protected override bool OnBackButtonPressed()
    {
        if (Microsoft.Maui.Controls.Application.Current?.MainPage is NavigationPage navPage)
        {
            IReadOnlyList<Microsoft.Maui.Controls.Page> navStack = navPage.Navigation.NavigationStack;

            int pageCount = navPage.Navigation.NavigationStack.Count;
            if (navStack[pageCount - 2] is ListPage mainPage)
            {
                mainPage._ClientsView.UpdateClients(_clintView.Client);
            }
        }
        return base.OnBackButtonPressed();
    }
}