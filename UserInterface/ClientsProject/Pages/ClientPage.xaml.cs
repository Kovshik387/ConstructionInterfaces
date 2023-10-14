using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using ClientsProject.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace ClientsProject.Pages;

public partial class ClientPage : ContentPage
{
    private readonly ClientView _clientView;
    public ClientPage(ClientView clientView)
	{
        InitializeComponent();
        _clientView = clientView;
        this.BindingContext = _clientView;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.collectionView.ItemsSource = _clientView.Reviews; 
    }

    //private async void collectionViewSelected(object sender, EventArgs e)
    //{

    //}
}