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
    public ClientsView _ClientsView;
    private ClientView _ClientView;
    public ListPage(ClientsView clientsView, ClientView clientView)
    {
        InitializeComponent();

        this._ClientsView = clientsView; this._ClientView = clientView;
        this.BindingContext = _ClientsView;
    }

    private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Client current)
        {
            _ClientView.Client = current;
            await Navigation.PushAsync(new ClientPage(_ClientView,_ClientsView));
        }
    }
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
    }
    protected internal void AddClient(Client client) => _ClientsView.AddClient(client);
    protected internal void UpdateClients(Client client) =>
        _ClientsView.Clients[_ClientsView.Clients.IndexOf(_ClientsView.Clients.First(id => id.IdClient == client.IdClient))] = client;
    private void Button_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new AddClientPage(_ClientView));
}