using ClientsProject.DAL.Entities;
using ClientsProject.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using ClientsProject.DAL.Interfaces;
using ClientsProject.ViewModel;
using ClientsProject.Pages;

namespace ClientsProject
{
    public partial class MainPage : ContentPage
    {
        private readonly ClientsView _clientsView;
        private readonly ClientView _clientView;

        public MainPage(ClientsView clientsView, ClientView clientView)
        {
            this.InitializeComponent();
            this._clientsView = clientsView; this._clientView = clientView;
        }
        private void Button_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new ListPage(_clientsView,_clientView),true);
    }
}