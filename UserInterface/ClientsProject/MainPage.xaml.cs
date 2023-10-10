using ClientsProject.DAL.Entities;
using ClientsProject.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using ClientsProject.DAL.Interfaces;
using ClientsProject.ViewModel;
using ClientsProject.Page;

namespace ClientsProject
{
    public partial class MainPage : ContentPage
    {
        private readonly ClientsView _clientView;
        public MainPage(ClientsView client)
        {
            this.InitializeComponent();
            this._clientView = client;
        }

        private void Button_Clicked(object sender, EventArgs e)
            => Navigation.PushAsync(new ListPage(_clientView));
    }
}