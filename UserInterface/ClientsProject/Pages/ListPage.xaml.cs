using ClientsProject.DAL.Entities;
using ClientsProject.DAL.Interfaces;
using ClientsProject.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace ClientsProject.Pages;

public partial class ListPage : ContentPage
{
    public ClientsView _clientsView;
    private ClientView _clientView;
    public ListPage(ClientsView clientsView, ClientView clientView)
    {
        InitializeComponent();

        this._clientsView = clientsView; this._clientView = clientView;
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
        var clients = _clientsView.GetAllClient();
        this.collectionView.ItemsSource = clients;
    }
    private void Button_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new AddClientPage(_clientView));
}