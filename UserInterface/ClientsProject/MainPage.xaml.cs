using ClientsProject.DAL.Entities;
using ClientsProject.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using ClientsProject.DAL.Interfaces;
using ClientsProject.ViewModel;

namespace ClientsProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ClientView clientView)
        {   
            this.InitializeComponent();

            this.BindingContext = clientView;
        }
    }
}